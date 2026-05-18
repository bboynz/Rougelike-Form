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
    public partial class LoginForm: Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MainForm mainForm = new MainForm(UserPrompt.Text);
            mainForm.Show();

            this.Hide();
        }

        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("After logging in with your username you will be sent to the main menu where you can select levels by clicking on them, on the right is a button to go to the shop menu, there you can hover over the items to get info about them. to the left on the menu form is a play button, after pressing a level by clicking on the button in the menu you can press the game button to play. To play you need to click the buttons that look like plastic bags that pop up, after completing a level you get points which you can then use to buy items in the shop. Also the shop will restock every time you enter, but there is a limited stock so make sure to have atleast 50 points before entering");
        }
    }
}
