using Client.GuiController;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public partial class FrmMain : Form
	{
		private MainCoordinator mainCoordinator;
		public Radnik radnik;

		public FrmMain(Radnik r)
		{
			InitializeComponent();
			radnik = r;
		}

		private void dodajKupcaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowDodajKupcaForm(this);
		}
		public void SetPanel(UserControl userControl)
		{
			pnlMain.Controls.Clear();
			pnlMain.BackgroundImage = null;
			pnlMain.Controls.Add(userControl);
			userControl.Dock = DockStyle.Fill;
			pnlAzuriranje.Controls.Clear();
		}

		public void SetPanel1(UserControl userControl)
		{
			pnlAzuriranje.Controls.Clear();
			pnlAzuriranje.BackgroundImage = null;
			pnlAzuriranje.Controls.Add(userControl);
			userControl.Dock = DockStyle.Fill;
		}

		private void dodajArtikalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowDodajArtikalForm(this);
		}

		private void dodajMestoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowDodajMestoForm(this);
		}

		private void dodajStrucnuSpremuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowDodajStrSpremuForm(this);
		}

		private void dodajPorudzbenicuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowDodajPorudzbenicuForm(this);
		}

		private void radSaArtiklimaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowRadSaArtiklimaForm(this);

		}

		private void radSaKupcimaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowRadSaKupcimaForm(this);

		}

		private void radSaMestimaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowRadSaMestimaForm(this);

		}

		private void radSaStrucnomSpremomToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowRadSaStrSpremomForm(this);

		}

		private void radSaPorudzbenicamaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainCoordinator.Instance.ShowRadSaPorudzbenicamaForm(this);

		}

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
