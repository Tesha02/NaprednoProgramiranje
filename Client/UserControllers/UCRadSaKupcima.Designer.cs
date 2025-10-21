namespace Client.UserControllers
{
	partial class UCRadSaKupcima
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
			btnDetalji = new Button();
			tbPretraga = new TextBox();
			label1 = new Label();
			dgvKupci = new DataGridView();
			Ime = new DataGridViewTextBoxColumn();
			Prezime = new DataGridViewTextBoxColumn();
			Email = new DataGridViewTextBoxColumn();
			KontaktTelefon = new DataGridViewTextBoxColumn();
			Mesto = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvKupci).BeginInit();
			SuspendLayout();
			// 
			// btnDetalji
			// 
			btnDetalji.Location = new Point(784, 72);
			btnDetalji.Name = "btnDetalji";
			btnDetalji.Size = new Size(94, 29);
			btnDetalji.TabIndex = 9;
			btnDetalji.Text = "Detalji";
			btnDetalji.UseVisualStyleBackColor = true;
			// 
			// tbPretraga
			// 
			tbPretraga.Location = new Point(47, 74);
			tbPretraga.Name = "tbPretraga";
			tbPretraga.Size = new Size(377, 27);
			tbPretraga.TabIndex = 8;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(47, 30);
			label1.Name = "label1";
			label1.Size = new Size(68, 20);
			label1.TabIndex = 7;
			label1.Text = "Pretraga:";
			// 
			// dgvKupci
			// 
			dgvKupci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvKupci.Columns.AddRange(new DataGridViewColumn[] { Ime, Prezime, Email, KontaktTelefon, Mesto });
			dgvKupci.Location = new Point(18, 215);
			dgvKupci.Name = "dgvKupci";
			dgvKupci.RowHeadersWidth = 51;
			dgvKupci.Size = new Size(860, 355);
			dgvKupci.TabIndex = 6;
			// 
			// Ime
			// 
			Ime.DataPropertyName = "Ime";
			Ime.HeaderText = "Ime";
			Ime.MinimumWidth = 6;
			Ime.Name = "Ime";
			Ime.Width = 125;
			// 
			// Prezime
			// 
			Prezime.DataPropertyName = "Prezime";
			Prezime.HeaderText = "Prezime";
			Prezime.MinimumWidth = 6;
			Prezime.Name = "Prezime";
			Prezime.Width = 125;
			// 
			// Email
			// 
			Email.DataPropertyName = "Email";
			Email.HeaderText = "Email";
			Email.MinimumWidth = 6;
			Email.Name = "Email";
			Email.Width = 125;
			// 
			// KontaktTelefon
			// 
			KontaktTelefon.DataPropertyName = "KontaktTelefon";
			KontaktTelefon.HeaderText = "Kontakt Telefon";
			KontaktTelefon.MinimumWidth = 6;
			KontaktTelefon.Name = "KontaktTelefon";
			KontaktTelefon.Width = 125;
			// 
			// Mesto
			// 
			Mesto.DataPropertyName = "Mesto";
			Mesto.HeaderText = "Mesto";
			Mesto.MinimumWidth = 6;
			Mesto.Name = "Mesto";
			Mesto.Width = 125;
			// 
			// UCRadSaKupcima
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnDetalji);
			Controls.Add(tbPretraga);
			Controls.Add(label1);
			Controls.Add(dgvKupci);
			Name = "UCRadSaKupcima";
			Size = new Size(896, 601);
			((System.ComponentModel.ISupportInitialize)dgvKupci).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnDetalji;
		private TextBox tbPretraga;
		private Label label1;
		private DataGridView dgvKupci;
		private DataGridViewTextBoxColumn Ime;
		private DataGridViewTextBoxColumn Prezime;
		private DataGridViewTextBoxColumn Email;
		private DataGridViewTextBoxColumn KontaktTelefon;
		private DataGridViewTextBoxColumn Mesto;

		public Button BtnDetalji { get => btnDetalji; set => btnDetalji = value; }
		public TextBox TbPretraga { get => tbPretraga; set => tbPretraga = value; }
		public Label Label1 { get => label1; set => label1 = value; }
		public DataGridView DgvKupci { get => dgvKupci; set => dgvKupci = value; }
	}
}
