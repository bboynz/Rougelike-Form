using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rougelike
{
    public partial class MainForm: Form
    {
        //this is the main instance that will be used through the program
        Player player = new Player();

        Level selectedLevel = new Level();

        //___PLAYER CODE___
        public class Player
        {
            public string Username { get; set; }
            public List<Item> heldItems = new List<Item>();
        }

        public class Level
        {
            public int Difficulty;//this will define the tempo and base pacing
            public int tempo;

            public List<string> tags = new List<string>();

            public string Name;
        }
        
        private Player InitializePlayer(string username)
        {
            //Sets up player
            Player player = new Player();
            player.Username = username;


            return player;
        }

        private Level InitializeLevel(int difficulty, string name)
        {
            Level level = new Level();

            level.Difficulty = difficulty;
            level.Name = name;

            //tempo is measured in BPM
            level.tempo = ((2 ^ level.Difficulty) / 4) * 60; 


            return level;
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
            selectedLevel = InitializeLevel(1, "Base level");
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
            LevelButton.BackColor = Color.RosyBrown;
            

            selectedLevel = InitializeLevel(4, "bob's house");

            levelNameLabel.Text = selectedLevel.Name;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
