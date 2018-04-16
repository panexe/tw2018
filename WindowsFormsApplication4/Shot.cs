using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    class Shot
    {
        int velocity_max_X;
        int velocity_max_Y;

        int velocity_min_X;
        int velocity_min_Y;

        int screen_boarder { get; set; }

        public int boarder_down { get; set; }
        public int boarder_up { get; set; }
        public bool offscreen { get; set; }

        public int right { get; set; }
        public int left { get; set; }

        public Rectangle hitbox { get; set; }
        public Vector2 velocity { get; set; }
        public Vector2 Position { get; set; }
        Random random;



        Brush brush;

        public Shot(int _boarder_up, int _boarder_down, int _velmax_X, int _velmax_Y, int _velmin_X, int _velmin_Y, int _screen_boarder, Brush _brush, Random r)
        {
            random = r;

            velocity_max_X = _velmax_X;
            velocity_max_Y = _velmax_Y;

            velocity_min_X = _velmin_X;
            velocity_min_Y = _velmin_Y;

            screen_boarder = _screen_boarder;

            boarder_up = _boarder_up;
            boarder_down = _boarder_down;

            offscreen = false;



            Position = new Vector2(-100, random.Next( boarder_up,boarder_down));
            hitbox = new Rectangle(new Point(Position.x,Position.y), new Size(random.Next(1,100), random.Next(5,20)));

            velocity = new Vector2(
                random.Next( velocity_min_X,velocity_max_X), 
                random.Next(velocity_min_Y, velocity_max_Y));

            brush = _brush;

            update();


        }

        public void Move()
        {
            Position = new Vector2(Position.x + velocity.x, Position.y + velocity.y);
            if(Position.x > screen_boarder)
            {
                offscreen = true;
            }
            hitbox = new Rectangle(new Point(Position.x, Position.y), hitbox.Size);
            update();
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brush, hitbox);
        }

        public void update()
        {
            right = this.Position.x + hitbox.Width;
            left = this.Position.x;

            if(this.left > screen_boarder)
            {
                offscreen = true;
            }
        }

    }
}
