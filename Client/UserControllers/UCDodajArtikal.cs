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

namespace Client.UserControllers
{
	public partial class UCDodajArtikal : UserControl
	{
		public UCDodajArtikal()
		{
			InitializeComponent();
			DodajArtikalGuiController.Instance.PopuniFormu(this);

		}

		public UCDodajArtikal(long id)
		{
			InitializeComponent();
			DodajArtikalGuiController.Instance.PopuniFormu(this, id);
		}

	}
}
