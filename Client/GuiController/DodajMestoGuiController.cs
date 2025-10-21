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
	public class DodajMestoGuiController
	{
		private UCDodajMesto uCDodajMesto;
		private static DodajMestoGuiController instance;
		public static DodajMestoGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new DodajMestoGuiController();
				}
				return instance;
			}
		}
		private DodajMestoGuiController()
		{
		}

		internal void PopuniFormu(UCDodajMesto uCDodajMesto)
		{
			this.uCDodajMesto = uCDodajMesto;
			uCDodajMesto.BtnDodajMesto.Visible = true;
			uCDodajMesto.BtnDodajMesto.Click += DodajMesto;
		}

		private void DodajMesto(object? sender, EventArgs e)
		{
			if (!Validacija())
			{
				MessageBox.Show("Molimo popunite sva polja.");
				return;
			}

			Mesto m = new Mesto
			{
				Naziv = uCDodajMesto.TbNaziv.Text,
				PostanskiBroj = uCDodajMesto.TbPtt.Text
			};

			if (((BindingList<Mesto>)Communication.Instance.VratiMesta().Result).Any(mesto => mesto.PostanskiBroj.Equals(m.PostanskiBroj)))
			{
				MessageBox.Show("Sistem ne može da zapamti mesto! (Mesto sa istim PTT se već nalazi u bazi)");
				return;
			}

			Response response = Communication.Instance.UnesiMesto(m);
			if (response.ExceptionMessage != null)
			{
				MessageBox.Show("Sistem ne može da zapamti mesto: " + response.ExceptionMessage);
				return;
			}
			MessageBox.Show("Mesto je uspešno sačuvano!");
			uCDodajMesto.TbPtt.Text = "";
			uCDodajMesto.TbNaziv.Text = "";
		}

		private bool Validacija()
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(uCDodajMesto.TbNaziv.Text))
			{
				uCDodajMesto.TbNaziv.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(uCDodajMesto.TbPtt.Text))
			{
				uCDodajMesto.TbPtt.BackColor = Color.Salmon;
				isValid = false;
			}

			return isValid;
		}

		
	}
}
