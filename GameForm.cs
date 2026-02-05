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
        int winHeight;
        int winWidth;

        public GameForm()
        {


            InitializeComponent();

        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            winHeight = this.Height;
            winWidth = this.Width;

            InitializeButton(winWidth / 2, winHeight / 2, 30, Color.Green);
        }

        public void InitializeButton(int X, int Y, int size, Color color)
        {
            Button button = new Button();
            

            //Constant values
            button.Anchor = AnchorStyles.None;
            button.Text = "";
            button.Cursor = Cursors.Cross;

            //set values 
            button.Location = new Point(X - (size/2), Y - (size/2));
            button.Size = new Size(size, size);
            button.BackColor = color;

            //showing/adding the component
            button.Visible = true;
            this.Controls.Add(button);
            button.BringToFront();

            //Edge case protection
            winHeight = this.Height;
            winWidth = this.Width;

                //checks if button is in window boundaries for X axis, if it's not puts it in bounds
            if (button.Location.X > winWidth-size*2)
            {
                button.Location = new Point(button.Location.X, button.Location.X - Math.Abs(button.Location.X - winHeight));
            }
            if (button.Location.X < 0)
            {
                button.Location = new Point(button.Location.X, button.Location.X + Math.Abs(button.Location.X - winHeight));
            }
                //checks if button is in window boundaries for Y axis, if it's not puts it in bounds
            if (button.Location.Y > winHeight-size*2)
            {
                button.Location = new Point(button.Location.Y , button.Location.Y - Math.Abs(button.Location.Y - winHeight));
            }
            if (button.Location.Y < 0)
            {
                button.Location = new Point(button.Location.Y, button.Location.Y + Math.Abs(button.Location.Y - winHeight));
            }


            //Button events
            button.Click += new System.EventHandler(this.gameButton_Click);
        }

        void gameButton_Click(object sender, EventArgs e)
        {
            //Gets reference to button by casting sender object as button
            Button button = (Button)sender;

            //For easy reference
            int size = button.Width;
            int X = button.Location.X + size / 2;
            int Y = button.Location.Y + size / 2;

            //gets rid of button
            button.Hide();
            button.Dispose();
            this.Controls.Remove(button);
            
            //Makes seperate button
            InitializeButton(X, Y + 20, size, button.BackColor);

            //Will add different cases if items are held and how to change button spawn in said case.


            //
        }
    }
}
