namespace Server
{
	public partial class Form1 : Form
	{
		private Server server;

		public Form1()
		{
			InitializeComponent();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			server = new Server();
			btnStart.Enabled = false;
			btnStop.Enabled = true;
			server.Start();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			btnStart.Enabled = true;
			btnStop.Enabled = false;
			server.Stop();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
