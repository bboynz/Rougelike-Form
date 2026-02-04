using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Rougelike
{
    public partial class ShopForm: Form
    {
        

        public static class ShopItems
        {
            static MainForm.Item bomb = MainForm.InitializeItem("bomb");
        }

        public ShopForm()
        {
            InitializeComponent();
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

        }
    }
}
