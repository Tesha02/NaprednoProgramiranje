namespace Client
{
	partial class FrmLogin
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			pbShowPass = new PictureBox();
			btnUloguj = new Button();
			tbLozinka = new TextBox();
			tbKorisnickoIme = new TextBox();
			label2 = new Label();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)pbShowPass).BeginInit();
			SuspendLayout();
			// 
			// pbShowPass
			// 
			pbShowPass.Location = new Point(444, 154);
			pbShowPass.Name = "pbShowPass";
			pbShowPass.Size = new Size(29, 27);
			pbShowPass.SizeMode = PictureBoxSizeMode.StretchImage;
			pbShowPass.TabIndex = 11;
			pbShowPass.TabStop = false;
			// 
			// btnUloguj
			// 
			btnUloguj.Location = new Point(88, 268);
			btnUloguj.Name = "btnUloguj";
			btnUloguj.Size = new Size(94, 29);
			btnUloguj.TabIndex = 10;
			btnUloguj.Text = "Uloguj se";
			btnUloguj.UseVisualStyleBackColor = true;
			// 
			// tbLozinka
			// 
			tbLozinka.Location = new Point(202, 154);
			tbLozinka.Name = "tbLozinka";
			tbLozinka.Size = new Size(236, 27);
			tbLozinka.TabIndex = 9;
			tbLozinka.UseSystemPasswordChar = true;
			// 
			// tbKorisnickoIme
			// 
			tbKorisnickoIme.Location = new Point(202, 84);
			tbKorisnickoIme.Name = "tbKorisnickoIme";
			tbKorisnickoIme.Size = new Size(236, 27);
			tbKorisnickoIme.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(88, 157);
			label2.Name = "label2";
			label2.Size = new Size(62, 20);
			label2.TabIndex = 7;
			label2.Text = "Lozinka:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(88, 87);
			label1.Name = "label1";
			label1.Size = new Size(109, 20);
			label1.TabIndex = 6;
			label1.Text = "Korisnicko ime:";
			// 
			// LoginForma
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(pbShowPass);
			Controls.Add(btnUloguj);
			Controls.Add(tbLozinka);
			Controls.Add(tbKorisnickoIme);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "LoginForma";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pbShowPass).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pbShowPass;
		private Button btnUloguj;
		private TextBox tbLozinka;
		private TextBox tbKorisnickoIme;
		private Label label2;
		private Label label1;

		public PictureBox PbShowPass { get => pbShowPass; set => pbShowPass = value; }
		public Button BtnUloguj { get => btnUloguj; set => btnUloguj = value; }
		public TextBox TbLozinka { get => tbLozinka; set => tbLozinka = value; }
		public TextBox TbKorisnickoIme { get => tbKorisnickoIme; set => tbKorisnickoIme = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public Label Label1 { get => label1; set => label1 = value; }
	}
}
