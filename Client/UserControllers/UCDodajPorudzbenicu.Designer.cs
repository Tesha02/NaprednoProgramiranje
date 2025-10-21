namespace Client.UserControllers
{
	partial class UCDodajPorudzbenicu
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
			tbUkupnaVrednost = new TextBox();
			label3 = new Label();
			dgvStavke = new DataGridView();
			Artikal = new DataGridViewTextBoxColumn();
			CenaArtikla = new DataGridViewTextBoxColumn();
			Kolicina = new DataGridViewTextBoxColumn();
			UkupnaCena = new DataGridViewTextBoxColumn();
			label7 = new Label();
			panel1 = new Panel();
			btnDodajStavku = new Button();
			tbIznosArtikla = new TextBox();
			tbUkupnaCena = new TextBox();
			tbKolicina = new TextBox();
			cmbArtikal = new ComboBox();
			label10 = new Label();
			label9 = new Label();
			label8 = new Label();
			label4 = new Label();
			dtpDatumDo = new DateTimePicker();
			dtpDatumOd = new DateTimePicker();
			label6 = new Label();
			label5 = new Label();
			btnObrisiStavku = new Button();
			cmbKupac = new ComboBox();
			lblRadnik = new Label();
			label2 = new Label();
			label1 = new Label();
			btnAzuriraj = new Button();
			btnSacuvaj = new Button();
			((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// tbUkupnaVrednost
			// 
			tbUkupnaVrednost.Location = new Point(154, 221);
			tbUkupnaVrednost.Name = "tbUkupnaVrednost";
			tbUkupnaVrednost.Size = new Size(209, 27);
			tbUkupnaVrednost.TabIndex = 25;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(25, 224);
			label3.Name = "label3";
			label3.Size = new Size(123, 20);
			label3.TabIndex = 26;
			label3.Text = "Ukupna vrednost:";
			// 
			// dgvStavke
			// 
			dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvStavke.Columns.AddRange(new DataGridViewColumn[] { Artikal, CenaArtikla, Kolicina, UkupnaCena });
			dgvStavke.Location = new Point(3, 338);
			dgvStavke.Name = "dgvStavke";
			dgvStavke.ReadOnly = true;
			dgvStavke.RowHeadersWidth = 51;
			dgvStavke.Size = new Size(796, 340);
			dgvStavke.TabIndex = 27;
			// 
			// Artikal
			// 
			Artikal.HeaderText = "Artikal";
			Artikal.MinimumWidth = 6;
			Artikal.Name = "Artikal";
			Artikal.ReadOnly = true;
			Artikal.Width = 125;
			// 
			// CenaArtikla
			// 
			CenaArtikla.HeaderText = "Cena artikla";
			CenaArtikla.MinimumWidth = 6;
			CenaArtikla.Name = "CenaArtikla";
			CenaArtikla.ReadOnly = true;
			CenaArtikla.Width = 125;
			// 
			// Kolicina
			// 
			Kolicina.HeaderText = "Kolicina";
			Kolicina.MinimumWidth = 6;
			Kolicina.Name = "Kolicina";
			Kolicina.ReadOnly = true;
			Kolicina.Width = 125;
			// 
			// UkupnaCena
			// 
			UkupnaCena.HeaderText = "Ukupna cena";
			UkupnaCena.MinimumWidth = 6;
			UkupnaCena.Name = "UkupnaCena";
			UkupnaCena.ReadOnly = true;
			UkupnaCena.Width = 125;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(481, 35);
			label7.Name = "label7";
			label7.Size = new Size(52, 20);
			label7.TabIndex = 24;
			label7.Text = "Stavka";
			// 
			// panel1
			// 
			panel1.Controls.Add(btnDodajStavku);
			panel1.Controls.Add(tbIznosArtikla);
			panel1.Controls.Add(tbUkupnaCena);
			panel1.Controls.Add(tbKolicina);
			panel1.Controls.Add(cmbArtikal);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(label4);
			panel1.Location = new Point(470, 47);
			panel1.Name = "panel1";
			panel1.Size = new Size(438, 254);
			panel1.TabIndex = 23;
			// 
			// btnDodajStavku
			// 
			btnDodajStavku.Location = new Point(239, 222);
			btnDodajStavku.Name = "btnDodajStavku";
			btnDodajStavku.Size = new Size(111, 29);
			btnDodajStavku.TabIndex = 7;
			btnDodajStavku.Text = "Dodaj stavku";
			btnDodajStavku.UseVisualStyleBackColor = true;
			// 
			// tbIznosArtikla
			// 
			tbIznosArtikla.Location = new Point(141, 115);
			tbIznosArtikla.Name = "tbIznosArtikla";
			tbIznosArtikla.Size = new Size(209, 27);
			tbIznosArtikla.TabIndex = 6;
			// 
			// tbUkupnaCena
			// 
			tbUkupnaCena.Location = new Point(141, 157);
			tbUkupnaCena.Name = "tbUkupnaCena";
			tbUkupnaCena.Size = new Size(209, 27);
			tbUkupnaCena.TabIndex = 12;
			// 
			// tbKolicina
			// 
			tbKolicina.Location = new Point(141, 72);
			tbKolicina.Name = "tbKolicina";
			tbKolicina.Size = new Size(209, 27);
			tbKolicina.TabIndex = 5;
			// 
			// cmbArtikal
			// 
			cmbArtikal.FormattingEnabled = true;
			cmbArtikal.Location = new Point(141, 31);
			cmbArtikal.Name = "cmbArtikal";
			cmbArtikal.Size = new Size(209, 28);
			cmbArtikal.TabIndex = 4;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(38, 118);
			label10.Name = "label10";
			label10.Size = new Size(90, 20);
			label10.TabIndex = 2;
			label10.Text = "Cena artikla:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(38, 75);
			label9.Name = "label9";
			label9.Size = new Size(65, 20);
			label9.TabIndex = 1;
			label9.Text = "Kolicina:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(38, 31);
			label8.Name = "label8";
			label8.Size = new Size(55, 20);
			label8.TabIndex = 0;
			label8.Text = "Artikal:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(38, 160);
			label4.Name = "label4";
			label4.Size = new Size(97, 20);
			label4.TabIndex = 3;
			label4.Text = "Ukupna cena:";
			// 
			// dtpDatumDo
			// 
			dtpDatumDo.Location = new Point(207, 149);
			dtpDatumDo.Name = "dtpDatumDo";
			dtpDatumDo.Size = new Size(250, 27);
			dtpDatumDo.TabIndex = 22;
			// 
			// dtpDatumOd
			// 
			dtpDatumOd.Location = new Point(207, 56);
			dtpDatumOd.Name = "dtpDatumOd";
			dtpDatumOd.Size = new Size(250, 27);
			dtpDatumOd.TabIndex = 21;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(207, 110);
			label6.Name = "label6";
			label6.Size = new Size(79, 20);
			label6.TabIndex = 20;
			label6.Text = "Datum do:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(207, 14);
			label5.Name = "label5";
			label5.Size = new Size(79, 20);
			label5.TabIndex = 19;
			label5.Text = "Datum od:";
			// 
			// btnObrisiStavku
			// 
			btnObrisiStavku.Location = new Point(25, 272);
			btnObrisiStavku.Name = "btnObrisiStavku";
			btnObrisiStavku.Size = new Size(121, 29);
			btnObrisiStavku.TabIndex = 18;
			btnObrisiStavku.Text = "Obrisi stavku";
			btnObrisiStavku.UseVisualStyleBackColor = true;
			// 
			// cmbKupac
			// 
			cmbKupac.FormattingEnabled = true;
			cmbKupac.Location = new Point(25, 58);
			cmbKupac.Name = "cmbKupac";
			cmbKupac.Size = new Size(151, 28);
			cmbKupac.TabIndex = 17;
			// 
			// lblRadnik
			// 
			lblRadnik.AutoSize = true;
			lblRadnik.Location = new Point(25, 156);
			lblRadnik.Name = "lblRadnik";
			lblRadnik.Size = new Size(50, 20);
			lblRadnik.TabIndex = 16;
			lblRadnik.Text = "label3";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(25, 110);
			label2.Name = "label2";
			label2.Size = new Size(57, 20);
			label2.TabIndex = 15;
			label2.Text = "Radnik:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(25, 14);
			label1.Name = "label1";
			label1.Size = new Size(53, 20);
			label1.TabIndex = 14;
			label1.Text = "Kupac:";
			// 
			// btnAzuriraj
			// 
			btnAzuriraj.Location = new Point(726, 307);
			btnAzuriraj.Name = "btnAzuriraj";
			btnAzuriraj.Size = new Size(94, 29);
			btnAzuriraj.TabIndex = 28;
			btnAzuriraj.Text = "Azuriraj";
			btnAzuriraj.UseVisualStyleBackColor = true;
			// 
			// btnSacuvaj
			// 
			btnSacuvaj.Location = new Point(726, 307);
			btnSacuvaj.Name = "btnSacuvaj";
			btnSacuvaj.Size = new Size(94, 29);
			btnSacuvaj.TabIndex = 29;
			btnSacuvaj.Text = "Sacuvaj";
			btnSacuvaj.UseVisualStyleBackColor = true;
			// 
			// UCDodajPorudzbenicu
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(btnSacuvaj);
			Controls.Add(btnAzuriraj);
			Controls.Add(tbUkupnaVrednost);
			Controls.Add(label3);
			Controls.Add(dgvStavke);
			Controls.Add(label7);
			Controls.Add(panel1);
			Controls.Add(dtpDatumDo);
			Controls.Add(dtpDatumOd);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(btnObrisiStavku);
			Controls.Add(cmbKupac);
			Controls.Add(lblRadnik);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UCDodajPorudzbenicu";
			Size = new Size(921, 692);
			((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbUkupnaVrednost;
		private Label label3;
		private DataGridView dgvStavke;
		private DataGridViewTextBoxColumn Artikal;
		private DataGridViewTextBoxColumn CenaArtikla;
		private DataGridViewTextBoxColumn Kolicina;
		private DataGridViewTextBoxColumn UkupnaCena;
		private Label label7;
		private Panel panel1;
		private Button btnDodajStavku;
		private TextBox tbIznosArtikla;
		private TextBox tbUkupnaCena;
		private TextBox tbKolicina;
		private ComboBox cmbArtikal;
		private Label label10;
		private Label label9;
		private Label label8;
		private Label label4;
		private DateTimePicker dtpDatumDo;
		private DateTimePicker dtpDatumOd;
		private Label label6;
		private Label label5;
		private Button btnObrisiStavku;
		private ComboBox cmbKupac;
		private Label lblRadnik;
		private Label label2;
		private Label label1;
		private Button btnAzuriraj;
		private Button btnSacuvaj;

		public TextBox TbUkupnaVrednost { get => tbUkupnaVrednost; set => tbUkupnaVrednost = value; }
		public Label Label3 { get => label3; set => label3 = value; }
		public DataGridView DgvStavke { get => dgvStavke; set => dgvStavke = value; }
		public DataGridViewTextBoxColumn Artikal1 { get => Artikal; set => Artikal = value; }
		public DataGridViewTextBoxColumn CenaArtikla1 { get => CenaArtikla; set => CenaArtikla = value; }
		public DataGridViewTextBoxColumn Kolicina1 { get => Kolicina; set => Kolicina = value; }
		public DataGridViewTextBoxColumn UkupnaCena1 { get => UkupnaCena; set => UkupnaCena = value; }
		public Label Label7 { get => label7; set => label7 = value; }
		public Panel Panel1 { get => panel1; set => panel1 = value; }
		public Button BtnDodajStavku { get => btnDodajStavku; set => btnDodajStavku = value; }
		public TextBox TbIznosArtikla { get => tbIznosArtikla; set => tbIznosArtikla = value; }
		public TextBox TbUkupnaCena { get => tbUkupnaCena; set => tbUkupnaCena = value; }
		public TextBox TbKolicina { get => tbKolicina; set => tbKolicina = value; }
		public ComboBox CmbArtikal { get => cmbArtikal; set => cmbArtikal = value; }
		public Label Label10 { get => label10; set => label10 = value; }
		public Label Label9 { get => label9; set => label9 = value; }
		public Label Label8 { get => label8; set => label8 = value; }
		public Label Label4 { get => label4; set => label4 = value; }
		public DateTimePicker DtpDatumDo { get => dtpDatumDo; set => dtpDatumDo = value; }
		public DateTimePicker DtpDatumOd { get => dtpDatumOd; set => dtpDatumOd = value; }
		public Label Label6 { get => label6; set => label6 = value; }
		public Label Label5 { get => label5; set => label5 = value; }
		public Button BtnObrisiStavku { get => btnObrisiStavku; set => btnObrisiStavku = value; }
		public ComboBox CmbKupac { get => cmbKupac; set => cmbKupac = value; }
		public Label LblRadnik { get => lblRadnik; set => lblRadnik = value; }
		public Label Label2 { get => label2; set => label2 = value; }
		public Label Label1 { get => label1; set => label1 = value; }
		public Button BtnAzuriraj { get => btnAzuriraj; set => btnAzuriraj = value; }
		public Button BtnSacuvaj { get => btnSacuvaj; set => btnSacuvaj = value; }
	}
}
