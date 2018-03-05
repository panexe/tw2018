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
            

            
        }


        public void tick()
        {
            // Shots bewegen 
            foreach(Shot s in shots)
            {
                s.Move();
            }

            int i = 0;
            // Kollision checken 
            while(shots[i].Position.x > )
        }

        public void newShot()
        {
            shots.Add(new Shot(screenboarder_top, screenboarder_bottom, 5, 0, 5, 0, screenboarder_right);
        }
    }

    
}
