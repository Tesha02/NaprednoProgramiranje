namespace Client.UserControllers
{
	partial class UCDodajStrSpremu
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
			btnIzmeni = new Button();
			btnDodaj = new Button();
			tbOpis = new TextBox();
			tbNaziv = new TextBox();
			label2 = new Label();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnIzmeni
			// 
			btnIzmeni.Location = new Point(168, 250);
			btnIzmeni.Name = "btnIzmeni";
			btnIzmeni.Size = new Size(94, 29);
			btnIzmeni.TabIndex = 11;
			btnIzmeni.Text = "Izmeni";
			btnIzmeni.UseVisualStyleBackColor = true;
			// 
			// btnDodaj
			// 
			btnDodaj.Location = new Point(168, 250);
			btnDodaj.Name = "btnDodaj";
			btnDodaj.Size = new Size(94, 29);
			btnDodaj.TabIndex = 10;
			btnDodaj.Text = "Dodaj";
			btnDodaj.UseVisualStyleBackColor = true;
			// 
			// tbOpis
			// 
			tbOpis.Location = new Point(151, 160);
			tbOpis.Name = "tbOpis";
			tbOpis.Size = new Size(125, 27);
			tbOpis.TabIndex = 9;
			// 
			// tbNaziv
			// 
			tbNaziv.Location = new Point(151, 100);
			tbNaziv.Name = "tbNaziv";
			tbNaziv.Size = new Size(125, 27);
			tbNaziv.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(95, 163);
			label2.Name = "label2";
			label2.Size = new Size(46, 20);
			label2.TabIndex = 7;
			label2.Text = "Opis: ";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(95, 103);
			label1.Name = "label1";
			label1.Size = new Size(53, 20);
			label1.TabIndex = 6;
			label1.Text = "Naziv: ";
			// 
			// UCDodajStrSpremu
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnIzmeni);
			Controls.Add(btnDodaj);
			Controls.Add(tbOpis);
			Controls.Add(tbNaziv);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UCDodajStrSpremu";
			Size = new Size(393, 397);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnIzmeni;
		private Button btnDodaj;
		private TextBox tbOpis;
		private TextBox tbNaziv;
		private Label label2;
		private Label label1;

		public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
		public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
		public TextBox TbOpis { get => tbOpis; set => tbOpis = value; }
		public TextBox TbNaziv { get => tbNaziv; set => tbNaziv = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public Label Label1 { get => label1; set => label1 = value; }
	}
}
