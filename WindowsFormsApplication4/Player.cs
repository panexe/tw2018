using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    class Player
    {
        int speed;

        public Rectangle hitbox { get; set; }

        public Vector2 Position { get; set; }

        public Vector2 velocity { get; set; }

        Brush brush;

        public Player(int _speed, int sizex , int sizey , Brush _brush)
        {
            speed = _speed;
            Position = new Vector2(400, 400);
            velocity = new Vector2(0, 0);
            brush = _brush;

            hitbox = new Rectangle(new Point(Position.x, Position.y), new Size(sizex, sizey));

        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brush,hitbox);
        }
    }
}
