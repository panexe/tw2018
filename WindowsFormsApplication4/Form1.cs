using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public int points { get; set; }

        Game game;
        public bool key_left{ get; set; }
        public bool key_right { get; set; }
        public bool key_down { get; set; }
        public bool key_up { get; set; }

        public int interval_factor { get; set; }
        public int interval { get; set; }
        public long tss { get; set; }
        public Stopwatch shots_timer { get; set; }

        bool button_start;

        public Form1()
        {
            points = 0;

            InitializeComponent();

            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);

            game = new Game(this.Top, this.Bottom, this.Right,this.Left);
           gametimer.Start();

            key_down = false;
            key_left = false;
            key_right = false;
            key_up = false;

            interval_factor = 2;

            shots_timer = new Stopwatch();
            shot_timer.Start();

            tss = 0;
            interval = 100;

            button_start = false;


        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            
                // Screen updaten 
                screen.Invalidate();

                game.tick();

                game.newShot();
            
            


        }
        public void stop_timers()
        {
            shot_timer.Stop();
        }

        private void screen_Paint(object sender, PaintEventArgs e)
        {
            game.draw(e);

            typeof(Panel).InvokeMember("DoubleBuffered",
    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
    null, screen, new object[] { true });
        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            // Screen updaten 
            screen.Invalidate();

            game.tick();

            if (game.hit)
            {
                gametimer.Stop();
                timer1.Stop();
                timer2.Stop();
                shots_timer.Stop();

                btn_restart.Enabled = true;
                btn_restart.Visible = true;
            }
            

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && !key_right )
            {
                game.velocity = new Vector2(-5, game.velocity.y);
                key_left = true;
            }
            else if(e.KeyCode == Keys.Right && !key_left)
            {
                game.velocity = new Vector2(5, game.velocity.y);
                key_right = true;

            }
            if( e.KeyCode == Keys.Up && !key_down)
            {
                game.velocity = new Vector2(game.velocity.x, -5);
                key_up = true;
            }
            else if(e.KeyCode == Keys.Down && !key_up)
            {
                game.velocity = new Vector2(game.velocity.x, 5);
                key_down = true;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                game.velocity = new Vector2(0, game.velocity.y);
                key_left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                game.velocity = new Vector2(0, game.velocity.y);
                key_right = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                game.velocity = new Vector2(game.velocity.x, 0);
                key_up = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                game.velocity = new Vector2(game.velocity.x, 0);
                key_down = false;

            }
        }

        private void shot_timer_Tick(object sender, EventArgs e)
        {
            
                if (shot_timer.Interval > 50)
                    //shot_timer.Interval = Convert.ToInt32( 100 / Math.Pow(interval_factor, 0.8*interval_factor) * 4);


                    game.newShot();
                //if(shot_timer.Interval > 50)
                //shot_timer.Interval -= 30;
            
                
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            points++;
            interval_factor += 1;

            label1.Text = points.ToString();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
