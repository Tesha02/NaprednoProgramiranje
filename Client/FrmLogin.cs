using Client.GuiController;

namespace Client
{
	public partial class FrmLogin : Form
	{
		private LoginGuiController loginController;
		public FrmLogin()
		{
			InitializeComponent();
			btnUloguj.Click += LoginGuiController.Instance.Login;
		}

		private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
