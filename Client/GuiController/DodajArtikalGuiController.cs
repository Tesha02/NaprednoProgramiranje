using Client.UserControllers;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
	public class DodajArtikalGuiController
	{
		public event Action<Artikal> ArtikalAzuriran;
		private UCDodajArtikal uCDodajArtikal;
		private Artikal artikalZaIzmenu;
		private static DodajArtikalGuiController instance;
		public static DodajArtikalGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DodajArtikalGuiController();
				}
				return instance;
			}
		}
		private DodajArtikalGuiController()
		{
			
		}

		internal object? UcitajTipove()
		{
			Response response = Communication.Instance.VratiTipove();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Greška pri učitavanju tipova: " + response.ExceptionMessage);
				return null;
			}
			List<Tip> tipovi = (List<Tip>)response.Result;
			return tipovi;
		}

		internal void DodajArtikal(UCDodajArtikal uCDodajArtikal)
		{
			this.uCDodajArtikal = uCDodajArtikal;
			try
			{
				if (!Validacija())
				{
					MessageBox.Show("Los unos podataka");
					return;
				}
				string naziv = uCDodajArtikal.TbNaziv.Text;
				long cena = long.Parse(uCDodajArtikal.TbCena.Text);
				Tip tip = (Tip)uCDodajArtikal.CmbTip.SelectedItem;
				Artikal a = new Artikal
				{
					Naziv = naziv,
					Cena = cena,
					Tip = tip
				};
				Response response= Communication.Instance.VratiArtikle();
				if (response.ExceptionMessage != null)
				{
					MessageBox.Show("Greška pri učitavanju artikala: " + response.ExceptionMessage);
					return;
				}
				
				BindingList<Artikal> artikli = (BindingList<Artikal>)response.Result;
				if(artikli.Any(artikal=>artikal.Naziv==a.Naziv)) {
					MessageBox.Show("Sistem ne moze da kreira artikal");
					return;
				}

				response=Communication.Instance.DodajArtikal(a);
				if(response.ExceptionMessage != null)
				{
					MessageBox.Show("Greska pri cuvanju artikla: "+response.ExceptionMessage);
					return;
					
				}
				a.Id = (long)response.Result;
				MessageBox.Show("Sistem je kreirao artikal");
				uCDodajArtikal.TbNaziv.Text = "";
				uCDodajArtikal.TbCena.Text = "";
				uCDodajArtikal.CmbTip.SelectedIndex = -1;

			}
			catch (Exception ex)
			{
				MessageBox.Show("Greska pri prijavljivanju: " + ex.Message);
			}
		}

		private bool Validacija()
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(uCDodajArtikal.TbNaziv.Text))
			{
				uCDodajArtikal.TbNaziv.BackColor = Color.Salmon;
				isValid = false;
			}
			int broj;
			if (!int.TryParse(uCDodajArtikal.TbCena.Text, out broj))
			{
				uCDodajArtikal.TbCena.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajArtikal.CmbTip.Text))
			{
				uCDodajArtikal.CmbTip.BackColor = Color.Salmon;
				isValid = false;
			}

			return isValid;
		}

		internal void VratiArtikal(UCDodajArtikal uCDodajArtikal, int id)
		{
			throw new NotImplementedException();
		}

		internal void PopuniFormu(UCDodajArtikal uCDodajArtikal, long id)
		{
			uCDodajArtikal.BtnAzuriraj.Click += btnAzuriraj_Click;
			this.uCDodajArtikal= uCDodajArtikal;
			uCDodajArtikal.BtnSacuvaj.Visible = false;
			uCDodajArtikal.BtnAzuriraj.Enabled = true;
			uCDodajArtikal.CmbTip.DataSource = UcitajTipove();
			artikalZaIzmenu = new Artikal
			{
				Id = id
			};
			artikalZaIzmenu = VratiArtikal(artikalZaIzmenu);
			uCDodajArtikal.TbNaziv.Text = artikalZaIzmenu.Naziv;
			uCDodajArtikal.TbCena.Text = artikalZaIzmenu.Cena + "";
			uCDodajArtikal.CmbTip.SelectedItem = artikalZaIzmenu.Tip;
		}

		private Artikal VratiArtikal(Artikal artikalZaIzmenu)
		{
			Response response=Communication.Instance.VratiArtikal(artikalZaIzmenu);
			if(response.ExceptionMessage != null)
			{
				MessageBox.Show("Greška pri učitavanju artikla: " + response.ExceptionMessage);
				return null;
			}
			return (Artikal)response.Result;
		}

		private void btnAzuriraj_Click(object? sender, EventArgs e)
		{
			if (!Validacija())
			{
				MessageBox.Show("Popunite sva polja!");
				return;
			}
			string naziv = uCDodajArtikal.TbNaziv.Text;
			long cena = long.Parse(uCDodajArtikal.TbCena.Text);
			Tip tip = (Tip)uCDodajArtikal.CmbTip.SelectedItem;

			DialogResult result = MessageBox.Show("Da li sigurno zelite da sacuvate izmene?", "Sacuvaj Izmene",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				artikalZaIzmenu.Naziv = naziv;
				artikalZaIzmenu.Cena = cena;
				artikalZaIzmenu.Tip = tip;
				Response resp=Communication.Instance.AzurirajArtikal(artikalZaIzmenu);
				if (resp.ExceptionMessage != null)
				{
					MessageBox.Show("Greška pri izmeni artikla: " + resp.ExceptionMessage);
					return;
				}
				MessageBox.Show("Artikal je uspešno izmenjen!");
				Artikal artikal = (Artikal)resp.Result;
				MainCoordinator.Instance.ArtikalAzuriran(artikal);
			}
		}

		internal void PopuniFormu(UCDodajArtikal uCDodajArtikal)
		{
			this.uCDodajArtikal = uCDodajArtikal;
			uCDodajArtikal.BtnSacuvaj.Visible = true;
			uCDodajArtikal.BtnAzuriraj.Visible = false;
			uCDodajArtikal.CmbTip.DataSource = UcitajTipove();
			uCDodajArtikal.BtnSacuvaj.Click += btnSacuvaj_Click;
		}

		private void btnSacuvaj_Click(object sender, EventArgs e)
		{
			DodajArtikal(uCDodajArtikal);
		}
	}
}
