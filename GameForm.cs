using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Rougelike.MainForm;

namespace Rougelike
{
    public partial class GameForm: Form
    {
     //CLASS REFERENCE
        // reference to the current selected level 
        public MainForm.Level level = new MainForm.Level();
        //reference to the player
        Player Player = new Player();
        //reference to the mainform
        MainForm mainForm;

     //BOOLS
        public bool loopGame; //If the game loop is running

     //INTS
        public int cycles; //How many cycles of button spawns should occur

            //progress tracking
        public int buttons = 0; 
            //how many points are added
        public int points = 0;

     
     //RANDOM
        //reference to a random
        Random random = new Random();

        //___FORM CODE___
        public GameForm(MainForm.Player player, MainForm.Level Level, MainForm mainform)
        {
            InitializeComponent();

            //sets the references based of the parameters
            level = Level;
            Player = player;
            mainForm = mainform;

            //connects the resize event to the GameForm_Resize method
            this.Resize += new EventHandler(GameForm_Resize);
        }
        
        //Runs when the form loads
        private void GameForm_Load(object sender, EventArgs e)
        {

            //starts the game loop when the form loads
            loopGame = true;

            //sets the cycles to the level length
            cycles = level.Length;
            //Initialize the progress bar gui
            progressCount.Text = $"{points}/{level.Length}";
            progressBar1.Maximum = level.Length;

            //uses await and async run and load GUI
            ExecuteGameLoop();




        }

        private void GameForm_Resize(object sender, EventArgs e)
        {

            //Goes through all active buttons to see if they are in the window boundries
            foreach (Button button in activeButtons)
            {
                CheckButtonLocation(button, button.Width);
            }

        }



        //___CONTROL CODE___
        //A reference to the current buttons in the form
        public List<Button> activeButtons = new List<Button>();

        public void InitializeButton(int X, int Y, int size, Color color, bool clone = false)
        { 
            //adds to the button int tracker
            buttons++;

            //creates a new button and adds it to the list of current buttons in the list
            Button button = new Button();
            activeButtons.Add(button);

            //Constant values
            button.Anchor = AnchorStyles.None;
            button.Text = "";
            button.Cursor = Cursors.Cross;

            //set values based of parameters
            button.Location = new Point(X - (size/2), Y - (size/2));
            button.Size = new Size(size, size);
            button.BackColor = color;

            //Sets the background image
            button.BackgroundImage = Image.FromFile(@"Media\PlasticBag.jpg");
            button.BackgroundImageLayout = ImageLayout.Zoom;

            //showing/adding the component
            button.Visible = true;
            this.Controls.Add(button);
            button.BringToFront();

            //Edge case protection
            this.Height = this.Height;
            this.Width = this.Width;


            //checks if the player has an item that triggers in the button generation by looking through the player item inventory stored in a list of items.
            if (Player.heldItems.Count() > 0)
            {
                foreach (Item item in Player.heldItems)
                {
                    if (item.Trigger == "generation")
                    {
                        item.Behaviour(this, button);
                    }

                }
            }

            //checks if the button is a clone
            if (clone)
            {
                buttons--;
                button.Name += " Copy";
            }

            //Connects the button's click event to the gameButton_Click method
            button.Click += new System.EventHandler(this.gameButton_Click);

            //checks if the button in within the game limits
            CheckButtonLocation(button, button.Width);
        }

        void gameButton_Click(object sender, EventArgs e)
        {
            //Gets reference to button by casting sender object as button
            Button button = (Button)sender;

            //For easy reference
            int size = button.Width;
            int X = button.Location.X + size / 2;
            int Y = button.Location.Y + size / 2;

            //gets rid of button
            button.Hide();
            button.Dispose();
            this.Controls.Remove(button);
            activeButtons.Remove(button);

            //So clones don't overload the progress bar
            if (!button.Name.Contains("Copy"))
            {
                //updates the points and buttons innt tracker
                buttons--;
                points++;

                //updates the progress 
                progressCount.Text = $"{points}/{level.Length}";
                progressBar1.Value = points;
            }
            

            //checks through the player list of items to see if they contain an item that triggers on the click
            if (Player.heldItems.Count() > 0)
            {
                foreach(Item item in Player.heldItems)
                {
                    if(item.Trigger == "click")
                    {
                        item.Behaviour(this, button);
                    }
                }
            }



            //Makes seperate button
            //InitializeButton(X + 50, Y + 50, size, button.BackColor);

            //Will add different cases if items are held and how to change button spawn in said case.


            //
        }

        private void CheckButtonLocation(Button button, int size)
        {

            //checks if button is in window boundaries for X axis, if it's not puts it in bounds
            if (button.Location.X > this.Width - (size * 1.5))
            {
                button.Location = new Point(this.Width - (size * 1 + (size / 2)), button.Location.Y);
            }
            if (button.Location.X < 0)
            {
                button.Location = new Point(0, button.Location.Y);
            }
            //checks if button is in window boundaries for Y axis, if it's not puts it in bounds
            if (button.Location.Y > this.Height - (size * 2.5))
            {
                button.Location = new Point(button.Location.X, this.Height - (size * 2 + (size / 3))); //Weird constant that makes the button skim the window boarder
            }
            if (button.Location.Y < 0)
            {
                button.Location = new Point(button.Location.X, 0);
            }
        }


        //___GAME CODE___

        private void ExecuteGameLoop()
        {
            //calculates the timing based off the levels tempo
            double timing = 60;
            timing = timing / level.tempo;
            timing = timing * 1000;

            //if the player has a presto
            if (Player.Presto)
            {
                timing *= 2;
            }

            

            //sets the interval then starts the timer
            tempoTimer.Interval = (int)timing; // dif 1 is 60/30 so will run every 2 seconds
            tempoTimer.Start();
     
        }

        public void EndGameLoop(object sender, EventArgs e)
        {
            //stops the game loop
            tempoTimer.Stop();
            this.Dispose();

            MessageBox.Show("Level Failed");
        }

        //private double SetTempo()
        //{
        //    double tempo;

        //    double num1 = 2 * level.Difficulty;

        //    num1 = num1 / 4;

        //    num1 = num1 * 60;


        //    tempo = num1;// 1 = every 2s (30BPM (0.5*60) ), 2 = every 1 second (60BPM (1*60) ), 3 = every 2/3 second (90 BPM (1.5*60) ), etc   

            
        //    return (tempo);
        //}

        private void tempoTimer_Tick(object sender, EventArgs e)
        {
            //checks if there is any cycles left if not stops the game loop
            if (cycles <= 0)
            {
                loopGame = false;
            }

            if (loopGame)
            {
                //checks through the player list of items to see if they contain an item that triggers on the timer tick
                if (Player.heldItems.Count() > 0)
                {
                    foreach (Item item in Player.heldItems)
                    {
                        if (item.Trigger == "tick")
                        {
                            item.Behaviour(this, sender);
                        }
                    }
                    //creates the button after
                    InitializeButton(random.Next(this.Width), random.Next(this.Height), 30, Color.Green);
                }
                else
                {
                    //creates a button
                    InitializeButton(random.Next(this.Width), random.Next(this.Height), 30, Color.Green);
                }
                
                //updates the cycles tracker
                cycles--;
            }
            else
            {
                if (buttons == 0){
                    //ends the timer
                    tempoTimer.Stop();

                    //adding and manipulatiing points
                    foreach(Item item in Player.heldItems)
                    {
                        //Adds to a total mult (maybe would be better to just mult by all items
                        Player.Multiplier += item.addedMult;
                    }
                    Player.Points += (int)(level.Length * Player.Multiplier);

                    //closing this form and showing the main form
                    mainForm.Show();
                    mainForm.UpdateLevelGUI();

                    this.Hide();
                    this.Dispose();
                }
                
            }

            
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {//ends the game when the main form is closed
            Application.Exit();
        }
    }
}
