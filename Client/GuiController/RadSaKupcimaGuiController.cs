using Azure;
using Client.UserControllers;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Response = Common.Communication.Response;

namespace Client.GuiController
{
	public class RadSaKupcimaGuiController
	{
		private BindingList<Kupac> kupci;
		private UCRadSaKupcima uCRadSaKupcima;
		FrmMain frmMain;
		private static RadSaKupcimaGuiController instance;
		public static RadSaKupcimaGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RadSaKupcimaGuiController();
				}
				return instance;
			}
		}
		private RadSaKupcimaGuiController()
		{
		}

		internal void PopuniFormu(UCRadSaKupcima uCRadSaKupcima, FrmMain frmMain)
		{
			this.uCRadSaKupcima = uCRadSaKupcima;
			this.frmMain = frmMain;
			uCRadSaKupcima.DgvKupci.AutoGenerateColumns = false;
			kupci =VratiKupce();
			uCRadSaKupcima.DgvKupci.DataSource = kupci;
			uCRadSaKupcima.TbPretraga.TextChanged += tbPretraga_TextChanged;
			uCRadSaKupcima.DgvKupci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			uCRadSaKupcima.BtnDetalji.Click += btnDetalji_Click;
		}

		private BindingList<Kupac> VratiKupce()
		{
			Response response = Communication.Instance.VratiKupce();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju kupaca: " + response.ExceptionMessage);
				return null;
			}
			
			return (BindingList<Kupac>)response.Result;
			
		}

		private void tbPretraga_TextChanged(object? sender, EventArgs e)
		{
			string filter = uCRadSaKupcima.TbPretraga.Text.Trim();
			var filteredKupci = kupci.Where(k => k.Ime.Contains(filter) || k.Prezime.Contains(filter)).ToList();

			uCRadSaKupcima.DgvKupci.DataSource = new BindingList<Kupac>(filteredKupci);
		}

		private void btnDetalji_Click(object sender, EventArgs e)
		{
			if (uCRadSaKupcima.DgvKupci.SelectedRows.Count > 0)
			{
				Kupac k = uCRadSaKupcima.DgvKupci.SelectedRows[0].DataBoundItem as Kupac;
				MainCoordinator.Instance.ShowDodajKupcaForm(frmMain, k.Id);
			}
			else
			{
				MessageBox.Show("Niste odabrali red");
			}
		}

		internal void OsveziKupca(Kupac k)
		{
			var stari = kupci.FirstOrDefault(x => x.Id == k.Id);
			if (stari != null)
			{
				stari.Ime = k.Ime;
				stari.Prezime = k.Prezime;
				stari.Email = k.Email;
				stari.KontaktTelefon = k.KontaktTelefon;
				stari.Mesto = k.Mesto;
				uCRadSaKupcima.DgvKupci.Refresh();
			}
		}
	}
}
