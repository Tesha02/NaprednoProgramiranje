using Client.UserControllers;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
	public class MainCoordinator
	{
		private static MainCoordinator instance;
		public static MainCoordinator Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MainCoordinator();
				}
				return instance;
			}
		}

		private MainCoordinator()
		{
			
		}

		private FrmMain frmMain;

		internal void ShowFrmMain(Radnik r)
		{
			frmMain = new FrmMain(r);
			frmMain.AutoSize = true;
			frmMain.ShowDialog();
		}

		internal void ShowAddPersonPanel()
		{
			
		}

		internal void ShowDodajKupcaForm(FrmMain frmMain, long i=0)
		{
			if (i != 0)
			{
				frmMain.SetPanel1(new UCDodajKupca(i));
				return;
			}
			frmMain.SetPanel(new UCDodajKupca());
		}

		internal void ShowDodajArtikalForm(FrmMain frmMain, long i = 0)
		{
			if (i != 0)
			{
				frmMain.SetPanel1(new UCDodajArtikal(i));
				return;
			}

			frmMain.SetPanel(new UCDodajArtikal());
		}

		internal void ShowDodajMestoForm(FrmMain frmMain)
		{
			frmMain.SetPanel(new UCDodajMesto());
		}

		internal void ShowDodajStrSpremuForm(FrmMain frmMain,long i=0)
		{
			if (i != 0)
			{
				frmMain.SetPanel1(new UCDodajStrSpremu(i));
				return;
			}
			frmMain.SetPanel(new UCDodajStrSpremu());
		}

		internal void ShowDodajPorudzbenicuForm(FrmMain frmMain,long i=0)
		{
			if (i != 0)
			{
				frmMain.SetPanel1(new UCDodajPorudzbenicu(i));
				return;
			}
			frmMain.SetPanel(new UCDodajPorudzbenicu());
		}

		internal void ShowRadSaArtiklimaForm(FrmMain frmMain)
		{
			frmMain.SetPanel(new UCRadSaArtiklima(frmMain));
		}

		internal void ShowRadSaKupcimaForm(FrmMain frmMain)
		{
			frmMain.SetPanel(new UCRadSaKupcima(frmMain));
		}

		internal void ArtikalAzuriran(Artikal artikal)
		{
			RadSaArtiklimaGuiController.Instance.OsveziArtikal(artikal);
		}

		internal void KupacAzuriran(Kupac k)
		{
			RadSaKupcimaGuiController.Instance.OsveziKupca(k);
		}

		internal void ShowRadSaMestimaForm(FrmMain frmMain)
		{
			frmMain.SetPanel(new UCRadSaMestima(frmMain));
		}

		internal void ShowRadSaStrSpremomForm(FrmMain frmMain)
		{
			frmMain.SetPanel(new UCRadSaStrSpremom(frmMain));
		}

		internal void StrSpremaAzurirana(StrSprema ss)
		{
			RadSaStrSpremomGuiController.Instance.OsveziStrSpremu(ss);
		}

		internal void ShowRadSaPorudzbenicamaForm(FrmMain frmMain)
		{
			frmMain.SetPanel(new UCRadSaPorudzbenicama(frmMain));
		}

		internal void PorudzbenicaAzurirana(Porudzbenica p)
		{
			RadSaPorudzbenicamaGuiController.Instance.OsveziPorudzbenicu(p);
		}
	}
}
