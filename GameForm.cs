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
    public partial class GameForm: Form
    {
        int height;
        int width;

        public GameForm()
        {
            height = this.Height;
            width = this.Width;

            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            height = this.Height;
            width = this.Width;


        }
    }
}
