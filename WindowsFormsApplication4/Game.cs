using System;
using System.Collections.Generic;
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

        Vector2 velocity;
        Random random;

        List<Shot> shots;
        public Player player { get; set; }

        int screenboarder_top;
        int screenboarder_bottom;
        int screenboarder_right;

        public Game(int _boarder_top, int _boarder_bottom, int _boarder_right)
        {


            screenboarder_top = _boarder_top;
            screenboarder_bottom = _boarder_bottom;
            screenboarder_right = _boarder_right;

            score = 0;
            hit = false;

            shots = new List<Shot>();
            player = new Player(5, 100, 100);
            

            
        }


        public void tick()
        {
            // Shots bewegen 
            foreach(Shot s in shots)
            {
                s.Move();
            }

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
                if(shots[i].Position.x + shots[i].hitbox.Width > player.Position.x +3)
                {
                    // Hört auf zu überprüfen wenn die objekte weiter links als der Spieler sind 
                    // um rechenleistung zu sparen
                    return false;
                }
                if (shots[i].hitbox.Contains(player.hitbox))
                {
                    return true;
                }


                i++;
                
            }
            return false;
        }

        public void newShot()
        {
            shots.Add(new Shot(screenboarder_top, screenboarder_bottom, 5, 0, 5, 0, screenboarder_right));
        }

        public void lost()
        {

        }
    }

    
}
