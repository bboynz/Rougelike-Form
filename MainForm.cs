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

        //___PLAYER CODE___
        public class Player
        {
            public string Username { get; set; }
            public List<Item> heldItems = new List<Item>();
        }
        
        private Player InitializePlayer(string username)
        {
            //Sets up player
            Player player = new Player();
            player.Username = username;


            return player;
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

        }



        //___CONTROL CODE___
        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm(player);
            shopForm.Show();
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm(player);
            gameForm.Show();

        }
    }
}
