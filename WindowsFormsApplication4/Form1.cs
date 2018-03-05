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
        
        
        public Form1()
        {
            

            InitializeComponent();
            game = new Game(this.Top, this.Bottom, this.Right);
           gametimer.Start();

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
    }
}
