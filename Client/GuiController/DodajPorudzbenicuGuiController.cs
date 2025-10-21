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

namespace Client.GuiController
{
	public class DodajPorudzbenicuGuiController
	{
		private UCDodajPorudzbenicu uCDodajPorudzbenicu;
		private Radnik radnik;
		private Porudzbenica porudzbenicaZaIzmenu;

		private static DodajPorudzbenicuGuiController instance;
		public static DodajPorudzbenicuGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DodajPorudzbenicuGuiController();
				}
				return instance;
			}
		}
		private DodajPorudzbenicuGuiController()
		{
		}

		internal void DodajPorudzbenicu()
		{
			
		}

		internal BindingList<Kupac> UcitajKupce()
		{
			Response response = Communication.Instance.VratiKupce();
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju kupaca: " + response.ExceptionMessage);
				return null;
			}
			return (BindingList<Kupac>)response.Result;
		}

		internal BindingList<Artikal> UcitajArtikle()
		{
			Response response = Communication.Instance.VratiArtikle();
			if(response.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske pri ucitavanju artikala: " + response.ExceptionMessage);
				return null;
			}
			return (BindingList<Artikal>)response.Result;
		}

		internal void PopuniFormu(UCDodajPorudzbenicu uCDodajPorudzbenicu)
		{
			this.uCDodajPorudzbenicu = uCDodajPorudzbenicu;
			radnik = Communication.Instance.Radnik;
			uCDodajPorudzbenicu.BtnAzuriraj.Visible = false;
			uCDodajPorudzbenicu.BtnSacuvaj.Visible = true;
			uCDodajPorudzbenicu.CmbKupac.DataSource = UcitajKupce();
			uCDodajPorudzbenicu.CmbArtikal.DataSource = UcitajArtikle();
			uCDodajPorudzbenicu.LblRadnik.Text = radnik.Ime + " " + radnik.Prezime;
			uCDodajPorudzbenicu.TbUkupnaCena.Enabled = false;
			uCDodajPorudzbenicu.TbIznosArtikla.Enabled = false;
			uCDodajPorudzbenicu.DtpDatumOd.Value = DateTime.Now;
			uCDodajPorudzbenicu.DtpDatumOd.Enabled = false;

			uCDodajPorudzbenicu.CmbKupac.SelectedIndex = -1;
			uCDodajPorudzbenicu.CmbArtikal.SelectedIndex = -1;
			//dgvStavke.DataSource = stavke;
			uCDodajPorudzbenicu.DgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			uCDodajPorudzbenicu.TbUkupnaVrednost.Enabled = false;
			uCDodajPorudzbenicu.CmbArtikal.DropDownStyle = ComboBoxStyle.DropDownList;
			uCDodajPorudzbenicu.CmbKupac.DropDownStyle = ComboBoxStyle.DropDownList;

			uCDodajPorudzbenicu.CmbArtikal.SelectedIndexChanged += CmbArtikal_SelectedIndexChanged;
			uCDodajPorudzbenicu.TbKolicina.TextChanged += TbKolicina_TextChanged;
			uCDodajPorudzbenicu.TbIznosArtikla.TextChanged += tbIznosArtikla_TextChanged;
			uCDodajPorudzbenicu.BtnDodajStavku.Click += btnDodajStavku_Click;
			uCDodajPorudzbenicu.BtnObrisiStavku.Click += btnObrisiStavku_Click;
			uCDodajPorudzbenicu.BtnSacuvaj.Click += btnSacuvaj_Click;


		}

		private void btnDodajStavku_Click(object sender, EventArgs e)
		{
			if (!Validacija())
			{
				MessageBox.Show("Pogresan unos!");
				return;
			}

			Artikal a = (Artikal)uCDodajPorudzbenicu.CmbArtikal.SelectedItem;
			long kolicina = long.Parse(uCDodajPorudzbenicu.TbKolicina.Text);
			float cenaStavke = float.Parse(uCDodajPorudzbenicu.TbIznosArtikla.Text);
			float ukupnaCenaStavke = cenaStavke * kolicina;
			//StavkaPorudzbenice sp = new StavkaPorudzbenice(kolicina, cenaStavke, ukupnaCenaStavke, a);
			//k.ubaciStavku(sp);
			bool flag = true;
			foreach (DataGridViewRow row in uCDodajPorudzbenicu.DgvStavke.Rows)
			{
				if (row.Cells["Artikal"].Value != null && row.Cells["Artikal"].Value.ToString().Equals(a.ToString()))
				{
					flag = false;
					row.Cells["Kolicina"].Value = (long)row.Cells["Kolicina"].Value + kolicina;
					row.Cells["UkupnaCena"].Value = Convert.ToDouble(row.Cells["UkupnaCena"].Value) + kolicina * cenaStavke;
					break;
				}
			}
			if (flag)
			{
				uCDodajPorudzbenicu.DgvStavke.Rows.Add(a, cenaStavke, kolicina, ukupnaCenaStavke);
			}
			//dgvStavke.DataSource = k.vratiStavkeIzBaze();
			MessageBox.Show("Uspesno ste ubacili proizvod!");

			float ukupnaVr = 0;
			foreach (DataGridViewRow row in uCDodajPorudzbenicu.DgvStavke.Rows)
			{
				ukupnaVr += Convert.ToSingle(row.Cells["UkupnaCena"].Value);
			}
			uCDodajPorudzbenicu.TbUkupnaVrednost.Text = ukupnaVr + "";

			uCDodajPorudzbenicu.CmbArtikal.SelectedIndex = -1;
			uCDodajPorudzbenicu.TbKolicina.Text = "";
		}

		private void btnObrisiStavku_Click(object sender, EventArgs e)
		{
			if (uCDodajPorudzbenicu.DgvStavke.SelectedRows.Count > 0)
			{
				foreach (DataGridViewRow selectedRow in uCDodajPorudzbenicu.DgvStavke.SelectedRows)
				{
					uCDodajPorudzbenicu.DgvStavke.Rows.Remove(selectedRow);
				}

				float ukupnaVr = 0;
				foreach (DataGridViewRow row in uCDodajPorudzbenicu.DgvStavke.Rows)
				{
					ukupnaVr += Convert.ToSingle(row.Cells["UkupnaCena"].Value);
				}
				uCDodajPorudzbenicu.TbUkupnaVrednost.Text = ukupnaVr + "";
			}
			else
			{
				MessageBox.Show("Morate selektovati stavku!");
			}
		}

		private bool Validacija()
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(uCDodajPorudzbenicu.TbIznosArtikla.Text))
			{
				uCDodajPorudzbenicu.TbIznosArtikla.BackColor = Color.Salmon;
				return false;
			}
			int broj;
			if (!int.TryParse(uCDodajPorudzbenicu.TbKolicina.Text, out broj))
			{
				uCDodajPorudzbenicu.TbKolicina.BackColor = Color.Salmon;
				return false;
			}
			if (string.IsNullOrEmpty(uCDodajPorudzbenicu.CmbArtikal.Text))
			{
				uCDodajPorudzbenicu.CmbArtikal.BackColor = Color.Salmon;
				return false;
			}

			uCDodajPorudzbenicu.TbKolicina.BackColor = Color.White;
			uCDodajPorudzbenicu.CmbArtikal.BackColor = Color.White;
			uCDodajPorudzbenicu.TbIznosArtikla.BackColor = Color.White;

			return true;
		}

		private bool Validacija1()
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(uCDodajPorudzbenicu.CmbKupac.Text))
			{
				uCDodajPorudzbenicu.CmbKupac.BackColor = Color.Salmon;
				return false;
			}

			if (uCDodajPorudzbenicu.DgvStavke.Rows.Count == 0)
			{
				uCDodajPorudzbenicu.DgvStavke.RowsDefaultCellStyle.BackColor = Color.Salmon;
				//dgvStavke.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
				return false;
			}

			int broj;
			if (!int.TryParse(uCDodajPorudzbenicu.TbUkupnaVrednost.Text, out broj))
			{
				uCDodajPorudzbenicu.TbUkupnaVrednost.BackColor = Color.Salmon;
				return false;
			}

			uCDodajPorudzbenicu.CmbKupac.BackColor = Color.White;
			uCDodajPorudzbenicu.DgvStavke.BackgroundColor = Color.White;

			return true;
		}

		internal void CmbArtikal_SelectedIndexChanged(object? sender, EventArgs e)
		{
			if (uCDodajPorudzbenicu.CmbArtikal.SelectedIndex < 0)
			{
				uCDodajPorudzbenicu.TbIznosArtikla.Text = 0 + "";
				return;
			}
			uCDodajPorudzbenicu.TbIznosArtikla.Text = ((Artikal)uCDodajPorudzbenicu.CmbArtikal.SelectedItem).Cena.ToString();
			uCDodajPorudzbenicu.TbKolicina.Clear();
			uCDodajPorudzbenicu.TbUkupnaCena.Clear();
		}

		internal void TbKolicina_TextChanged(object? sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(uCDodajPorudzbenicu.TbKolicina.Text))
			{
				return;
			}
			long br = long.Parse(uCDodajPorudzbenicu.TbKolicina.Text) * long.Parse(uCDodajPorudzbenicu.TbIznosArtikla.Text);
			uCDodajPorudzbenicu.TbUkupnaCena.Text = br + "";
		}

		internal void tbIznosArtikla_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(uCDodajPorudzbenicu.TbKolicina.Text))
			{
				return;
			}
			long br = long.Parse(uCDodajPorudzbenicu.TbKolicina.Text) * long.Parse(uCDodajPorudzbenicu.TbIznosArtikla.Text);
			uCDodajPorudzbenicu.TbUkupnaCena.Text = br + "";
		}

		internal void PopuniFormu(UCDodajPorudzbenicu uCDodajPorudzbenicu, long i)
		{
			this.uCDodajPorudzbenicu = uCDodajPorudzbenicu;
			radnik = Communication.Instance.Radnik;
			this.porudzbenicaZaIzmenu = new Porudzbenica
			{
				Id = i,
				StavkePorudzbenica=new List<StavkaPorudzbenice>()
			};
			porudzbenicaZaIzmenu = vratiPorudzbenicu(this.porudzbenicaZaIzmenu);
			uCDodajPorudzbenicu.CmbKupac.Text = porudzbenicaZaIzmenu.Kupac.ToString();
			uCDodajPorudzbenicu.CmbKupac.Enabled=false;

			uCDodajPorudzbenicu.BtnSacuvaj.Visible = false;
			uCDodajPorudzbenicu.BtnAzuriraj.Visible = true;

			uCDodajPorudzbenicu.DtpDatumDo.Value = porudzbenicaZaIzmenu.DatumDo.ToDateTime(TimeOnly.MinValue);
			uCDodajPorudzbenicu.DtpDatumOd.Value = porudzbenicaZaIzmenu.DatumOd.ToDateTime(TimeOnly.MinValue);
			uCDodajPorudzbenicu.DtpDatumOd.Enabled = false;

			uCDodajPorudzbenicu.CmbArtikal.DataSource = UcitajArtikle();
			uCDodajPorudzbenicu.CmbArtikal.SelectedIndex = -1;
			uCDodajPorudzbenicu.LblRadnik.Text = radnik.Ime + " " + radnik.Prezime;

			uCDodajPorudzbenicu.TbUkupnaVrednost.Text=porudzbenicaZaIzmenu.UkupnaVr + "";
			uCDodajPorudzbenicu.TbUkupnaCena.Enabled = false;
			uCDodajPorudzbenicu.TbIznosArtikla.Enabled = false;

			//dgvStavke.DataSource = stavke;
			uCDodajPorudzbenicu.DgvStavke.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			uCDodajPorudzbenicu.TbUkupnaVrednost.Enabled = false;

			uCDodajPorudzbenicu.CmbArtikal.SelectedIndexChanged += CmbArtikal_SelectedIndexChanged;
			uCDodajPorudzbenicu.TbKolicina.TextChanged += TbKolicina_TextChanged;
			uCDodajPorudzbenicu.TbIznosArtikla.TextChanged += tbIznosArtikla_TextChanged;
			uCDodajPorudzbenicu.BtnDodajStavku.Click += btnDodajStavku_Click;
			uCDodajPorudzbenicu.BtnObrisiStavku.Click += btnObrisiStavku_Click;
			uCDodajPorudzbenicu.BtnAzuriraj.Click += btnAzuriraj_Click;
			
			foreach (StavkaPorudzbenice sp in porudzbenicaZaIzmenu.StavkePorudzbenica)
			{
				uCDodajPorudzbenicu.DgvStavke.Rows.Add(sp.Artikal, sp.CenaStavke, sp.Kolicina, sp.UkupnaCena);
			}
		}

		private Porudzbenica vratiPorudzbenicu(Porudzbenica porudzbenicaZaIzmenu)
		{
			Response response = Communication.Instance.VratiPorudzbenicu(porudzbenicaZaIzmenu);
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Greska prilikom ucitavanja kupca: " + response.ExceptionMessage);
				return null;
			}
			return (Porudzbenica)response.Result;
		}

		private void btnAzuriraj_Click(object sender, EventArgs e)
		{
			if (!Validacija1())
			{
				MessageBox.Show("Nisi uneo sve podatke");
				return;
			}
			porudzbenicaZaIzmenu.StavkePorudzbenica=new List<StavkaPorudzbenice>();
	
			Artikal artikal = new Artikal();
			float cenaArtikla, ukupnaCena = 0;
			long kolicina = 0;
			foreach (DataGridViewRow row in uCDodajPorudzbenicu.DgvStavke.Rows)
			{
				if (row.Cells["Artikal"].Value == null)
					break;
				artikal = row.Cells["Artikal"].Value as Artikal;
				cenaArtikla = Convert.ToSingle(row.Cells[1].Value);
				kolicina = Convert.ToInt64(row.Cells[2].Value);
				ukupnaCena = Convert.ToSingle(row.Cells[3].Value);

				StavkaPorudzbenice sp = new StavkaPorudzbenice
				{
					Kolicina = kolicina,
					CenaStavke = cenaArtikla,
					UkupnaCena = ukupnaCena,
					Artikal = artikal,
					Porudzbenica = porudzbenicaZaIzmenu,
				};
				porudzbenicaZaIzmenu.StavkePorudzbenica.Add(sp);
			}
			porudzbenicaZaIzmenu.DatumDo = DateOnly.FromDateTime(uCDodajPorudzbenicu.DtpDatumOd.Value.Date);
			porudzbenicaZaIzmenu.UkupnaVr= float.Parse(uCDodajPorudzbenicu.TbUkupnaVrednost.Text);
			Response resp = Communication.Instance.AzurirajPorudzbenicu(porudzbenicaZaIzmenu);
			if (resp.ExceptionMessage != null)
			{
				MessageBox.Show("Doslo je do greske: " + resp.ExceptionMessage);
				return;
			}
			else
			{
				uCDodajPorudzbenicu.DgvStavke.Rows.Clear();
				MessageBox.Show("Sistem je izmenio porudzbenicu");
			}
			MainCoordinator.Instance.PorudzbenicaAzurirana((Porudzbenica)resp.Result);


		}

		private void btnSacuvaj_Click(object sender, EventArgs e)
		{
			if (!Validacija1())
			{
				MessageBox.Show("Sistem ne moze da kreira porudzbenicu");
				return;
			}

			Kupac kupac = uCDodajPorudzbenicu.CmbKupac.SelectedItem as Kupac;
			DateOnly datumOd = DateOnly.FromDateTime(uCDodajPorudzbenicu.DtpDatumOd.Value.Date);
			DateOnly datumDo = DateOnly.FromDateTime(uCDodajPorudzbenicu.DtpDatumDo.Value);
			float ukupnaVr = float.Parse(uCDodajPorudzbenicu.TbUkupnaVrednost.Text);
			Porudzbenica p = new Porudzbenica
			{
				DatumDo = datumDo,
				DatumOd = datumOd,
				UkupnaVr = ukupnaVr,
				Radnik = radnik,
				Kupac = kupac,
				StavkePorudzbenica = new List<StavkaPorudzbenice>()
			};
			Artikal artikal = new Artikal();
			float cenaArtikla, ukupnaCena = 0;
			long kolicina = 0;
			foreach (DataGridViewRow row in uCDodajPorudzbenicu.DgvStavke.Rows)
			{
				if (row.Cells["Artikal"].Value == null)
					break;
				artikal = row.Cells["Artikal"].Value as Artikal;
				cenaArtikla = Convert.ToSingle(row.Cells[1].Value);
				kolicina = Convert.ToInt64(row.Cells[2].Value);
				ukupnaCena = Convert.ToSingle(row.Cells[3].Value);

				StavkaPorudzbenice sp = new StavkaPorudzbenice
				{
					Kolicina = kolicina,
					CenaStavke = cenaArtikla,
					UkupnaCena = ukupnaCena,
					Artikal = artikal,
					Porudzbenica = p
				};
				p.StavkePorudzbenica.Add(sp);
			}

			Response resp = Communication.Instance.DodajPorudzbenicu(p);
			if (resp.ExceptionMessage != null)
			{
				MessageBox.Show("Sistem ne moze da zapamti porudzbenicu!");
				return;
			}
			uCDodajPorudzbenicu.DgvStavke.Rows.Clear();
			p.Id = (long)resp.Result;
			if (p.Id > 0)
			{
				MessageBox.Show("Sistem je zapamtio porudzbenicu!");
			}
		}
	}
}
