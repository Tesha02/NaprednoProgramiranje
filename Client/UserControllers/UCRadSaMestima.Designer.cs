namespace Client.UserControllers
{
	partial class UCRadSaMestima
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
			components = new System.ComponentModel.Container();
			bindingSource1 = new BindingSource(components);
			label1 = new Label();
			tbPretrazi = new TextBox();
			btnObrisi = new Button();
			dgvMesta = new DataGridView();
			PostanskiBroj = new DataGridViewTextBoxColumn();
			Naziv = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvMesta).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(69, 34);
			label1.Name = "label1";
			label1.Size = new Size(59, 20);
			label1.TabIndex = 10;
			label1.Text = "Pretrazi";
			// 
			// tbPretrazi
			// 
			tbPretrazi.Location = new Point(69, 83);
			tbPretrazi.Name = "tbPretrazi";
			tbPretrazi.Size = new Size(240, 27);
			tbPretrazi.TabIndex = 9;
			// 
			// btnObrisi
			// 
			btnObrisi.Location = new Point(518, 267);
			btnObrisi.Name = "btnObrisi";
			btnObrisi.Size = new Size(94, 29);
			btnObrisi.TabIndex = 8;
			btnObrisi.Text = "Obrisi";
			btnObrisi.UseVisualStyleBackColor = true;
			// 
			// dgvMesta
			// 
			dgvMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMesta.Columns.AddRange(new DataGridViewColumn[] { PostanskiBroj, Naziv });
			dgvMesta.Location = new Point(69, 220);
			dgvMesta.Name = "dgvMesta";
			dgvMesta.RowHeadersWidth = 51;
			dgvMesta.Size = new Size(406, 315);
			dgvMesta.TabIndex = 6;
			// 
			// PostanskiBroj
			// 
			PostanskiBroj.DataPropertyName = "PostanskiBroj";
			PostanskiBroj.HeaderText = "Postanski Broj";
			PostanskiBroj.MinimumWidth = 6;
			PostanskiBroj.Name = "PostanskiBroj";
			PostanskiBroj.Width = 125;
			// 
			// Naziv
			// 
			Naziv.DataPropertyName = "Naziv";
			Naziv.HeaderText = "Naziv";
			Naziv.MinimumWidth = 6;
			Naziv.Name = "Naziv";
			Naziv.Width = 125;
			// 
			// UCRadSaMestima
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(label1);
			Controls.Add(tbPretrazi);
			Controls.Add(btnObrisi);
			Controls.Add(dgvMesta);
			Name = "UCRadSaMestima";
			Size = new Size(730, 571);
			((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvMesta).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private BindingSource bindingSource1;
		private Label label1;
		private TextBox tbPretrazi;
		private Button btnObrisi;
		private DataGridView dgvMesta;
		private DataGridViewTextBoxColumn PostanskiBroj;
		private DataGridViewTextBoxColumn Naziv;

		public BindingSource BindingSource1 { get => bindingSource1; set => bindingSource1 = value; }
		public Label Label1 { get => label1; set => label1 = value; }
		public TextBox TbPretrazi { get => tbPretrazi; set => tbPretrazi = value; }
		public Button BtnObrisi { get => btnObrisi; set => btnObrisi = value; }
		public DataGridView DgvMesta { get => dgvMesta; set => dgvMesta = value; }
	}
}
