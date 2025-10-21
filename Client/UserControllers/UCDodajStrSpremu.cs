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
	public partial class UCDodajStrSpremu : UserControl
	{
		public UCDodajStrSpremu()
		{
			InitializeComponent();
			DodajStrSpremuGuiController.Instance.PopuniFormu(this);
		}
		public UCDodajStrSpremu(long i)
		{
			InitializeComponent();
			DodajStrSpremuGuiController.Instance.PopuniFormu(this, i);
		}

	}
}
