using Client.UserControllers;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Client.GuiController
{
	public class DodajKupcaGuiController
	{
		private UCDodajKupca uCDodajKupca;
		private Kupac kupacZaIzmenu;
		private static DodajKupcaGuiController instance;
		public static DodajKupcaGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DodajKupcaGuiController();
				}
				return instance;
			}
		}
		private DodajKupcaGuiController()
		{
		}

		public void DodajKupca()
		{
			
			if (!Validacija())
			{
				MessageBox.Show("Sistem ne moze da kreira kupca");
				return;
			}
			Mesto m = uCDodajKupca.CmbMesto.SelectedItem as Mesto;
			Kupac k = new Kupac
			{
				Ime = uCDodajKupca.TbIme.Text,
				Prezime = uCDodajKupca.TbPrezime.Text,
				Email = uCDodajKupca.TbEmail.Text,
				KontaktTelefon = uCDodajKupca.TbKontaktTelefon.Text,
				Mesto = m
			};
			Response response=Communication.Instance.UnesiKorisnika(k);
			if(response.ExceptionMessage != null)
			{
				MessageBox.Show("Greška prilikom čuvanja korisnika: " + response.ExceptionMessage);
				return;
			}
			k.Id= (long)response.Result;
			MessageBox.Show("Sistem je kreirao kupca");
			uCDodajKupca.TbIme.Text = "";
			uCDodajKupca.TbPrezime.Text = "";
			uCDodajKupca.TbEmail.Text = "";
			uCDodajKupca.TbKontaktTelefon.Text = "";
			uCDodajKupca.CmbMesto.SelectedIndex = -1;

		}

		private bool Validacija()
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(uCDodajKupca.TbIme.Text))
			{
				uCDodajKupca.TbIme.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajKupca.TbPrezime.Text))
			{
				uCDodajKupca.TbPrezime.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajKupca.TbEmail.Text))
			{
				uCDodajKupca.TbEmail.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajKupca.TbKontaktTelefon.Text))
			{
				uCDodajKupca.TbKontaktTelefon.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajKupca.CmbMesto.Text))
			{
				uCDodajKupca.CmbMesto.BackColor = Color.Salmon;
				isValid = false;
			}
			return isValid;
		}

		internal BindingList<Mesto> UcitajMesta()
		{
			Response response = Communication.Instance.VratiMesta();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Greska prilikom ucitavanja mesta: " + response.ExceptionMessage);
				return null;
			}
			return (BindingList<Mesto>)response.Result;
		}

		internal void PopuniFormu(UCDodajKupca uCDodajKupca)
		{
			this.uCDodajKupca = uCDodajKupca;
			uCDodajKupca.BtnSacuvaj.Visible = true;
			uCDodajKupca.BtnAzuriraj.Enabled = false;
			uCDodajKupca.CmbMesto.DataSource = UcitajMesta();
			uCDodajKupca.BtnSacuvaj.Click += btnSacuvaj_Click;
		}

		internal void PopuniFormu(UCDodajKupca uCDodajKupca, long i)
		{
			this.uCDodajKupca = uCDodajKupca;
			uCDodajKupca.BtnSacuvaj.Visible = false;
			uCDodajKupca.BtnAzuriraj.Enabled = true;
			uCDodajKupca.BtnAzuriraj.Click += btnAzuriraj_Click;
			uCDodajKupca.CmbMesto.DataSource = UcitajMesta();
			kupacZaIzmenu = new Kupac
			{
				Id = i
			};

			kupacZaIzmenu = VratiKupca(kupacZaIzmenu);
			uCDodajKupca.TbIme.Text = kupacZaIzmenu.Ime;
			uCDodajKupca.TbPrezime.Text = kupacZaIzmenu.Prezime;
			uCDodajKupca.TbEmail.Text = kupacZaIzmenu.Email;
			uCDodajKupca.TbKontaktTelefon.Text = kupacZaIzmenu.KontaktTelefon;
			uCDodajKupca.CmbMesto.SelectedItem = kupacZaIzmenu.Mesto;
		}

		private Kupac VratiKupca(Kupac izmenjenKupac)
		{
			Response response = Communication.Instance.VratiKupca(izmenjenKupac);
			if(response.ExceptionMessage != null)
			{
				MessageBox.Show("Greska prilikom ucitavanja kupca: " + response.ExceptionMessage);
				return null;
			}
			return (Kupac)response.Result;
		}

		private void btnAzuriraj_Click(object? sender, EventArgs e)
		{
			if (!Validacija())
			{
				MessageBox.Show("Sistem ne moze da zapamti kupca");
				return;
			}
			string ime = uCDodajKupca.TbIme.Text;
			string prezime = uCDodajKupca.TbPrezime.Text;
			string email = uCDodajKupca.TbEmail.Text;
			string telefon = uCDodajKupca.TbKontaktTelefon.Text;
			Mesto m = (Mesto)uCDodajKupca.CmbMesto.SelectedItem;

			DialogResult result = MessageBox.Show("Da li sigurno zelite da sacuvate izmene?", "Sacuvaj Izmene",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				kupacZaIzmenu.Ime = ime;
				kupacZaIzmenu.Prezime = prezime;
				kupacZaIzmenu.Email = email;
				kupacZaIzmenu.KontaktTelefon = telefon;
				kupacZaIzmenu.Mesto = m;
				Response response=Communication.Instance.AzurirajKupca(kupacZaIzmenu);
				if (response.ExceptionMessage != null)
				{
					MessageBox.Show("Greska prilikom azuriranja kupca: " + response.ExceptionMessage);
					return;
				}
				Kupac k= (Kupac)response.Result;
				MessageBox.Show("Kupac je uspesno promenjen");
				MainCoordinator.Instance.KupacAzuriran(k);
			}
		}

		private void btnSacuvaj_Click(object sender, EventArgs e)
		{
			DodajKupca();
		}
	}
}

		

