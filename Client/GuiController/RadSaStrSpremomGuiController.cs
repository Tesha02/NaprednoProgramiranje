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
	public class RadSaStrSpremomGuiController
	{
		FrmMain frmMain;
		BindingList<StrSprema> strSpreme;
		private UCRadSaStrSpremom uCRadSaStrSpremom;
		private static RadSaStrSpremomGuiController instance;
		public static RadSaStrSpremomGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new RadSaStrSpremomGuiController();
				}
				return instance;
			}
		}
		private RadSaStrSpremomGuiController()
		{
		}

		internal void PopuniFormu(UCRadSaStrSpremom uCRadSaStrSpremom, FrmMain frmMain)
		{
			this.uCRadSaStrSpremom = uCRadSaStrSpremom;
			this.frmMain = frmMain;
			uCRadSaStrSpremom.DgvStrSprema.AutoGenerateColumns = false;
			uCRadSaStrSpremom.DgvStrSprema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			strSpreme = vratiStrSpreme();
			uCRadSaStrSpremom.DgvStrSprema.DataSource = strSpreme;
			uCRadSaStrSpremom.TbPretraga.TextChanged += tbPretrazi_TextChanged;
			uCRadSaStrSpremom.BtnObrisi.Click += btnObrisi_Click;
			uCRadSaStrSpremom.BtnIzmeni.Click += btnIzmeni_Click;
		}

		private BindingList<StrSprema> vratiStrSpreme()
		{
			Response response = Communication.Instance.VratiStrSpreme();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju mesta: " + response.ExceptionMessage);
				return null;
			}

			return (BindingList<StrSprema>)response.Result;
		}

		private void btnIzmeni_Click(object? sender, EventArgs e)
		{
			if (uCRadSaStrSpremom.DgvStrSprema.SelectedRows.Count == 1)
			{
				StrSprema sprema = uCRadSaStrSpremom.DgvStrSprema.SelectedRows[0].DataBoundItem as StrSprema;
				MainCoordinator.Instance.ShowDodajStrSpremuForm(frmMain,sprema.Id);
			}
			else
			{
				MessageBox.Show("Niste odabrali red!");
			}
		}

		private void btnObrisi_Click(object? sender, EventArgs e)
		{
			if (uCRadSaStrSpremom.DgvStrSprema.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow selectedRow in uCRadSaStrSpremom.DgvStrSprema.SelectedRows)
				{
					StrSprema sprema = selectedRow.DataBoundItem as StrSprema;
					Response r = Communication.Instance.ObrisiStrSpremu(sprema);
					if (r.ExceptionMessage != null)
					{
						if (r.ExceptionMessage.Contains("REFERENCE constraint"))
						{
							MessageBox.Show("Ne mozete obrisati mesto koje je vezano za kupca ili radnika!");
							continue;
						}
						else
						{
							MessageBox.Show("Greska pri brisanju strucne spreme: " + r.ExceptionMessage);
						}

					}
					else
					{
						MessageBox.Show("Uspesno ste obrisali strucnu spremu!");
					}
				}
				uCRadSaStrSpremom.DgvStrSprema.DataSource = vratiStrSpreme();
			}
			else
			{
				MessageBox.Show("Izaberite barem jedan red");
			}
		}

		private void tbPretrazi_TextChanged(object? sender, EventArgs e)
		{
			string filter = uCRadSaStrSpremom.TbPretraga.Text.Trim();
			var filteredSpreme = strSpreme.Where(s => s.Naziv.Contains(filter) || s.Opis.Contains(filter)).ToList();

			uCRadSaStrSpremom.DgvStrSprema.DataSource = new List<StrSprema>(filteredSpreme);
		}

		internal void OsveziStrSpremu(StrSprema ss)
		{
			var stari = strSpreme.FirstOrDefault(x => x.Id == ss.Id);
			if (stari != null)
			{
				stari.Naziv=ss.Naziv;
				stari.Opis = ss.Opis;
				uCRadSaStrSpremom.DgvStrSprema.Refresh();
			}
		}
	}
}
