using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class Shot
    {
        int velocity_max_X;
        int velocity_max_Y;

        int velocity_min_X;
        int velocity_min_Y;

        Rectangle hitbox { get; set; }
        public Vector2 velocity { get; set; }
        public Vector2 Position { get; set; }
        Random random;

        public Shot(int _posy, int _velmax_X, int _velmax_Y, int _velmin_X, int _velmin_Y)
        {
            velocity_max_X = _velmax_X;
            velocity_max_Y = _velmax_Y;

            velocity_min_X = _velmin_X;
            velocity_min_Y = _velmin_Y;

            Position = new Vector2(-10, _posy);
            hitbox = new Rectangle(new Point(Position.x,Position.y), new Size(random.Next(10, 20), 20));

            velocity = new Vector2(
                random.Next( velocity_min_X,velocity_max_X), 
                random.Next(velocity_min_Y, velocity_max_Y));



        }

        public void Move()
        {
            Position = new Vector2(Position.x + velocity.x, Position.y + velocity.y);

        }


    }
}
