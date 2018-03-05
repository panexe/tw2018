﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        bool leftclick = false;
        bool rightclick = false;
        bool upclick = false;
        bool downclick = false;
        bool shotsfired = false;
        bool lost = false;
        int lastrandom = 0;
        List<PictureBox> shots = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lost == true)
            {
                for (int i = 0; i < shots.Count; i++)
                {
                    shots[i].Left += 5;

                    if (shots[i].Left >= player.Left && shots[i].Right <= player.Right)
                    {
                        if (shots[i].Top > player.Top && shots[i].Bottom < player.Bottom)
                        {
                            MessageBox.Show("Verloren");
                            timer1.Stop();
                            timer2.Stop();
                        }
                    }
                }
            }

            if (leftclick)
            {
                if(player.Left > panel1.Left)
                {
                    player.Left -= 3;
                }
            }
            if (rightclick)
            {
                if(player.Right < panel1.Right)
                {
                    player.Left += 3;
                }
                
            }
            if (upclick)
            {
                if(player.Top > panel1.Top)
                {
                    player.Top -= 3;
                }
                
            }
            if (downclick)
            {
                if(player.Bottom < panel1.Bottom)
                {
                    player.Top += 3;
                }
                
            }



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                leftclick = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                rightclick = true;
            }


            if (e.KeyCode == Keys.Up)
            {
                upclick = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                downclick = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if( e.KeyCode == Keys.Left)
            {
                leftclick = false;
            }
            if(e.KeyCode == Keys.Right)
            {
                rightclick = false;
            }


            if (e.KeyCode == Keys.Up)
            {
                upclick = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                downclick = false;
            }
        }

        private void shot()
        {
            shotsfired = true;
            Random r = new Random();
            PictureBox pictureBox2 = new PictureBox();

            int y = r.Next(panel1.Top, panel1.Bottom);
            if(y +10 > lastrandom)
            {
            pictureBox2.Location = new System.Drawing.Point(0,y);
            }
            if (y - 10 < lastrandom)
            {
                pictureBox2.Location = new System.Drawing.Point(0, y);
            }
            else {
             y = r.Next(panel1.Top, panel1.Bottom);
            
                pictureBox2.Location = new System.Drawing.Point(0, y);
            }
            lastrandom = pictureBox2.Top;
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(30,3);
            pictureBox2.BackColor = Color.Black;
            pictureBox2.Visible = true;
            panel1.Controls.Add(pictureBox2);
            shots.Add(pictureBox2);
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lost = true)
            {
                if (shotsfired == false)
                {
                    shot();
                }
                if (shots[0].Right >= panel1.Right)
                {
                    shots[0].Dispose();
                    shotsfired = false;

                }
            }
            

        }


    }
}
