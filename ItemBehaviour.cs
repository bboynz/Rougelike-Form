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
        int WormState;
        Point pastPoint = new Point();
        public int direction = 0;


        public void Presto(GameForm gameForm, object Player)
        {
            //sets the player presto bool to true
            Player player = (Player)Player;//sets player reference
            player.Presto = true;

        }
        public void Swing(GameForm gameForm, object timer)
        {
            //sets timer reference
            Timer tempoTimer = (Timer)timer;
            Level level = gameForm.level;

                //I use a 400:1600 ratio because it is still taking 2000 for every two beats

            if (swingState == 1) //Short interval (bum bum) (10% of 4/4)
            {
                //calculattes the swing timer to the ratio
                double timing = 60;
                timing = timing / level.tempo;
                timing = timing * 400;



                tempoTimer.Interval = (int)timing;

                swingState = 2; //continues cycle
            }
            else if (swingState == 2) //long interval (bum wait) (40% of 4/4)
            {
                //calculattes the swing timer to the ratio
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


            if (!button.Name.Contains("Copy"))
            {


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
                        if (ran == 1)//makes the buttons based off of the direction
                        {
                            button.Location = new Point(pastPoint.X + random.Next(size, size + 10), pastPoint.Y - random.Next(size, size + 100));
                        }
                        if (ran == 2)
                        {
                            button.Location = new Point(pastPoint.X - random.Next(size, size + 10), pastPoint.Y - random.Next(size, size + 100));
                        }
                        break;
                    //right
                    case 2://makes the buttons based off of the direction
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
                    case 3://makes the buttons based off of the direction
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
                    case 4://makes the buttons based off of the direction
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


                //sets the new past point
                pastPoint = button.Location;
            }
        }
        public void Worm(GameForm gameForm, object buttonRef)
        {
            Button button = (Button)buttonRef; //Geko tail only gets button
            //only happens if the button isn't a copy
            if (!button.Name.Contains("Copy"))
            {
                if (WormState == 0)//bases on the state sets the size to make it look like a up down effect
                {
                    int size = button.Size.Width;

                    button.Width = size;
                    button.Height = size;

                    WormState = 1;
                }
                else if (WormState == 1)//bases on the state sets the size to make it look like a up down effect
                {
                    int size = button.Size.Width;
                    size = size - (size / 4);

                    button.Width = size;
                    button.Height = size;

                    WormState = 2;
                }
                else if (WormState == 2)//bases on the state sets the size to make it look like a up down effect
                {
                    int size = button.Size.Width;
                    size = size / 2;

                    button.Width = size;
                    button.Height = size;

                    WormState = 3;
                }
                else if (WormState == 3)
                {
                    int size = button.Size.Width;
                    size = size - (size / 4);

                    button.Width = size;
                    button.Height = size;

                    WormState = 0;
                }
            }
            
        }
        public void GekoTail(GameForm gameForm, object buttonRef)
        {
            Button button = (Button)buttonRef; //Geko tail only gets button

            if (!button.Name.Contains("Copy"))//doesn't apply if the button is a copy/clone
            {
                int size = button.Size.Width;//sets the size reference
                size -= size / 8;//updates rhe size
                gameForm.InitializeButton(button.Location.X + size, button.Location.Y + size, size, button.BackColor,clone: true);//creates a lone button 

            }

            
        }
        
        //Obstacles

        //public void Bomb(GameForm gameForm, object buttonRef)
        //{
        //    random = new Random();
        //    int num = random.Next(1, 2);
        //    if (num == 1)
        //    {
                
        //        Button button = (Button)buttonRef;
        //        gameForm.InitializeButton(button.Location.X + 10, button.Location.Y, button.Width, Color.Red, bomb: true, clone: true);
        //        MessageBox.Show("Bomb!");

        //    }
        //}
    }
}
