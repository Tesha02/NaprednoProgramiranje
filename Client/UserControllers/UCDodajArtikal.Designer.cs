namespace Client.UserControllers
{
	partial class UCDodajArtikal
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			tbNaziv = new TextBox();
			tbCena = new TextBox();
			btnSacuvaj = new Button();
			cmbTip = new ComboBox();
			btnAzuriraj = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(84, 51);
			label1.Name = "label1";
			label1.Size = new Size(46, 20);
			label1.TabIndex = 0;
			label1.Text = "Naziv";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(84, 162);
			label2.Name = "label2";
			label2.Size = new Size(42, 20);
			label2.TabIndex = 1;
			label2.Text = "Cena";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(84, 280);
			label3.Name = "label3";
			label3.Size = new Size(30, 20);
			label3.TabIndex = 2;
			label3.Text = "Tip";
			// 
			// tbNaziv
			// 
			tbNaziv.Location = new Point(84, 97);
			tbNaziv.Name = "tbNaziv";
			tbNaziv.Size = new Size(353, 27);
			tbNaziv.TabIndex = 3;
			// 
			// tbCena
			// 
			tbCena.Location = new Point(84, 214);
			tbCena.Name = "tbCena";
			tbCena.Size = new Size(353, 27);
			tbCena.TabIndex = 5;
			// 
			// btnSacuvaj
			// 
			btnSacuvaj.Location = new Point(84, 488);
			btnSacuvaj.Name = "btnSacuvaj";
			btnSacuvaj.Size = new Size(94, 29);
			btnSacuvaj.TabIndex = 7;
			btnSacuvaj.Text = "Sacuvaj";
			btnSacuvaj.UseVisualStyleBackColor = true;
			// 
			// cmbTip
			// 
			cmbTip.FormattingEnabled = true;
			cmbTip.Location = new Point(84, 335);
			cmbTip.Name = "cmbTip";
			cmbTip.Size = new Size(353, 28);
			cmbTip.TabIndex = 9;
			// 
			// btnAzuriraj
			// 
			btnAzuriraj.Location = new Point(343, 488);
			btnAzuriraj.Name = "btnAzuriraj";
			btnAzuriraj.Size = new Size(94, 29);
			btnAzuriraj.TabIndex = 10;
			btnAzuriraj.Text = "Azuriraj";
			btnAzuriraj.UseVisualStyleBackColor = true;
			// 
			// UCDodajArtikal
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnAzuriraj);
			Controls.Add(cmbTip);
			Controls.Add(btnSacuvaj);
			Controls.Add(tbCena);
			Controls.Add(tbNaziv);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UCDodajArtikal";
			Size = new Size(526, 550);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox tbNaziv;
		private TextBox tbCena;
		private Button btnSacuvaj;
		private ComboBox cmbTip;
		private Button btnAzuriraj;

		public Label Label1 { get => label1; set => label1 = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public Label Label3 { get => label3; set => label3 = value; }
		public TextBox TbNaziv { get => tbNaziv; set => tbNaziv = value; }
		public TextBox TbCena { get => tbCena; set => tbCena = value; }
		public Button BtnSacuvaj { get => btnSacuvaj; set => btnSacuvaj = value; }
		public ComboBox CmbTip { get => cmbTip; set => cmbTip = value; }
		public Button BtnAzuriraj { get => btnAzuriraj; set => btnAzuriraj = value; }
	}
}
