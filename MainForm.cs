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

        Player player = new Player();

        Level selectedLevel = new Level();

        List<Level> Levels = new List<Level>();

        //___PLAYER CODE___
        public class Player
        {
            public string Username { get; set; }
            public List<Item> heldItems = new List<Item>();
        }

        public class Level
        {
            public Button levelButton = new Button();


            public int Difficulty;//this will define the tempo and base pacing
            public int tempo;
            public int Length;

            public List<string> tags = new List<string>();

            public string Name;


            private string image;
            public string ButtonImage //automaticly sets button image
            {
                get { return image; }
                set {
                    image = value;
                    levelButton.BackgroundImage = Image.FromFile(image);
                }
            }

            private int id;
            public int ID 
            {
                get { return id; }
                set { id = value; }
            }

            public bool unlocked;

        }
        
        private Player InitializePlayer(string username)
        {
            //Sets up player
            Player player = new Player();
            player.Username = username;


            return player;
        }

        private Level InitializeLevel(int difficulty, string name, string path, int id, int length)
        {

            Level level = new Level();
            Button levelButton = level.levelButton;

            level.Difficulty = difficulty;
            level.Name = name;
            level.ID = id;
            level.Length = length;

            //tempo is measured in BPM
            double num1 = 2 * level.Difficulty;
            num1 = num1 / 4;
            num1 = num1 * 60;

            level.tempo = (int)num1;


            //Button Setup
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


            levelButton.Click += new System.EventHandler(this.LevelButton_Click);
            levelButton.MouseHover += new System.EventHandler(this.LevelButton_MouseHover);
            levelButton.MouseLeave += new System.EventHandler(this.LevelButton_MouseLeave);

            levelButton.Visible = true;
            this.Controls.Add(levelButton);
            levelButton.BringToFront();

            Levels.Add(level);


            UpdateLevelGUI(); //could use task.run() 

            return level;
        }

        private void UpdateLevelGUI()
        {
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


                Point finalPos = new Point(middleX, y);
                PointLerp(levelButton.Location, finalPos, 10, levelButton);

                //move gui to front

                selectedLevelLabel.BringToFront();
                levelNameLabel.BringToFront();
                LevelInfoLabel.BringToFront();
                
            }
        }


        //___ITEM CODE___
        public class Item
        {
            public string Name;
            public string Tag;

            public string Image;
        }

        public static Item InitializeItem(string name, string tag, string type, string image)
        {
            Item item = new Item();

            item.Name = name;
            item.Tag = tag;
            

            item.Image = image;

            return item;
        }

         

        //___FORM CODE___
        public MainForm(string username)
        {
            InitializeComponent();
            player = InitializePlayer(username); //sets up the player instance
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            selectedLevel = InitializeLevel(1, "Base level", @"media\LevelPlaceHolder.jpg", 0, 20);
            selectedLevel.levelButton.PerformClick();

            InitializeLevel(2, "level 2", @"media\LevelPlaceHolder.jpg", 1, 20);
            InitializeLevel(3, "level 3", @"media\LevelPlaceHolder.jpg", 2, 30);
            InitializeLevel(4, "level 4", @"media\LevelPlaceHolder.jpg", 3, 40);
            InitializeLevel(5, "level 5", @"media\LevelPlaceHolder.jpg", 4, 60);
            InitializeLevel(6, "level 6", @"media\LevelPlaceHolder.jpg", 5, 80);
            InitializeLevel(7, "level 7", @"media\LevelPlaceHolder.jpg", 6, 100);
            InitializeLevel(8, "level 8", @"media\LevelPlaceHolder.jpg", 7, 150);
        }



        //___CONTROL CODE___
        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm(player);
            shopForm.Show();
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(player,selectedLevel);
            gameForm.Show();

        }
        private void LevelButton_Click(object sender, EventArgs e)
        {
            Button levelButton = (Button)sender; //gets referecne from object that triggdred event

            Level level = new Level();

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

            selectedLevel = level;

            UpdateLevelGUI();

            levelNameLabel.Text = selectedLevel.Name;
            LevelInfoLabel.Text = $"Difficulty: {level.Difficulty} (BPM:{level.tempo}, {Math.Round((double)(60.0/level.tempo), 2)} per second)";

            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LevelButton_MouseHover(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            //button.BackColor = Color.GhostWhite;

        }

        private void LevelButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;

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
