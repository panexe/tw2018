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
        public int screen_boarder_left { get; set; }
        public int screen_boarder_right { get; set; }
        public int screen_boarder_down { get; set; }
        public int screen_boarder_up { get; set; }
        public int right { get; set; }
        public int left { get; set; }
        public int up { get; set; }
        public int down { get; set; }

        public Player(int _speed, int sizex , int sizey , Brush _brush, int _screenboarder_right, int _screenboarder_left, int _boarder_up, int _boarder_down)
        {
            speed = _speed;
            Position = new Vector2(400, 400);
            velocity = new Vector2(0, 0);
            brush = _brush;
            screen_boarder_right = _screenboarder_right;
            screen_boarder_left = _screenboarder_left;
            screen_boarder_up = _boarder_up;
            screen_boarder_down = _boarder_down;

            hitbox = new Rectangle(new Point(Position.x, Position.y), new Size(sizex, sizey));
            update(new Vector2(0,0));
        }

        public void draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(brush,hitbox);

        }

        public void update(Vector2 _velocity)
        {
            right = this.Position.x + this.hitbox.Width;
            left = this.Position.x;
            up = this.Position.y;
            down = this.Position.y + this.hitbox.Height;
            velocity = _velocity;

            hitbox = new Rectangle(new Point(Position.x, Position.y), hitbox.Size);
        }

        public void move()
        {
            if(this.right <= screen_boarder_right && this.left >= screen_boarder_left)
                Position = new Vector2(Position.x + velocity.x, Position.y);

            if(this.up >= screen_boarder_up && this.down <= screen_boarder_down)
                Position = new Vector2(Position.x, Position.y + velocity.y);

        }
    }
}
