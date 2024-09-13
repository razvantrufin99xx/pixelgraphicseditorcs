/*
 * Created by SharpDevelop.
 * User: razvan
 * Date: 9/13/2024
 * Time: 4:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace pixelsGiga
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		Graphics g;
		Font f;
		Pen p = new Pen(Color.Black);
		Brush b = new SolidBrush(Color.Red);
		public void grid()
		{
			for (int y = 0; y < 20; y++)
        	{
        	    for (int x = 0; x < 20; x++)
            	{
                	g.DrawRectangle(Pens.Black, x * 20, y * 20, 20, 20);
            	}
        	}
		}
		public int[,] gridint = new int[20,20];
		void MainFormMouseDown(object sender, MouseEventArgs e)
		{
			int x = (e.X/20)*20;
			int y = (e.Y/20)*20;
			Text = "x=" + x.ToString() + "y=" + y.ToString() ;
			Text += "==>" + "ex=" + e.X.ToString() + "ey=" + e.Y.ToString() ;
			g.FillRectangle(b,x,y,20,20);
			gridint[(e.X/20),e.Y/20]=1;
		}
		public void initgridmatrxi()
		{
			 for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    gridint[i, j] = 0; // Random integers between 0 and 99
                }
            }
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			g = CreateGraphics();
			f = this.Font;
			initgridmatrxi();
		}
		void MainFormShown(object sender, EventArgs e)
		{
			grid();
		}
		public void displaygrid()
		{
			for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                	if(gridint[i,j]!=0){
                    	textBox1.AppendText(gridint[i, j].ToString("D2") + " ");
                	}
                	else 
                	{
                		textBox1.AppendText("00"+ " ");
                	}
                }
                textBox1.AppendText(Environment.NewLine);
            }
		}
		void Button1Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			displaygrid();
		}
	}
}
