using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
	public class LoginGuiController
	{
		private FrmLogin frmLogin;
		private bool isPasswordVisible = false;
		private static LoginGuiController instance;
		public static LoginGuiController Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LoginGuiController();
				}
				return instance;
			}
		}
		private LoginGuiController()
		{
		}

		//private void pbShowPass_Click(object sender, EventArgs e)
		//{
		//	if (isPasswordVisible)
		//	{
		//		frmLogin.TbLozinka.UseSystemPasswordChar = true;
		//		frmLogin.PbShowPass.Image = Properties.Resources.icons8_closed_eye_50;
		//		isPasswordVisible = false;
		//	}
		//	else
		//	{
		//		frmLogin.TbLozinka.UseSystemPasswordChar = false;
		//		frmLogin.PbShowPass.Image = Properties.Resources.icons8_eye_50;
		//		isPasswordVisible = true;
		//	}
		//}

		internal void ShowFrmLogin()
		{
			try
			{
				Communication.Instance.Connect();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				frmLogin = new FrmLogin();
				frmLogin.AutoSize = true;
				Application.Run(frmLogin);
			}
			catch (SocketException)
			{
				MessageBox.Show("Nije moguce uspostaviti komunikaciju sa serverom!");
			}
		}

		public void Login(object sender, EventArgs e)
		{
			if (!Validacija(frmLogin))
			{
				MessageBox.Show("Molimo popunite sva polja.");
				return;
			}

			Radnik r = new Radnik
			{
				KorisnickoIme = frmLogin.TbKorisnickoIme.Text,
				Lozinka = frmLogin.TbLozinka.Text
			};
			Response response = Communication.Instance.Login(r);

			if (response.ExceptionMessage == null)
			{
				frmLogin.Visible = false;
				MainCoordinator.Instance.ShowFrmMain((Radnik)response.Result);
			}
			else
			{
				MessageBox.Show(">>>" + response.ExceptionMessage);
			}
		}

		private bool Validacija(FrmLogin frmLogin)
		{
			bool isValid = true;
			if (string.IsNullOrEmpty(frmLogin.TbKorisnickoIme.Text))
			{
				frmLogin.TbKorisnickoIme.BackColor = Color.Salmon;
				isValid = false;
			}
			if (string.IsNullOrEmpty(frmLogin.TbLozinka.Text))
			{
				frmLogin.TbLozinka.BackColor = Color.Salmon;
				isValid = false;
			}
			return isValid;
		}


	}
}
