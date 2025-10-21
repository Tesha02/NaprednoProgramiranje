using Client.GuiController;
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
	public partial class UCDodajKupca : UserControl
	{
		public UCDodajKupca()
		{
			InitializeComponent();
			DodajKupcaGuiController.Instance.PopuniFormu(this);
			
		}

		public UCDodajKupca(long i)
		{
			InitializeComponent();
			DodajKupcaGuiController.Instance.PopuniFormu(this,i);
			
		}

		
	}
}
