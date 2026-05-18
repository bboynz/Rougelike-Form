using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rougelike
{
    public partial class ShopForm: Form
    {
        //The information panel to inform the player
        Panel infoPanel = new Panel();

        //References to the player, and to the main form
        public MainForm.Player Player = new MainForm.Player();
        public MainForm mainForm;

        //Reference for chosen items and the pool of items
        List<MainForm.Item> showcasedItems = new List<MainForm.Item>();
        List<MainForm.Item> shopPool = ShopItems.shopItemPool;
        //How many items that are stocked
        int stock = 3;

        //Music
        SoundPlayer bgMusic = new SoundPlayer(@"Media\Shop Music.wav");


        //___ITEM CODE___
        Random random = new Random();

        //A list of the items that are in the shop
        public static class ShopItems
        {
            //rdference to the item behavour script where I store the functions
            static ItemBehaviour itemBehaviour = new ItemBehaviour();

            //I initialize all the items and add them to the item
            static MainForm.Item snake = MainForm.InitializeItem("snake","animal","pattern", @"Media\snake.png", price: 50, trigger: "generation", behaviour: itemBehaviour.Snake, mult: 0.1);
            static MainForm.Item worm = MainForm.InitializeItem("worm", "animal", "pattern", @"Media\worm.png", price: 50, trigger: "generation", behaviour: itemBehaviour.Worm, mult: 0.2);
            static MainForm.Item gekoTail = MainForm.InitializeItem("geko's tail", "animal", "pattern", @"Media\geckoTail.png", price: 50, trigger: "click", behaviour: itemBehaviour.GekoTail, mult: 0.5);
            static MainForm.Item swing = MainForm.InitializeItem("swing rhythm", "music", "timing", @"Media\timing.png", price: 50, trigger: "tick", behaviour: itemBehaviour.Swing, mult: 0.2);
            static MainForm.Item presto = MainForm.InitializeItem("presto", "music", "timing", @"Media\timing.png", price: 50, trigger: "buy", behaviour: itemBehaviour.Presto, mult: 1);
            public static List<MainForm.Item> shopItemPool = new List<MainForm.Item> {snake, worm, gekoTail, swing, presto, presto};

            
        }



        //___FORM CODE___

        //The shop form
        public ShopForm(MainForm.Player player, MainForm mainForm)
        {
            InitializeComponent();

            Player = player;
            this.mainForm = mainForm;
        }

        //Runs on the shop form
        private void ShopForm_Load(object sender, EventArgs e)
        {
            //hides the panel
            infoPanel.Hide();

            //hides all the options
            Option_1.Hide();
            Option_2.Hide();
            Option_3.Hide();

            //updates the point label to show the player's point
            PointsLabel.Text = Player.Points.ToString();

            //if there is enough items it restocks the shop else it shows the no stock label
            if (shopPool.Count() > 2) { RerollStock();}
            else { NoStockLabel.Visible = true; RerollLabel.Hide(); }

            //starts the music
            bgMusic.PlayLooping();

        }


        //___CONTROL CODE___
        public void InitializeItemInfoPanel(int X, int Y, int height, int width, MainForm.Item item)
        {
            //hides the panel
            infoPanel = new Panel();

            //Sets the location based on the parameters
            infoPanel.Location = new Point(X, (this.Height - height)-Y);
            //Sets the name based on the parameters
            infoPanel.Name = item.Name;
            //Sets the size based on the parameters
            infoPanel.Size = new Size(width, height);

            //creates the name label 
            Label itemNameLabel = new Label();
            itemNameLabel.Location = new Point(10, 10);
            itemNameLabel.Size = new Size(100, 100);
            itemNameLabel.Font = new Font("Arial", 10);
            itemNameLabel.Text = item.Name;

            //adds the name label to the panel
            infoPanel.Controls.Add(itemNameLabel);

            //creates the information label
            Label itemInfoLabel = new Label();
            itemInfoLabel.Location = new Point(10, 25);
            itemInfoLabel.Size = new Size(200, 200);

            //sets the text
            itemInfoLabel.Text = $" Tag: {item.Tag}\n Type {item.Type}\n Price: {item.Price}";

            //adds the information label
            infoPanel.Controls.Add(itemInfoLabel);
            //adds the panel to the shop form
            this.Controls.Add(infoPanel);

            //brings important information to the front
            infoPanel.BringToFront();
            itemNameLabel.BringToFront();
            itemInfoLabel.BringToFront();

            //shows the GUI
            infoPanel.Show();
            infoPanel.Visible = true;
        }

        //Event called on the first option picture box clicked
        private void Option_1_Click(object sender, EventArgs e)
        {
            if (showcasedItems[0] != null) // so it doesn't run if there is no item
            {

                if (Player.Points >= showcasedItems[0].Price)// Checks if the player has enough points to but the item
                {
                    Player.Points -= showcasedItems[0].Price;//takes away points from player using reference
                    //Updates the gui
                    showcasedItems[0].Name = Option_1.Name;
                    PointsLabel.Text = Player.Points.ToString();
                    //adds item to the player 
                    Player.heldItems.Add(showcasedItems[0]);
                    shopPool.Remove(showcasedItems[0]);
                    //showcasedItems.RemoveAt(0);

                    //hides the picture
                    Option_1.Hide();

                    //Checks if item is triggered on purchase
                    if (showcasedItems[0].Trigger == "buy")
                    {
                        showcasedItems[0].Behaviour(null, Player);
                    }

                }
                
            }
        }

        //Event called on the first option picture box clicked
        private void Option_2_Click(object sender, EventArgs e)
        {
            

            if (showcasedItems[1] != null)// so it doesn't run if there is no item
            {
                if (Player.Points >= showcasedItems[1].Price)// Checks if the player has enough points to but the item
                {
                    Player.Points -= showcasedItems[1].Price;//takes away points from player using reference
                    //Updates the gui
                    showcasedItems[1].Name = Option_2.Name;
                    PointsLabel.Text = Player.Points.ToString();
                    //adds item to the player 
                    Player.heldItems.Add(showcasedItems[1]);
                    shopPool.Remove(showcasedItems[1]);
                    //showcasedItems.RemoveAt(1);

                    //hides the picturebox

                    Option_2.Hide();

                    //Checks if item is triggered on purchase
                    if (showcasedItems[1].Trigger == "buy")
                    {
                        showcasedItems[1].Behaviour(null, Player);
                    }
                }
            }
        }

        //Event called on the first option picture box clicked
        private void Option_3_Click(object sender, EventArgs e)
        {
            if (showcasedItems[2] != null)// so it doesn't run if there is no item
            {
                if (Player.Points >= showcasedItems[2].Price)// Checks if the player has enough points to but the item
                {
                    Player.Points -= showcasedItems[2].Price;//takes away points from player using reference
                    //Updates the gui

                    showcasedItems[2].Name = Option_3.Name;
                    PointsLabel.Text = Player.Points.ToString();
                    //adds item to the player 
                    Player.heldItems.Add(showcasedItems[2]);
                    shopPool.Remove(showcasedItems[2]);
                    //showcasedItems.RemoveAt(2);

                    //hides the picturebox
                    Option_3.Hide();

                    //Checks if item is triggered on purchase
                    if (showcasedItems[2].Trigger == "buy")
                    {
                        showcasedItems[2].Behaviour(null, Player);
                    }
                }
            }
            
        }

        //Event called on the first option picture box hovered over
        private void Option_1_MouseHover(object sender, EventArgs e)
        {
            if (showcasedItems[0] != null)// so it doesn't run if there is no item
            {
                InitializeItemInfoPanel(X:0, Y:30, height: 120, width: 150, item: showcasedItems[0]);//creates the info panel
            }
            
        }
        //Event called on the first option picture box hovered over
        private void Option_2_MouseHover(object sender, EventArgs e)
        {
            if (showcasedItems[1] != null)// so it doesn't run if there is no item
            {
                InitializeItemInfoPanel(X: 100, Y: 40, height: 120, width: 150, item: showcasedItems[1]);//creates the info panel
            }
        }
        //Event called on the first option picture box hovered over
        private void Option_3_MouseHover(object sender, EventArgs e)
        {
            if (showcasedItems[2] != null)// so it doesn't run if there is no item
            {
                InitializeItemInfoPanel(X: 200, Y: 50, height: 120, width: 150, item: showcasedItems[2]);//creates the info panel
            }
        }
        //Event called on the first option picture box leaves area
        private void Option_1_MouseLeave(object sender, EventArgs e)
        {
            infoPanel.Hide();//hides the info panel
        }
        //Event called on the first option picture box leaves area
        private void Option_2_MouseLeave(object sender, EventArgs e)
        {
            infoPanel.Hide();//hides the info panel
        }
        //Event called on the first option picture box leaves area
        private void Option_3_MouseLeave(object sender, EventArgs e)
        {
            infoPanel.Hide();//hides the info panel
        }
        //Event called on the first option picture box clicked
        private void RerollLabel_Click(object sender, EventArgs e)
        {
            RerollStock();//restock/rerolls the shop
        }

        //A function to reroll/restock the items in the shop
        public void RerollStock()
        {
            //Resets the list
            showcasedItems = new List<MainForm.Item>();

            //Makes the items visible
            Option_1.Show();
            Option_2.Show();
            Option_3.Show();

            //Gets new seed for random
            random = new Random();

            //sets max based off the number of items in the shop pool
            int max = shopPool.Count - 1;
            
            //---Expantion item for more choices?---

            for (int i = 1; i <= stock; i++)
            {
                //chooses random if possible
                int num = 0;
                if (max != 0)
                {
                    num = random.Next(0, max);
                }
                
                //item reference
                MainForm.Item item = shopPool[num];

                //swaps the item around
                showcasedItems.Add(item);
                shopPool.Remove(item); // If I want to make it so items only show once in shops

                //recalculates the max amount
                max = shopPool.Count - 1;
            }

            //Because there are different options I hard code setting the images
            Option_1.Image = Image.FromFile(showcasedItems[0].Image);
            Option_2.Image = Image.FromFile(showcasedItems[1].Image);
            Option_3.Image = Image.FromFile(showcasedItems[2].Image);

            //Makes it impossible to break by trying to reroll when impossible
            if (shopPool.Count() < 3) {RerollLabel.Hide();}
            else { RerollLabel.Show();}
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            //Ends all form tasks
            bgMusic.Stop();
            this.Hide();
            this.Close();
            this.Dispose();
        }

        private void ShopForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //stops the music
            bgMusic.Stop();
            //updates the gui in the mainform incase a item that changes level info was bought.
            mainForm.UpdateLevelGUI();
            mainForm.selectedLevel.levelButton.PerformClick();
        }
    }
}
