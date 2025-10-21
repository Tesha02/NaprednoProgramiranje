namespace Client.UserControllers
{
	partial class UCDodajMesto
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnDodajMesto = new Button();
			tbNaziv = new TextBox();
			tbPtt = new TextBox();
			label2 = new Label();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnDodajMesto
			// 
			btnDodajMesto.Location = new Point(190, 288);
			btnDodajMesto.Name = "btnDodajMesto";
			btnDodajMesto.Size = new Size(113, 29);
			btnDodajMesto.TabIndex = 10;
			btnDodajMesto.Text = "Dodaj mesto";
			btnDodajMesto.UseVisualStyleBackColor = true;
			// 
			// tbNaziv
			// 
			tbNaziv.Location = new Point(177, 183);
			tbNaziv.Name = "tbNaziv";
			tbNaziv.Size = new Size(175, 27);
			tbNaziv.TabIndex = 9;
			// 
			// tbPtt
			// 
			tbPtt.Location = new Point(177, 99);
			tbPtt.Name = "tbPtt";
			tbPtt.Size = new Size(175, 27);
			tbPtt.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(104, 186);
			label2.Name = "label2";
			label2.Size = new Size(49, 20);
			label2.TabIndex = 7;
			label2.Text = "Naziv:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(104, 102);
			label1.Name = "label1";
			label1.Size = new Size(30, 20);
			label1.TabIndex = 6;
			label1.Text = "Ptt:";
			// 
			// UCDodajMesto
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnDodajMesto);
			Controls.Add(tbNaziv);
			Controls.Add(tbPtt);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UCDodajMesto";
			Size = new Size(457, 417);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btnDodajMesto;
		private TextBox tbNaziv;
		private TextBox tbPtt;
		private Label label2;
		private Label label1;

		public Button BtnDodajMesto { get => btnDodajMesto; set => btnDodajMesto = value; }
		public TextBox TbNaziv { get => tbNaziv; set => tbNaziv = value; }
		public TextBox TbPtt { get => tbPtt; set => tbPtt = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public Label Label1 { get => label1; set => label1 = value; }
	}
}
