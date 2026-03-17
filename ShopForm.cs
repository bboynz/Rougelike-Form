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
        Panel infoPanel = new Panel();

        public MainForm.Player Player = new MainForm.Player();
        public ShopForm shopForm;

        //Reference for chosen items
        List<MainForm.Item> showcasedItems = new List<MainForm.Item>();
        int stock = 3;

        //Music
        SoundPlayer bgMusic = new SoundPlayer(@"Media\Shop Music.wav");


        //___ITEM CODE___
        Random random = new Random();

        public static class ShopItems
        {
            static ItemBehaviour itemBehaviour = new ItemBehaviour();

            //Temp prob use file later
            static MainForm.Item snake = MainForm.InitializeItem("snake","animal","pattern", @"Media\PlaceHolder.jpg", price: 50, trigger: "generation", behaviour: itemBehaviour.Snake);
            static MainForm.Item worm = MainForm.InitializeItem("worm", "animal", "pattern", @"Media\PlaceHolder.jpg", price: 50, trigger: "generation", behaviour: itemBehaviour.Worm);
            static MainForm.Item gekoTail = MainForm.InitializeItem("geko's tail", "animal", "pattern", @"Media\PlaceHolder.jpg", price: 50, trigger: "click", behaviour: itemBehaviour.GekoTail);
            static MainForm.Item metronome = MainForm.InitializeItem("metronome", "music", "timing", @"Media\PlaceHolder.jpg", price: 50);
            static MainForm.Item swing = MainForm.InitializeItem("swing rhythm", "music", "timing", @"Media\PlaceHolder.jpg", price: 50, trigger: "tick", behaviour: itemBehaviour.Swing);
            static MainForm.Item presto = MainForm.InitializeItem("presto", "music", "timing", @"Media\PlaceHolder.jpg", price: 50);

            public static List<MainForm.Item> shopItemPool = new List<MainForm.Item> {snake, worm, gekoTail, metronome, swing, presto };

            public static int Amount = shopItemPool.Count();

            
        }



        //___FORM CODE___
        public ShopForm(MainForm.Player player)
        {
            InitializeComponent();

            Player = player;
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            infoPanel.Hide();

            Option_1.Hide();
            Option_2.Hide();
            Option_3.Hide();

            if (ShopItems.shopItemPool.Count() > 2)
            {
                Option_1.Show();
                Option_2.Show();
                Option_3.Show();

                RerollStock();
                
            }
            

            bgMusic.PlayLooping();

        }


        //___CONTROL CODE___
        public void InitializeItemInfoPanel(int X, int Y, int height, int width, MainForm.Item item)
        {
            infoPanel = new Panel();

            infoPanel.Location = new Point(X, (this.Height - height)-Y);
            infoPanel.Name = item.Name;
            infoPanel.Size = new Size(width, height);


            Label itemNameLabel = new Label();
            itemNameLabel.Location = new Point(10, 10);
            itemNameLabel.Size = new Size(100, 100);
            itemNameLabel.Font = new Font("Arial", 10);
            itemNameLabel.Text = item.Name;

            infoPanel.Controls.Add(itemNameLabel);

            Label itemInfoLabel = new Label();
            itemInfoLabel.Location = new Point(10, 25);
            itemInfoLabel.Size = new Size(200, 200);

            itemInfoLabel.Text = $" Tag: {item.Tag}\n Type {item.Type}\n Price: {item.Price}";

            infoPanel.Controls.Add(itemInfoLabel);
            this.Controls.Add(infoPanel);

            infoPanel.BringToFront();
            itemNameLabel.BringToFront();
            itemInfoLabel.BringToFront();

            infoPanel.Show();

            infoPanel.Visible = true;
        }

        private void Option_1_Click(object sender, EventArgs e)
        {
            if (showcasedItems[0] != null)
            {
                showcasedItems[0].Name = Option_1.Name;

                Player.heldItems.Add(showcasedItems[0]);
                //ShopItems.shopItemPool.Remove(showcasedItems[0]);
                showcasedItems.RemoveAt(0);
                

                Option_1.Hide();
            }
        }

        private void Option_2_Click(object sender, EventArgs e)
        {
            if (showcasedItems[1] != null)
            {
                showcasedItems[1].Name = Option_2.Name;

                Player.heldItems.Add(showcasedItems[1]);
                //ShopItems.shopItemPool.Remove(showcasedItems[0]);
                showcasedItems.RemoveAt(1);

                Option_2.Hide();
            }
        }

        private void Option_3_Click(object sender, EventArgs e)
        {
            if (showcasedItems[2] != null)
            {
                showcasedItems[2].Name = Option_3.Name;

                Player.heldItems.Add(showcasedItems[2]);
                //ShopItems.shopItemPool.Remove(showcasedItems[0]);
                showcasedItems.RemoveAt(2);

                Option_3.Hide();
            }
            
        }

        private void Option_1_MouseHover(object sender, EventArgs e)
        {
            if (showcasedItems[0] != null)
            {
                InitializeItemInfoPanel(X:0, Y:30, height: 120, width: 150, item: showcasedItems[0]);
            }
            
        }

        private void Option_2_MouseHover(object sender, EventArgs e)
        {
            if (showcasedItems[1] != null)
            {
                InitializeItemInfoPanel(X: 100, Y: 40, height: 120, width: 150, item: showcasedItems[1]);
            }
        }

        private void Option_3_MouseHover(object sender, EventArgs e)
        {
            if (showcasedItems[2] != null)
            {
                InitializeItemInfoPanel(X: 200, Y: 50, height: 120, width: 150, item: showcasedItems[2]);
            }
        }

        private void Option_1_MouseLeave(object sender, EventArgs e)
        {
            infoPanel.Hide();
        }

        private void Option_2_MouseLeave(object sender, EventArgs e)
        {
            infoPanel.Hide();
        }

        private void Option_3_MouseLeave(object sender, EventArgs e)
        {
            infoPanel.Hide();
        }

        private void RerollLabel_Click(object sender, EventArgs e)
        {
            RerollStock();
        }

        public void RerollStock()
        {
            //sets max based off the number of items in the shop pool
            int max = ShopItems.shopItemPool.Count - 1;

            //---Expantion item for more choices?---

            for (int i = stock; i >= 0; i--)
            {
                
                int num = random.Next(0, max);

                
                showcasedItems.Add(ShopItems.shopItemPool[num]);
                ShopItems.shopItemPool.Remove(showcasedItems.Last());

                max = ShopItems.shopItemPool.Count - 1;
            }

            //Because there are different options I hard code setting the images
            Option_1.Image = Image.FromFile(showcasedItems[0].Image);
            Option_2.Image = Image.FromFile(showcasedItems[1].Image);
            Option_3.Image = Image.FromFile(showcasedItems[2].Image);
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            //Ends all form tasks
            bgMusic.Stop();
            this.Hide();
            this.Dispose();
        }
    }
}
