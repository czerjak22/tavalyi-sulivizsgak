﻿namespace _06_CursorPosition
{
	partial class Form1
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelCursorPosition = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelCursorPosition
			// 
			this.labelCursorPosition.BackColor = System.Drawing.Color.Lime;
			this.labelCursorPosition.Location = new System.Drawing.Point(412, 217);
			this.labelCursorPosition.Name = "labelCursorPosition";
			this.labelCursorPosition.Size = new System.Drawing.Size(100, 23);
			this.labelCursorPosition.TabIndex = 0;
			this.labelCursorPosition.Text = "LABel";
			this.labelCursorPosition.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelCursorPosition_MouseMove);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.labelCursorPosition);
			this.Name = "Form1";
			this.Text = "Form1";
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelCursorPosition;
	}
}

