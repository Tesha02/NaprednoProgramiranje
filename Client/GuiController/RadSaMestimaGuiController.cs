using Client.UserControllers;
using Common.Communication;
using Common.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
	public class RadSaMestimaGuiController
	{
		FrmMain frmMain;
		private UCRadSaMestima uCRadSaMestima;
		private static RadSaMestimaGuiController instance;
		BindingList<Mesto> mesta = new BindingList<Mesto>();
		public static RadSaMestimaGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RadSaMestimaGuiController();
				}
				return instance;
			}
		}
		private RadSaMestimaGuiController()
		{

		}

		internal void PopuniFormu(UCRadSaMestima uCRadSaMestima,FrmMain frmMain)
		{
			this.frmMain = frmMain;
			this.uCRadSaMestima = uCRadSaMestima;
			uCRadSaMestima.DgvMesta.AutoGenerateColumns = false;
			uCRadSaMestima.DgvMesta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			uCRadSaMestima.DgvMesta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			mesta = vratiMesta();
			uCRadSaMestima.DgvMesta.DataSource = mesta;
			uCRadSaMestima.TbPretrazi.TextChanged += tbPretrazi_TextChanged;
			uCRadSaMestima.BtnObrisi.Click += btnObrisi_Click;
		}

		

		private void btnObrisi_Click(object? sender, EventArgs e)
		{
			if (uCRadSaMestima.DgvMesta.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow selectedRow in uCRadSaMestima.DgvMesta.SelectedRows)
				{
					Mesto m = uCRadSaMestima.DgvMesta.SelectedRows[0].DataBoundItem as Mesto;
					Response r = Communication.Instance.ObrisiMesto(m);
					if (r.ExceptionMessage != null)
					{
						if (r.ExceptionMessage.Contains("REFERENCE constraint"))
						{
							MessageBox.Show("Ne mozete obrisati mesto koje je vezano za kupca ili radnika!");
							continue;
						}
						else
						{
							MessageBox.Show("Greska pri brisanju mesta: " + r.ExceptionMessage);
						}

					}
					else
					{
						MessageBox.Show("Uspesno ste obrisali mesto!");
					}
				}
				uCRadSaMestima.DgvMesta.DataSource = vratiMesta();
			}
			else
			{
				MessageBox.Show("Niste selektovali nijedno mesto");
			}
		}

		private void tbPretrazi_TextChanged(object? sender, EventArgs e)
		{
			string filter = uCRadSaMestima.TbPretrazi.Text.Trim();
			var filteredMesta = mesta.Where(m => m.Naziv.Contains(filter) || m.PostanskiBroj.Contains(filter)).ToList();

			uCRadSaMestima.DgvMesta.DataSource = new BindingList<Mesto>(filteredMesta);
		}

		private BindingList<Mesto> vratiMesta()
		{
			Response response = Communication.Instance.VratiMesta();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju mesta: " + response.ExceptionMessage);
				return null;
			}

			return (BindingList<Mesto>)response.Result;
		}
	}
}
