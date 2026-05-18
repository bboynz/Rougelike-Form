using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rougelike
{
    public partial class MainForm: Form
    {
        //___REFERENCES__   //these are the main instances that will be used through the program

        Player player = new Player(); // refrence for the player informatiom

        public Level selectedLevel = new Level(); // reference for the level that the payer has selected

        public List<Level> Levels = new List<Level>(); // A reference for all the lists in the menu

        //___PLAYER CODE___
        public class Player //class to store information about the player
        {
            public string Username;//tracks the player username
            public List<Item> heldItems = new List<Item>();//a list of the items the player has

            public int Points;//tracks how many points the player has
            public double Multiplier = 1;//multiplys the points gained from completeing levels
            public bool Presto = false;//tracks if presto is enabled
        }

        public class Level //class to store information about the levels
        {
            //the gui of the level
            public Button levelButton = new Button();


            public int Difficulty;//this will define the tempo and base pacing
            public int tempo;//the tempo of the level
            public int Length;//how many buttons spawn/cycles happen

            public List<string> Tags = new List<string>();//a list of tags used to check if the level has a tag

            public string Name;//name of the level


            private string image;//used by the setter getter to set the image
            public string ButtonImage //automaticly sets button image
            {
                get { return image; }
                set {
                    image = value;
                    levelButton.BackgroundImage = Image.FromFile(image);
                }
            }

            //the id to organize and render the gui
            public int ID;
            //incase I want to lock the level
            public bool locked;

        }

        //___ITEM CODE___
        public class Item
        {
            public string Name;//name of the item
            public string Tag;//information tag of the item
            public string Type;//the type of item
            public int Price;//how much the item costs
            public string Trigger;//when the item is triggered
            public double addedMult;//how much mult it adds to the player

            public string Image;//the path to the image for the item
            public Action<GameForm, object> Behaviour;// the method that is called for the item

        }

        private Player InitializePlayer(string username)
        {
            //Sets up player
            Player player = new Player();
            player.Username = username;


            return player;
        }
        //creates a object of the level class
        private Level InitializeLevel(int difficulty, string name, string path, int id, int length, List<string> tags = null)
        {
            //Creates a new level class and a button for the gui
            Level level = new Level();
            Button levelButton = level.levelButton;

            //sets the level's variables from the parameters
            level.Difficulty = difficulty;
            level.Name = name;
            level.ID = id;
            level.Length = length;
            level.Tags = tags;

            //tempo is measured in BPM so calculates it
            double num1 = 2 * level.Difficulty;
            num1 = num1 / 4;
            num1 = num1 * 60;

            level.tempo = (int)num1;


            //Button Setup based of the level path
            levelButton.Width = 100;
            levelButton.Height = 50;
            levelButton.Padding = new Padding(3,2,3,2);
            levelButton.Name = name+"_Button";
            levelButton.BackColor = Color.White;
            levelButton.Cursor = Cursors.Cross;
            levelButton.Anchor = AnchorStyles.None;
            levelButton.BackgroundImageLayout = ImageLayout.Zoom;


            levelButton.Location = new Point(((this.Width / 2) - levelButton.Width), ((this.Height / 2) - levelButton.Height));

            level.ButtonImage = path;

            //connects all the events
            levelButton.Click += new System.EventHandler(this.LevelButton_Click);
            levelButton.MouseHover += new System.EventHandler(this.LevelButton_MouseHover);
            levelButton.MouseLeave += new System.EventHandler(this.LevelButton_MouseLeave);

            //makes the level button visible
            levelButton.Visible = true;
            this.Controls.Add(levelButton);
            levelButton.BringToFront();

            //adds the level to level lists
            Levels.Add(level);


            UpdateLevelGUI();//updates all the gui

            //returns the level
            return level;
        }
        //creates and returns a object of the item class
        public static Item InitializeItem(string name, string tag, string type, string image, int price = 0, Action<GameForm, object> behaviour = null, string trigger = "", double mult = 0)
        {
            //creates the object
            Item item = new Item();

            //sets all the item variables
            item.Name = name;
            item.Tag = tag;
            item.Type = type;
            item.Price = price;
            item.Trigger = trigger;

            item.Image = image;

            item.addedMult = mult;

            item.Behaviour = behaviour;


            //returns the object of the item class
            return item;
        }

        //used to update the gui
        public void UpdateLevelGUI()
        {
            //used to keep track of the last id
            int lastId = -1;
            Level lastLevel = null;
            foreach (Level level in Levels)
            {
                Button levelButton = level.levelButton;

                //so that the buttons are spaced out with id being less going under and id's that are more being over

                int middleX = (this.Width / 2) - levelButton.Width;
                int middleY = (this.Height / 2) - levelButton.Height;

                int y;

                

                y = (level.ID - selectedLevel.ID);
                //MessageBox.Show("Y = " + y.ToString());
                int num1 = (levelButton.Height);
                //MessageBox.Show("num1 = " + num1.ToString());
                y = num1 * y;
                //MessageBox.Show("Y = " + y.ToString());
                y = middleY - y;
                //MessageBox.Show("Y = " + y.ToString());

                //if they have the same id
                if (lastId == level.ID)
                {
                    lastLevel.levelButton.Location = new Point(middleX - (lastLevel.levelButton.Width/2), lastLevel.levelButton.Location.Y);
                    middleX += levelButton.Width/2;
                }

                //a reference to the last position then moves the button to the desegnated position based off the selected 
                Point finalPos = new Point(middleX, y);
                PointLerp(levelButton.Location, finalPos, 10, levelButton);

                


                //move gui to front

                selectedLevelLabel.BringToFront();
                levelNameLabel.BringToFront();
                LevelInfoLabel.BringToFront();
                pointLabel.BringToFront();

                //Updating the point label
                pointLabel.Text = "points: " + player.Points.ToString();

                //updates the lastID and level
                lastId = level.ID;
                lastLevel = level;
            }
        }
         

        //___FORM CODE___
        public MainForm(string username)
        {
            //creates the player
            InitializeComponent();
            player = InitializePlayer(username); //sets up the player instance
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //initialize the levels and select the first level
            selectedLevel = InitializeLevel(2, "Beach", @"media\beachLevel.png", 0, 20);
            selectedLevel.levelButton.PerformClick();

            InitializeLevel(2, "Park", @"media\parkLevel.png", id: 1, 30);
            InitializeLevel(2, "Beach level 2", @"media\beachLevel.png", id: 2, 20);
            InitializeLevel(3, "Park level 2", @"media\parkLevel.png", id: 2, 30);
            InitializeLevel(4, "Beach level 3", @"media\beachLevel.png", id: 3, 40);
            InitializeLevel(5, "Park Level 3", @"media\parkLevel.png", id: 4, 60);
            
        }



        //___CONTROL CODE___
        private void ShopButton_Click(object sender, EventArgs e)
        {
            //Creates and opens a shop form, also sends over a reference to the player
            ShopForm shopForm = new ShopForm(player, this);
            shopForm.Show();
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            //Creates and opens a game form, and sends over a reference to the player the the current level
            GameForm gameForm = new GameForm(player, selectedLevel, this);
            gameForm.Show();
            this.Hide();

        }
        private void LevelButton_Click(object sender, EventArgs e)
        {
            Button levelButton = (Button)sender; //gets referecne from object that triggdred event

            Level level = new Level();//creates a level reference

            foreach(Level i in Levels) //finds the assoiated level
            {
                if (i.levelButton == levelButton)
                {
                    level = i;
                }
            }

            

            //Changes selected visual so user has visual indecation
            selectedLevel.levelButton.BackColor = Color.White;
            levelButton.BackColor = Color.RosyBrown;

            selectedLevel = level;//sets the level reference

            UpdateLevelGUI();//updates the gui based of the selected level

            levelNameLabel.Text = selectedLevel.Name;

            //checks if presto is enabled so that it updates the gui accordingly
            if (!player.Presto)
            {
                LevelInfoLabel.Text = $"Difficulty: {level.Difficulty} (BPM:{level.tempo}, {Math.Round((double)(60.0 / level.tempo), 2)} per second)";
            }
            else
            {
                LevelInfoLabel.Text = $"Difficulty: {level.Difficulty*2} (BPM:{level.tempo*2}, {Math.Round((double)(60.0 / level.tempo*2), 2)} per second)";
            }


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {//ends the game when the main form is closed
            Application.Exit();
        }

        private void LevelButton_MouseHover(object sender, EventArgs e)
        {
            //for when the button is hovered over
            Button button = (Button)sender;//sets the reference type
            button.BackColor = Color.GhostWhite;

        }

        private void LevelButton_MouseLeave(object sender, EventArgs e)
        {
            //sets reference type
            Button button = (Button)sender;

            //updates the back colour when the mouse leaves
            if(button == selectedLevel.levelButton)
            {
                button.BackColor = Color.RosyBrown;
            }
            else
            {
                button.BackColor = Color.White;
            }

        }



        //___MATH CODE___
        
        public void PointLerp(Point startPoint, Point finalPoint, int steps, Control control)
        {
            //Sets the base point
            int X = startPoint.X;
            int Y = startPoint.Y;

            int stepX = Math.Abs(startPoint.X - finalPoint.X)/steps;
            
            int stepY = Math.Abs(startPoint.Y - finalPoint.Y)/steps;



            for(int i = steps; i <= 0; i--) //loops for number of steps then stops at the end point to give illusion of clean animation
            {
                //MessageBox.Show($"X:{X}, Y:{Y}. Final Point is ({finalPoint.X}, {finalPoint.Y}");

                control.Location = new Point(X, Y);

                X += stepX;
                Y += stepY;

                //Thread.Sleep(100);
            }
            
            control.Location = new Point(finalPoint.X, finalPoint.Y);

        }
    }
}
