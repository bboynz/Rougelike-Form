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
        public class Item
        {
            public string Name;


        }

        public static Item InitializeItem(string name)
        {
            Item item = new Item();

            item.Name = name;


            return item;
        }

        public MainForm()
        {
            InitializeComponent();
        }

       
    }
}
