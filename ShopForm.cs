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
        


        //Music
        SoundPlayer bgMusic = new SoundPlayer(@"Media\Shop Music.wav");


        //Item Generation
        Random random = new Random();

        public static class ShopItems
        {
            //Temp prob use file later
            static MainForm.Item snake = MainForm.InitializeItem("snake","animal","pattern", @"Media\PlaceHolder.jpg");
            static MainForm.Item worm = MainForm.InitializeItem("worm", "animal", "pattern", @"Media\PlaceHolder.jpg");
            static MainForm.Item gekoTail = MainForm.InitializeItem("geko's tail", "animal", "pattern", @"Media\PlaceHolder.jpg");
            static MainForm.Item metronome = MainForm.InitializeItem("metronome", "music", "timing", @"Media\PlaceHolder.jpg");
            static MainForm.Item swing = MainForm.InitializeItem("swing rhythm", "music", "timing", @"Media\PlaceHolder.jpg");
            static MainForm.Item presto = MainForm.InitializeItem("presto", "music", "timing", @"Media\PlaceHolder.jpg");

            public static List<MainForm.Item> shopItemPool = new List<MainForm.Item> {snake, worm, gekoTail, metronome, swing, presto };

            public static int Amount = shopItemPool.Count();

            
        }

        public ShopForm()
        {
            InitializeComponent();
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {
            //Reference for chosen items
            List<MainForm.Item> showcasedItems = new List<MainForm.Item>();
            
            int max = ShopItems.shopItemPool.Count-1;

            //---Expantion item for more choices?---

            showcasedItems.Add(ShopItems.shopItemPool[random.Next(0, max)]);
            showcasedItems.Add(ShopItems.shopItemPool[random.Next(0, max)]);
            showcasedItems.Add(ShopItems.shopItemPool[random.Next(0, max)]);

            max = showcasedItems.Count - 1;

            //Because there are different options I hard code setting the images
            Option_1.Image = Image.FromFile(showcasedItems[0].Image);
            Option_2.Image = Image.FromFile(showcasedItems[1].Image);
            Option_3.Image = Image.FromFile(showcasedItems[2].Image);

            bgMusic.PlayLooping();



        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Ends all form tasks
            bgMusic.Stop();
            this.Hide();
        }
    }
}
