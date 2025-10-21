namespace Client.UserControllers
{
	partial class UCRadSaArtiklima
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
			dgvArtikli = new DataGridView();
			Naziv = new DataGridViewTextBoxColumn();
			Cena = new DataGridViewTextBoxColumn();
			Tip = new DataGridViewTextBoxColumn();
			cmbPretragaPoTipu = new ComboBox();
			tbPretraga = new TextBox();
			label2 = new Label();
			label1 = new Label();
			btnExport = new Button();
			((System.ComponentModel.ISupportInitialize)dgvArtikli).BeginInit();
			SuspendLayout();
			// 
			// btnDetalji
			// 
			btnDetalji.Location = new Point(600, 89);
			btnDetalji.Name = "btnDetalji";
			btnDetalji.Size = new Size(94, 29);
			btnDetalji.TabIndex = 11;
			btnDetalji.Text = "Detalji";
			btnDetalji.UseVisualStyleBackColor = true;
			// 
			// dgvArtikli
			// 
			dgvArtikli.AllowUserToOrderColumns = true;
			dgvArtikli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvArtikli.Columns.AddRange(new DataGridViewColumn[] { Naziv, Cena, Tip });
			dgvArtikli.Location = new Point(36, 262);
			dgvArtikli.Name = "dgvArtikli";
			dgvArtikli.RowHeadersWidth = 51;
			dgvArtikli.Size = new Size(672, 285);
			dgvArtikli.TabIndex = 10;
			// 
			// Naziv
			// 
			Naziv.DataPropertyName = "Naziv";
			Naziv.HeaderText = "Naziv";
			Naziv.MinimumWidth = 6;
			Naziv.Name = "Naziv";
			Naziv.Width = 125;
			// 
			// Cena
			// 
			Cena.DataPropertyName = "Cena";
			Cena.HeaderText = "Cena";
			Cena.MinimumWidth = 6;
			Cena.Name = "Cena";
			Cena.Width = 125;
			// 
			// Tip
			// 
			Tip.DataPropertyName = "Tip";
			Tip.HeaderText = "Tip";
			Tip.MinimumWidth = 6;
			Tip.Name = "Tip";
			Tip.Width = 125;
			// 
			// cmbPretragaPoTipu
			// 
			cmbPretragaPoTipu.FormattingEnabled = true;
			cmbPretragaPoTipu.Location = new Point(36, 187);
			cmbPretragaPoTipu.Name = "cmbPretragaPoTipu";
			cmbPretragaPoTipu.Size = new Size(151, 28);
			cmbPretragaPoTipu.TabIndex = 9;
			// 
			// tbPretraga
			// 
			tbPretraga.Location = new Point(36, 90);
			tbPretraga.Name = "tbPretraga";
			tbPretraga.Size = new Size(266, 27);
			tbPretraga.TabIndex = 8;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(36, 145);
			label2.Name = "label2";
			label2.Size = new Size(120, 20);
			label2.TabIndex = 7;
			label2.Text = "Pretraga po tipu:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(36, 58);
			label1.Name = "label1";
			label1.Size = new Size(65, 20);
			label1.TabIndex = 6;
			label1.Text = "Pretraga";
			// 
			// btnExport
			// 
			btnExport.Location = new Point(506, 156);
			btnExport.Name = "btnExport";
			btnExport.Size = new Size(188, 29);
			btnExport.TabIndex = 12;
			btnExport.Text = "Prebaci sve artikle u fajl";
			btnExport.UseVisualStyleBackColor = true;
			// 
			// UCRadSaArtiklima
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnExport);
			Controls.Add(btnDetalji);
			Controls.Add(dgvArtikli);
			Controls.Add(cmbPretragaPoTipu);
			Controls.Add(tbPretraga);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UCRadSaArtiklima";
			Size = new Size(745, 605);
			((System.ComponentModel.ISupportInitialize)dgvArtikli).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnDetalji;
		private DataGridView dgvArtikli;
		private ComboBox cmbPretragaPoTipu;
		private TextBox tbPretraga;
		private Label label2;
		private Label label1;
		private DataGridViewTextBoxColumn Naziv;
		private DataGridViewTextBoxColumn Cena;
		private DataGridViewTextBoxColumn Tip;
		private Button btnExport;

		public Button BtnExport { get => btnExport; set => btnExport = value; }
		public Button BtnDetalji { get => btnDetalji; set => btnDetalji = value; }
		public DataGridView DgvArtikli { get => dgvArtikli; set => dgvArtikli = value; }
		public ComboBox CmbPretragaPoTipu { get => cmbPretragaPoTipu; set => cmbPretragaPoTipu = value; }
		public TextBox TbPretraga { get => tbPretraga; set => tbPretraga = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public Label Label1 { get => label1; set => label1 = value; }
	}
}
