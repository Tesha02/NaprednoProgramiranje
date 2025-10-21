namespace Server
{
	partial class Form1
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
			btnStart = new Button();
			btnStop = new Button();
			SuspendLayout();
			// 
			// btnStart
			// 
			btnStart.Location = new Point(102, 239);
			btnStart.Name = "btnStart";
			btnStart.Size = new Size(124, 29);
			btnStart.TabIndex = 0;
			btnStart.Text = "Pokreni Server";
			btnStart.UseVisualStyleBackColor = true;
			btnStart.Click += btnStart_Click;
			// 
			// btnStop
			// 
			btnStop.Location = new Point(558, 239);
			btnStop.Name = "btnStop";
			btnStop.Size = new Size(124, 29);
			btnStop.TabIndex = 1;
			btnStop.Text = "Zaustavi Server";
			btnStop.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnStop);
			Controls.Add(btnStart);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private Button btnStart;
		private Button btnStop;
	}
}
