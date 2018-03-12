using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Game game;
        public bool key_left{ get; set; }
        public bool key_right { get; set; }
        public bool key_down { get; set; }
        public bool key_up { get; set; }


        public Form1()
        {
            

            InitializeComponent();

            this.MinimumSize = new Size(1000, 1000);
            this.MaximumSize = new Size(1000, 1000);

            game = new Game(this.Top, this.Bottom, this.Right,this.Left);
           gametimer.Start();

            key_down = false;
            key_left = false;
            key_right = false;
            key_up = false;

        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Screen updaten 
            screen.Invalidate();

            game.tick();

            game.newShot();


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

            game.newShot();

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
            else if( e.KeyCode == Keys.Up && !key_down)
            {
                game.velocity = new Vector2(game.velocity.y, -5);
                key_up = true;
            }
            else if(e.KeyCode == Keys.Down && !key_up)
            {
                game.velocity = new Vector2(game.velocity.y, 5);
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
            else if (e.KeyCode == Keys.Right)
            {
                game.velocity = new Vector2(0, game.velocity.y);
                key_right = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                game.velocity = new Vector2(game.velocity.y, 0);
                key_up = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                game.velocity = new Vector2(game.velocity.y, 0);
                key_down = false;

            }
        }
    }
}
