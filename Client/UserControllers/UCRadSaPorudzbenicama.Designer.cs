namespace Client.UserControllers
{
	partial class UCRadSaPorudzbenicama
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
			btnPrikaziSve = new Button();
			btnIzbrisi = new Button();
			btnDetalji = new Button();
			dgvPorudzbenice = new DataGridView();
			DatumOd = new DataGridViewTextBoxColumn();
			DatumDo = new DataGridViewTextBoxColumn();
			UkupnaVr = new DataGridViewTextBoxColumn();
			Radnik = new DataGridViewTextBoxColumn();
			Kupac = new DataGridViewTextBoxColumn();
			cmbKupac = new ComboBox();
			label1 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvPorudzbenice).BeginInit();
			SuspendLayout();
			// 
			// btnPrikaziSve
			// 
			btnPrikaziSve.Location = new Point(629, 97);
			btnPrikaziSve.Name = "btnPrikaziSve";
			btnPrikaziSve.Size = new Size(186, 29);
			btnPrikaziSve.TabIndex = 11;
			btnPrikaziSve.Text = "Prikazi sve porudzbenice";
			btnPrikaziSve.UseVisualStyleBackColor = true;
			// 
			// btnIzbrisi
			// 
			btnIzbrisi.Location = new Point(721, 510);
			btnIzbrisi.Name = "btnIzbrisi";
			btnIzbrisi.Size = new Size(94, 29);
			btnIzbrisi.TabIndex = 10;
			btnIzbrisi.Text = "Izbrisi";
			btnIzbrisi.UseVisualStyleBackColor = true;
			// 
			// btnDetalji
			// 
			btnDetalji.Location = new Point(721, 465);
			btnDetalji.Name = "btnDetalji";
			btnDetalji.Size = new Size(94, 29);
			btnDetalji.TabIndex = 9;
			btnDetalji.Text = "Detalji";
			btnDetalji.UseVisualStyleBackColor = true;
			// 
			// dgvPorudzbenice
			// 
			dgvPorudzbenice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvPorudzbenice.Columns.AddRange(new DataGridViewColumn[] { DatumOd, DatumDo, UkupnaVr, Radnik, Kupac });
			dgvPorudzbenice.Location = new Point(22, 187);
			dgvPorudzbenice.Name = "dgvPorudzbenice";
			dgvPorudzbenice.RowHeadersWidth = 51;
			dgvPorudzbenice.Size = new Size(678, 352);
			dgvPorudzbenice.TabIndex = 8;
			// 
			// DatumOd
			// 
			DatumOd.DataPropertyName = "DatumOd";
			DatumOd.HeaderText = "Datum od";
			DatumOd.MinimumWidth = 6;
			DatumOd.Name = "DatumOd";
			DatumOd.Width = 125;
			// 
			// DatumDo
			// 
			DatumDo.DataPropertyName = "DatumDo";
			DatumDo.HeaderText = "Datum do";
			DatumDo.MinimumWidth = 6;
			DatumDo.Name = "DatumDo";
			DatumDo.Width = 125;
			// 
			// UkupnaVr
			// 
			UkupnaVr.DataPropertyName = "UkupnaVr";
			UkupnaVr.HeaderText = "Ukupna vrednost";
			UkupnaVr.MinimumWidth = 6;
			UkupnaVr.Name = "UkupnaVr";
			UkupnaVr.Width = 125;
			// 
			// Radnik
			// 
			Radnik.DataPropertyName = "Radnik";
			Radnik.HeaderText = "Radnik";
			Radnik.MinimumWidth = 6;
			Radnik.Name = "Radnik";
			Radnik.Width = 125;
			// 
			// Kupac
			// 
			Kupac.DataPropertyName = "Kupac";
			Kupac.HeaderText = "Kupac";
			Kupac.MinimumWidth = 6;
			Kupac.Name = "Kupac";
			Kupac.Width = 125;
			// 
			// cmbKupac
			// 
			cmbKupac.FormattingEnabled = true;
			cmbKupac.Location = new Point(78, 98);
			cmbKupac.Name = "cmbKupac";
			cmbKupac.Size = new Size(330, 28);
			cmbKupac.TabIndex = 7;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(22, 101);
			label1.Name = "label1";
			label1.Size = new Size(50, 20);
			label1.TabIndex = 6;
			label1.Text = "Kupac";
			// 
			// UCRadSaPorudzbenicama
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnPrikaziSve);
			Controls.Add(btnIzbrisi);
			Controls.Add(btnDetalji);
			Controls.Add(dgvPorudzbenice);
			Controls.Add(cmbKupac);
			Controls.Add(label1);
			Name = "UCRadSaPorudzbenicama";
			Size = new Size(832, 631);
			((System.ComponentModel.ISupportInitialize)dgvPorudzbenice).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnPrikaziSve;
		private Button btnIzbrisi;
		private Button btnDetalji;
		private DataGridView dgvPorudzbenice;
		private ComboBox cmbKupac;
		private Label label1;
		private DataGridViewTextBoxColumn DatumOd;
		private DataGridViewTextBoxColumn DatumDo;
		private DataGridViewTextBoxColumn UkupnaVr;
		private DataGridViewTextBoxColumn Radnik;
		private DataGridViewTextBoxColumn Kupac;

		public Button BtnPrikaziSve { get => btnPrikaziSve; set => btnPrikaziSve = value; }
		public Button BtnIzbrisi { get => btnIzbrisi; set => btnIzbrisi = value; }
		public Button BtnDetalji { get => btnDetalji; set => btnDetalji = value; }
		public DataGridView DgvPorudzbenice { get => dgvPorudzbenice; set => dgvPorudzbenice = value; }
		public ComboBox CmbKupac { get => cmbKupac; set => cmbKupac = value; }
		public Label Label1 { get => label1; set => label1 = value; }
	}
}
