namespace Client.UserControllers
{
	partial class UCDodajKupca
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
			cmbMesto = new ComboBox();
			label5 = new Label();
			btnAzuriraj = new Button();
			btnSacuvaj = new Button();
			tbKontaktTelefon = new TextBox();
			label4 = new Label();
			tbEmail = new TextBox();
			label3 = new Label();
			tbPrezime = new TextBox();
			label2 = new Label();
			tbIme = new TextBox();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnDodajMesto
			// 
			btnDodajMesto.Location = new Point(277, 306);
			btnDodajMesto.Name = "btnDodajMesto";
			btnDodajMesto.Size = new Size(38, 29);
			btnDodajMesto.TabIndex = 26;
			btnDodajMesto.Text = "+";
			btnDodajMesto.UseVisualStyleBackColor = true;
			// 
			// cmbMesto
			// 
			cmbMesto.FormattingEnabled = true;
			cmbMesto.Location = new Point(106, 307);
			cmbMesto.Name = "cmbMesto";
			cmbMesto.Size = new Size(151, 28);
			cmbMesto.TabIndex = 25;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(106, 263);
			label5.Name = "label5";
			label5.Size = new Size(53, 20);
			label5.TabIndex = 24;
			label5.Text = "Mesto:";
			// 
			// btnAzuriraj
			// 
			btnAzuriraj.Location = new Point(511, 503);
			btnAzuriraj.Name = "btnAzuriraj";
			btnAzuriraj.Size = new Size(94, 29);
			btnAzuriraj.TabIndex = 23;
			btnAzuriraj.Text = "Azuriraj";
			btnAzuriraj.UseVisualStyleBackColor = true;
			// 
			// btnSacuvaj
			// 
			btnSacuvaj.Location = new Point(107, 503);
			btnSacuvaj.Name = "btnSacuvaj";
			btnSacuvaj.Size = new Size(94, 29);
			btnSacuvaj.TabIndex = 22;
			btnSacuvaj.Text = "Sacuvaj";
			btnSacuvaj.UseVisualStyleBackColor = true;
			// 
			// tbKontaktTelefon
			// 
			tbKontaktTelefon.Location = new Point(411, 203);
			tbKontaktTelefon.Name = "tbKontaktTelefon";
			tbKontaktTelefon.Size = new Size(193, 27);
			tbKontaktTelefon.TabIndex = 21;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(411, 168);
			label4.Name = "label4";
			label4.Size = new Size(116, 20);
			label4.TabIndex = 20;
			label4.Text = "Kontakt Telefon:";
			// 
			// tbEmail
			// 
			tbEmail.Location = new Point(106, 203);
			tbEmail.Name = "tbEmail";
			tbEmail.Size = new Size(193, 27);
			tbEmail.TabIndex = 19;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(106, 168);
			label3.Name = "label3";
			label3.Size = new Size(49, 20);
			label3.TabIndex = 18;
			label3.Text = "Email:";
			// 
			// tbPrezime
			// 
			tbPrezime.Location = new Point(411, 99);
			tbPrezime.Name = "tbPrezime";
			tbPrezime.Size = new Size(193, 27);
			tbPrezime.TabIndex = 17;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(411, 61);
			label2.Name = "label2";
			label2.Size = new Size(65, 20);
			label2.TabIndex = 16;
			label2.Text = "Prezime:";
			// 
			// tbIme
			// 
			tbIme.Location = new Point(106, 99);
			tbIme.Name = "tbIme";
			tbIme.Size = new Size(193, 27);
			tbIme.TabIndex = 15;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(106, 61);
			label1.Name = "label1";
			label1.Size = new Size(37, 20);
			label1.TabIndex = 14;
			label1.Text = "Ime:";
			// 
			// UCDodajKupca
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnDodajMesto);
			Controls.Add(cmbMesto);
			Controls.Add(label5);
			Controls.Add(btnAzuriraj);
			Controls.Add(btnSacuvaj);
			Controls.Add(tbKontaktTelefon);
			Controls.Add(label4);
			Controls.Add(tbEmail);
			Controls.Add(label3);
			Controls.Add(tbPrezime);
			Controls.Add(label2);
			Controls.Add(tbIme);
			Controls.Add(label1);
			Name = "UCDodajKupca";
			Size = new Size(726, 624);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnDodajMesto;
		private ComboBox cmbMesto;
		private Label label5;
		private Button btnAzuriraj;
		private Button btnSacuvaj;
		private TextBox tbKontaktTelefon;
		private Label label4;
		private TextBox tbEmail;
		private Label label3;
		private TextBox tbPrezime;
		private Label label2;
		private TextBox tbIme;
		private Label label1;

		public Button BtnDodajMesto { get => btnDodajMesto; set => btnDodajMesto = value; }
		public ComboBox CmbMesto { get => cmbMesto; set => cmbMesto = value; }
		public Label Label5 { get => label5; set => label5 = value; }
		public Button BtnAzuriraj { get => btnAzuriraj; set => btnAzuriraj = value; }
		public Button BtnSacuvaj { get => btnSacuvaj; set => btnSacuvaj = value; }
		public TextBox TbKontaktTelefon { get => tbKontaktTelefon; set => tbKontaktTelefon = value; }
		public Label Label4 { get => label4; set => label4 = value; }
		public TextBox TbEmail { get => tbEmail; set => tbEmail = value; }
		public Label Label3 { get => label3; set => label3 = value; }
		public TextBox TbPrezime { get => tbPrezime; set => tbPrezime = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public TextBox TbIme { get => tbIme; set => tbIme = value; }
		public Label Label1 { get => label1; set => label1 = value; }
	}
}
