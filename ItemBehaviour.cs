using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Rougelike.MainForm;

namespace Rougelike
{
    public class ItemBehaviour
    {
        Random random = new Random();

        //Swing
        int swingState = 1;

        //Snake
        Point pastPoint = new Point();
        public int direction = 0;

        

        public void Swing(GameForm gameForm, object timer)
        {
            
            Timer tempoTimer = (Timer)timer;
            Level level = gameForm.level;

                //I use a 400:1600 ratio because it is still taking 2000 for every two beats

            if (swingState == 1) //Short interval (bum bum) (10% of 4/4)
            {
                double timing = 60;
                timing = timing / level.tempo;
                timing = timing * 400;

                tempoTimer.Interval = (int)timing;

                swingState = 2; //continues cycle
            }
            else if (swingState == 2) //long interval (bum wait) (40% of 4/4)
            {
                double timing = 60;
                timing = timing / level.tempo;
                timing = timing * 1600;

                tempoTimer.Interval = (int)timing;

                swingState = 1; //continues cycle
            }
        }
        public void Snake(GameForm gameForm, object buttonRef)
        {
            //references
            random = new Random();
            Button button = (Button)buttonRef;
            int size = button.Size.Width;
            

            

            
            //limits
            if (pastPoint.Y < 20)//too up
            {
                direction = 4;
            }
            if (pastPoint.X < 20)//too left
            {
                direction = 2;
            }
            if (pastPoint.X > gameForm.Width - 50)//too right
            {
                direction = 3;
            }
            if (pastPoint.Y > gameForm.Height - 50)//too down
            {
                direction = 1;
            }
            


            //direction
            int ran = random.Next(1, 2);


            switch (direction) //For each direction it gets random for that direction displacement and a minimal displacement for the perpendicular direction
            {
                //up
                case 1:
                    if (ran == 1)
                    {
                        button.Location = new Point(pastPoint.X + random.Next(size, size + 10), pastPoint.Y - random.Next(size, size + 100));
                    }
                    if (ran == 2)
                    {
                        button.Location = new Point(pastPoint.X - random.Next(size, size + 10), pastPoint.Y - random.Next(size, size + 100));
                    }
                    break;
                //right
                case 2:
                    if (ran == 1)
                    {
                        button.Location = new Point(pastPoint.X + random.Next(size, size + 100), pastPoint.Y + random.Next(size, size + 10));
                    }
                    if (ran == 2)
                    {
                        button.Location = new Point(pastPoint.X + random.Next(size, size + 100), pastPoint.Y - random.Next(size, size + 10));
                    }
                    break;
                //left
                case 3:
                    if (ran == 1)
                    {
                        button.Location = new Point(pastPoint.X - random.Next(size, size + 100), pastPoint.Y + random.Next(size, size + 10));
                    }
                    if (ran == 2)
                    {
                        button.Location = new Point(pastPoint.X - random.Next(size, size + 100), pastPoint.Y - random.Next(size, size + 10));
                    }
                    break;
                //down
                case 4:
                    if (ran == 1)
                    {
                        button.Location = new Point(pastPoint.X + random.Next(size, size + 10), pastPoint.Y + random.Next(size, size + 100));
                    }
                    if (ran == 2)
                    {
                        button.Location = new Point(pastPoint.X - random.Next(size, size + 10), pastPoint.Y + random.Next(size, size + 100));
                    }
                    break;
            }



            pastPoint = button.Location;
        }
        public void Worm(GameForm gameForm, object buttonRef)
        {
            Button button = (Button)buttonRef; //Geko tail only gets button

            if (gameForm.WormState == 0)
            {
                int size = button.Size.Width;

                button.Width = size;
                button.Height = size;

                gameForm.WormState = 1;
            }
            else if (gameForm.WormState == 1)
            {
                int size = button.Size.Width;
                size = size - (size / 4);

                button.Width = size;
                button.Height = size;

                gameForm.WormState = 2;
            }
            else if (gameForm.WormState == 2)
            {
                int size = button.Size.Width;
                size = size / 2;

                button.Width = size;
                button.Height = size;

                gameForm.WormState = 3;
            }
            else if (gameForm.WormState == 3)
            {
                int size = button.Size.Width;
                size = size - (size / 4);

                button.Width = size;
                button.Height = size;

                gameForm.WormState = 0;
            }
            
        }
        public void GekoTail(GameForm gameForm, object buttonRef)
        {
            Button button = (Button)buttonRef; //Geko tail only gets button

            if (!button.Name.Contains("Copy"))
            {
                int size = button.Size.Width;
                size = size / 2;
                gameForm.InitializeButton(button.Location.X + size, button.Location.Y + size, size, button.BackColor,clone: true);

            }

            
        }
    }
}
