using Client.UserControllers;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
	public class DodajStrSpremuGuiController
	{
		private UCDodajStrSpremu uCDodajStrSpremu;
		private StrSprema strSpremaZaIzmenu;
		private static DodajStrSpremuGuiController instance;
		public static DodajStrSpremuGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DodajStrSpremuGuiController();
				}
				return instance;
			}
		}
		private DodajStrSpremuGuiController()
		{
		}

		private bool Validacija()
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(uCDodajStrSpremu.TbNaziv.Text))
			{
				uCDodajStrSpremu.TbNaziv.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajStrSpremu.TbOpis.Text))
			{
				uCDodajStrSpremu.TbOpis.BackColor = Color.Salmon;
				isValid = false;
			}

			return isValid;
		}

		internal void PopuniFormu(UCDodajStrSpremu uCDodajStrSpremu)
		{
			this.uCDodajStrSpremu = uCDodajStrSpremu;
			uCDodajStrSpremu.BtnIzmeni.Visible = false;
			uCDodajStrSpremu.BtnDodaj.Visible = true;
			uCDodajStrSpremu.BtnDodaj.Click += btnDodaj_Click;

		}
		private void btnDodaj_Click(object sender, EventArgs e)
		{
			if (!Validacija())
			{
				MessageBox.Show("Sistem ne moze da kreira strucnu spremu");
				return;
			}

			StrSprema ss = new StrSprema
			{
				Naziv = uCDodajStrSpremu.TbNaziv.Text,
				Opis = uCDodajStrSpremu.TbOpis.Text
			};

			Response response = Communication.Instance.UnesiStrSpremu(ss);
			ss.Id = (long)response.Result;
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Greska prilikom unosa strucne spreme: " + response.ExceptionMessage);
				return;
			}
			MessageBox.Show("Sistem je kreirao strucnu spremu");
			uCDodajStrSpremu.TbNaziv.Text = "";
			uCDodajStrSpremu.TbOpis.Text = "";
		}

		internal void PopuniFormu(UCDodajStrSpremu uCDodajStrSpremu, long i)
		{
			this.uCDodajStrSpremu = uCDodajStrSpremu;
			uCDodajStrSpremu.BtnIzmeni.Visible = true;
			uCDodajStrSpremu.BtnDodaj.Visible = false;
			uCDodajStrSpremu.BtnIzmeni.Click += btnIzmeni_Click;
			strSpremaZaIzmenu= new StrSprema { Id = i };
			strSpremaZaIzmenu = VratiStrSpremu(strSpremaZaIzmenu);
			uCDodajStrSpremu.TbNaziv.Text = strSpremaZaIzmenu.Naziv;
			uCDodajStrSpremu.TbOpis.Text = strSpremaZaIzmenu.Opis;
		}

		private StrSprema VratiStrSpremu(StrSprema strSpremaZaIzmenu)
		{
			Response response = Communication.Instance.VratiStrSpremu(strSpremaZaIzmenu);
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Greska prilikom ucitavanja kupca: " + response.ExceptionMessage);
				return null;
			}
			return (StrSprema)response.Result;
		}

		private void btnIzmeni_Click(object? sender, EventArgs e)
		{
			if (!Validacija())
			{
				MessageBox.Show("Popunite sva polja!");
				return;
			}
			string naziv = uCDodajStrSpremu.TbNaziv.Text;
			string opis = uCDodajStrSpremu.TbOpis.Text;

			DialogResult result = MessageBox.Show("Da li sigurno zelite da sacuvate izmene?", "Sacuvaj Izmene",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				strSpremaZaIzmenu.Naziv = naziv;
				strSpremaZaIzmenu.Opis = opis;
				Response response = Communication.Instance.AzurirajStrSpremu(strSpremaZaIzmenu);
				if (response.ExceptionMessage != null)
				{
					MessageBox.Show("Greska prilikom azuriranja strucne spreme: " + response.ExceptionMessage);
					return;
				}
				StrSprema ss = (StrSprema)response.Result;
				MessageBox.Show("Strucna sprema je uspesno promenjena");
				MainCoordinator.Instance.StrSpremaAzurirana(ss);
			}
		}
	}
}
