namespace Client.UserControllers
{
	partial class UCRadSaStrSpremom
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
			btnObrisi = new Button();
			btnIzmeni = new Button();
			label1 = new Label();
			tbPretraga = new TextBox();
			dgvStrSprema = new DataGridView();
			NazivStrSpreme = new DataGridViewTextBoxColumn();
			Opis = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dgvStrSprema).BeginInit();
			SuspendLayout();
			// 
			// btnObrisi
			// 
			btnObrisi.Location = new Point(463, 258);
			btnObrisi.Name = "btnObrisi";
			btnObrisi.Size = new Size(94, 29);
			btnObrisi.TabIndex = 9;
			btnObrisi.Text = "Obrisi";
			btnObrisi.UseVisualStyleBackColor = true;
			// 
			// btnIzmeni
			// 
			btnIzmeni.Location = new Point(463, 199);
			btnIzmeni.Name = "btnIzmeni";
			btnIzmeni.Size = new Size(94, 29);
			btnIzmeni.TabIndex = 8;
			btnIzmeni.Text = "Izmeni";
			btnIzmeni.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(26, 40);
			label1.Name = "label1";
			label1.Size = new Size(62, 20);
			label1.TabIndex = 7;
			label1.Text = "Pretrazi:";
			// 
			// tbPretraga
			// 
			tbPretraga.Location = new Point(26, 77);
			tbPretraga.Name = "tbPretraga";
			tbPretraga.Size = new Size(190, 27);
			tbPretraga.TabIndex = 6;
			// 
			// dgvStrSprema
			// 
			dgvStrSprema.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStrSprema.Columns.AddRange(new DataGridViewColumn[] { NazivStrSpreme, Opis });
			dgvStrSprema.Location = new Point(26, 199);
			dgvStrSprema.Name = "dgvStrSprema";
			dgvStrSprema.RowHeadersWidth = 51;
			dgvStrSprema.Size = new Size(431, 226);
			dgvStrSprema.TabIndex = 5;
			// 
			// NazivStrSpreme
			// 
			NazivStrSpreme.DataPropertyName = "Naziv";
			NazivStrSpreme.HeaderText = "Strucna Sprema";
			NazivStrSpreme.MinimumWidth = 6;
			NazivStrSpreme.Name = "NazivStrSpreme";
			NazivStrSpreme.Width = 125;
			// 
			// Opis
			// 
			Opis.DataPropertyName = "Opis";
			Opis.HeaderText = "Opis";
			Opis.MinimumWidth = 6;
			Opis.Name = "Opis";
			Opis.Width = 125;
			// 
			// UCRadSaStrSpremom
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnObrisi);
			Controls.Add(btnIzmeni);
			Controls.Add(label1);
			Controls.Add(tbPretraga);
			Controls.Add(dgvStrSprema);
			Name = "UCRadSaStrSpremom";
			Size = new Size(574, 453);
			((System.ComponentModel.ISupportInitialize)dgvStrSprema).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnObrisi;
		private Button btnIzmeni;
		private Label label1;
		private TextBox tbPretraga;
		private DataGridView dgvStrSprema;
		private DataGridViewTextBoxColumn NazivStrSpreme;
		private DataGridViewTextBoxColumn Opis;

		public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
		public Button BtnIzmeni { get => btnIzmeni; set => btnIzmeni = value; }
		public Label Label1 { get => label1; set => label1 = value; }
		public TextBox TbPretraga { get => tbPretraga; set => tbPretraga = value; }
		public DataGridView DgvStrSprema { get => dgvStrSprema; set => dgvStrSprema = value; }
	}
}
