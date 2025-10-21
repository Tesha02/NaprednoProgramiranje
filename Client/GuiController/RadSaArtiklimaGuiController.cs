using Azure;
using Client.UserControllers;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Response = Common.Communication.Response;

namespace Client.GuiController
{
	public class RadSaArtiklimaGuiController
	{
		BindingList<Artikal> artikli = new BindingList<Artikal>();

		private UCRadSaArtiklima uCRadSaArtiklima;
		private FrmMain frmMain;
		private static RadSaArtiklimaGuiController instance;
		public static RadSaArtiklimaGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RadSaArtiklimaGuiController();
				}
				return instance;
			}
		}
		private RadSaArtiklimaGuiController()
		{
		}

		internal void PopuniFormu(UCRadSaArtiklima uCRadSaArtiklima, FrmMain frmMain)
		{
			this.uCRadSaArtiklima = uCRadSaArtiklima;
			this.frmMain = frmMain;
			artikli = VratiArtikle();
			uCRadSaArtiklima.DgvArtikli.AutoGenerateColumns = false;
			uCRadSaArtiklima.DgvArtikli.DataSource = artikli;
			uCRadSaArtiklima.DgvArtikli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			uCRadSaArtiklima.CmbPretragaPoTipu.DataSource = VratiTipove();
			uCRadSaArtiklima.CmbPretragaPoTipu.SelectedIndex = -1;
			uCRadSaArtiklima.TbPretraga.TextChanged += tbPretraga_TextChanged;
			uCRadSaArtiklima.CmbPretragaPoTipu.SelectedIndexChanged += cmbPretragaPoTipu_SelectedIndexChanged;
			uCRadSaArtiklima.BtnDetalji.Click += btnDetalji_Click;
			uCRadSaArtiklima.BtnExport.Click += btnExport_Click;

		}

		private void btnExport_Click(object? sender, EventArgs e)
		{
			if (artikli == null || artikli.Count == 0)
			{
				MessageBox.Show("Nema artikala za export.");
				return;
			}

			var options = new JsonSerializerOptions { WriteIndented = true };
			string json = JsonSerializer.Serialize(artikli, options);

			File.WriteAllText(@"..\..\..\..\Artikli.json", json);
			MessageBox.Show("Artikli su uspesno eksportovani u Artikli.json");

		}

		private BindingList<Artikal> VratiArtikle()
		{
			Response respone=Communication.Instance.VratiArtikle();
			if(respone.ExceptionMessage!=null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju artikala: " + respone.ExceptionMessage);
				return null;
			}
			return (BindingList<Artikal>)respone.Result;
		}

		private object? VratiTipove()
		{
			Response response = Communication.Instance.VratiTipove();
            if (response.ExceptionMessage!=null)
            {
				MessageBox.Show("Greska pri ucitavanju tipova proizvoda: "+response.ExceptionMessage);
				return null;
			}
			return response.Result;
		}

		private void btnDetalji_Click(object? sender, EventArgs e)
		{
			if (uCRadSaArtiklima.DgvArtikli.SelectedRows.Count > 0)
			{
				Artikal a = uCRadSaArtiklima.DgvArtikli.SelectedRows[0].DataBoundItem as Artikal;
				MainCoordinator.Instance.ShowDodajArtikalForm(frmMain, a.Id);
				
			}
			else
			{
				MessageBox.Show("Niste odabrali red");
			}
		}

		private void cmbPretragaPoTipu_SelectedIndexChanged(object? sender, EventArgs e)
		{
			if (uCRadSaArtiklima.CmbPretragaPoTipu.SelectedIndex < 0)
			{
				uCRadSaArtiklima.DgvArtikli.DataSource = artikli;
				return;
			}
			Tip tip = (Tip)uCRadSaArtiklima.CmbPretragaPoTipu.SelectedItem;
			uCRadSaArtiklima.DgvArtikli.DataSource = artikli.Where(a => a.Tip == tip).ToList();
		}

		private void tbPretraga_TextChanged(object? sender, EventArgs e)
		{
			string filter = uCRadSaArtiklima.TbPretraga.Text.Trim();
			var filteredArtikli = artikli.Where(a => a.Naziv.Contains(filter) || a.Naziv.Contains(filter)).ToList();
			uCRadSaArtiklima.DgvArtikli.DataSource = new BindingList<Artikal>(filteredArtikli);
		}

		internal void OsveziArtikal(Artikal a)
		{
			var stari = artikli.FirstOrDefault(x => x.Id == a.Id);
			if (stari != null)
			{
				stari.Naziv = a.Naziv;
				stari.Cena = a.Cena;
				stari.Tip = a.Tip;
				uCRadSaArtiklima.DgvArtikli.Refresh();
			}
		}
	}
}
