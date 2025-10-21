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
	public class RadSaPorudzbenicamaGuiController
	{
		private BindingList<Porudzbenica> porudzbenice;
		FrmMain frmMain;
		private UCRadSaPorudzbenicama uCRadSaPorudzbenicama;
		private static RadSaPorudzbenicamaGuiController instance;
		public static RadSaPorudzbenicamaGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RadSaPorudzbenicamaGuiController();
				}
				return instance;
			}
		}


		private RadSaPorudzbenicamaGuiController()
		{
		}

		internal void PopuniFormu(UCRadSaPorudzbenicama uCRadSaPorudzbenicama, FrmMain frmMain)
		{
			this.frmMain = frmMain;
			this.uCRadSaPorudzbenicama = uCRadSaPorudzbenicama;
			uCRadSaPorudzbenicama.DgvPorudzbenice.AutoGenerateColumns = false;
			porudzbenice = VratiPorudzbenice();
			uCRadSaPorudzbenicama.DgvPorudzbenice.DataSource = porudzbenice;
			uCRadSaPorudzbenicama.CmbKupac.DataSource = VratiKupce();
			uCRadSaPorudzbenicama.CmbKupac.SelectedIndex = -1;
			uCRadSaPorudzbenicama.CmbKupac.SelectedIndexChanged += CmbKupac_SelectedIndexChanged;
			uCRadSaPorudzbenicama.BtnPrikaziSve.Click += BtnPrikaziSve_Click;
			uCRadSaPorudzbenicama.BtnIzbrisi.Click += BtnIzbrisi_Click;
			uCRadSaPorudzbenicama.BtnDetalji.Click += BtnDetalji_Click;
		}

		private void BtnDetalji_Click(object? sender, EventArgs e)
		{
			if (uCRadSaPorudzbenicama.DgvPorudzbenice.SelectedRows.Count > 0)
			{
				Porudzbenica p = uCRadSaPorudzbenicama.DgvPorudzbenice.SelectedRows[0].DataBoundItem as Porudzbenica;
				MainCoordinator.Instance.ShowDodajPorudzbenicuForm(frmMain, p.Id);
			}
			else
			{
				MessageBox.Show("Niste odabrali red");
			}
		}

		private void BtnIzbrisi_Click(object? sender, EventArgs e)
		{
			if (uCRadSaPorudzbenicama.DgvPorudzbenice.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow selectedRow in uCRadSaPorudzbenicama.DgvPorudzbenice.SelectedRows)
				{
					Porudzbenica p = selectedRow.DataBoundItem as Porudzbenica;
					Response r = Communication.Instance.ObrisiPorudzbenicu(p);
					if (r.ExceptionMessage != null)
					{
						MessageBox.Show("Greska pri brisanju mesta: " + r.ExceptionMessage);
					}
					else
					{
						MessageBox.Show("Sistem je obrisao porudzbenicu");
					}
				}
				uCRadSaPorudzbenicama.DgvPorudzbenice.DataSource = VratiPorudzbenice();
			}
			else
			{
				MessageBox.Show("Izaberite barem jedan red");
			}
		}

		private void BtnPrikaziSve_Click(object? sender, EventArgs e)
		{
			uCRadSaPorudzbenicama.DgvPorudzbenice.DataSource = porudzbenice;
			uCRadSaPorudzbenicama.CmbKupac.SelectedIndex = -1;
		}

		private void CmbKupac_SelectedIndexChanged(object? sender, EventArgs e)
		{
			if (uCRadSaPorudzbenicama.CmbKupac.SelectedIndex < 0) return;

			Kupac selektovaniKupac = uCRadSaPorudzbenicama.CmbKupac.SelectedItem as Kupac;

			if (selektovaniKupac != null)
			{
				var filtrirane = porudzbenice.Where(p => p.Kupac.Id == selektovaniKupac.Id).ToList();

				uCRadSaPorudzbenicama.DgvPorudzbenice.DataSource = new BindingList<Porudzbenica>(filtrirane);
			}
		}

		private object? VratiKupce()
		{
			Response response = Communication.Instance.VratiKupce();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju kupaca: " + response.ExceptionMessage);
				return null;
			}

			return response.Result;
		}

		private BindingList<Porudzbenica> VratiPorudzbenice()
		{
			Response response = Communication.Instance.VratiPorudzbenice();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju porudzbenica: " + response.ExceptionMessage);
				return null;
			}

			return (BindingList<Porudzbenica>)response.Result;
		}

		internal void OsveziPorudzbenicu(Porudzbenica p)
		{
			var stari = porudzbenice.FirstOrDefault(x => x.Id == p.Id);
			if (stari != null)
			{
				stari.DatumOd = p.DatumOd;
				stari.DatumDo = p.DatumDo;
				stari.UkupnaVr = p.UkupnaVr;
				stari.Radnik = p.Radnik;
				stari.Kupac = p.Kupac;
				uCRadSaPorudzbenicama.DgvPorudzbenice.Refresh();
			}
		}
	}
}
