using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Autoclicker2
{
    public partial class Form1 : Form
    {

        [DllImport("User32.dll")] 
        public static extern short GetAsyncKeyState(Keys ArrowKeys);
        
        
        InputSimulator input = new InputSimulator();    

        public Form1()
        {
            InitializeComponent();
        }

        Random rng = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out int count);
            while (count > 0) 
            {
                int resdifferencex = 65535 / Screen.PrimaryScreen.Bounds.Width;
                int resdifferencey = 65535 / Screen.PrimaryScreen.Bounds.Height;
                int.TryParse(textBox1.Text, out int X);
                int.TryParse(textBox2.Text, out int Y);
                X = rng.Next(X, X + 8);
                Y = rng.Next(Y, Y + 5);
                input.Mouse.MoveMouseTo(X*resdifferencex, Y*resdifferencey);
                input.Mouse.LeftButtonClick();
                
                count--;
                textBox3.Text = count.ToString();
                if (GetAsyncKeyState(Keys.R) != 0)
                {
                    count = 1;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.E) != 0)
            {
                int Xcoords = Cursor.Position.X;
                int Ycoords = Cursor.Position.Y;
                textBox1.Text = Xcoords.ToString();
                textBox2.Text = Ycoords.ToString();
            }
        }
    }
}
