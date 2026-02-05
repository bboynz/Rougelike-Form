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
        //Player
        public List<Item> heldItems = new List<Item>();


        //Items
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

         

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm();
            shopForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();

        }
    }
}
