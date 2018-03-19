using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public struct Vector2
    {
        public int x { get; set; }
        public int y { get; set; }

        public Vector2(int a, int b)
        {
            x = a;
            y = b;
        }
    }
    class Game
    {
        int score;
        bool hit;

        public Vector2 velocity { get; set; }
        Random random;

        List<Shot> shots;
        public Player player { get; set; }

        public int screenboarder_top { get; set; }
        public int screenboarder_bottom { get; set; }
        public int screenboarder_right { get; set; }
        public int screenboarder_left { get; set; }

        public Game(int _boarder_top, int _boarder_bottom, int _boarder_right, int _boarder_left)
        {


            screenboarder_top = _boarder_top;
            screenboarder_bottom = _boarder_bottom;
            screenboarder_right = _boarder_right;
            screenboarder_left = _boarder_left;

            score = 0;
            hit = false;

            shots = new List<Shot>();
            player = new Player(5, 100, 100, new SolidBrush(Color.Brown),screenboarder_right, screenboarder_left ,screenboarder_top,screenboarder_bottom);
            

            
        }


        public void tick()
        {
            // Shots bewegen 
            foreach(Shot s in shots)
            {
                s.Move();
            }

            
            // Spieler Bewegen
            player.update(velocity);
            player.move();
            // Kolision

            if(colision() == true)
            {
                lost();
            }
            
        }

        public bool colision()
        {
            // Kollision checken 
            for (int i = 0; i < shots.Count; i++)
            {
                if (shots[i].right > player.left +3 || shots[i].left < player.right +3)
                {
                    if (shots[i].hitbox.IntersectsWith(player.hitbox))
                    {
                        return true;
                    }
               }

                if (shots[i].offscreen == true)
                {
                    shots.Remove(shots[i]);
                }

                i++;
                
            }
            return false;
        }

        public void newShot()
        {
            shots.Add(new Shot(screenboarder_top, screenboarder_bottom, 5, 0, 5, 0, screenboarder_right,new SolidBrush(Color.Black)));
        }

        public void lost()
        {
           
            MessageBox.Show("loser");
        }

        public void draw(PaintEventArgs e)
        {

            foreach(Shot s in shots)
            {
                s.draw(e);
            }
            player.draw(e);
        }
    }

    
}
