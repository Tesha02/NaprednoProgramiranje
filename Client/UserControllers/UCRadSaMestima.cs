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
	public partial class UCRadSaMestima : UserControl
	{
		public UCRadSaMestima(FrmMain frmMain)
		{
			InitializeComponent();
			RadSaMestimaGuiController.Instance.PopuniFormu(this,frmMain);
		}
	}
}
