﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _33_Gym
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			pictureBox1.Size = ClientSize;
			pictureBox1.Visible = true;
			pictureBox1.Top = 0;
			pictureBox1.Left = 0;
			pictureBox2.Top = 0;
			pictureBox2.Left = 0;
			pictureBox2.Size = ClientSize;
			pictureBox2.Visible = false;
			timer1.Interval = 100;
			timer1.Start();
		}
		private bool tick = false;
		private void timer1_Tick(object sender, EventArgs e)
		{
			pictureBox1.Visible = tick;
			pictureBox2.Visible = !tick;
			tick = !tick;
		}
	}
}
