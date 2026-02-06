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

            this.Resize += new EventHandler(GameForm_Resize);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            winHeight = this.Height;
            winWidth = this.Width;


            InitializeButton(winWidth / 2, winHeight / 2, 30, Color.Green);
        }

        public List<Button> activeButtons = new List<Button>();



        public void InitializeButton(int X, int Y, int size, Color color)
        {
            Button button = new Button();
            activeButtons.Add(button);

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

            CheckButtonLocation(button, button.Width);


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
            activeButtons.Remove(button);
            
            //Makes seperate button
            InitializeButton(X + 50, Y + 50, size, button.BackColor);

            //Will add different cases if items are held and how to change button spawn in said case.


            //
        }

        private void CheckButtonLocation(Button button, int size)
        {
            winHeight = this.Height;
            winWidth = this.Width;

            //checks if button is in window boundaries for X axis, if it's not puts it in bounds
            if (button.Location.X > winWidth - (size * 1.5))
            {
                button.Location = new Point(winWidth - (size * 1 + (size / 2)), button.Location.Y);
            }
            if (button.Location.X < 0)
            {
                button.Location = new Point(0, button.Location.Y);
            }
            //checks if button is in window boundaries for Y axis, if it's not puts it in bounds
            if (button.Location.Y > winHeight - (size * 2.5))
            {
                button.Location = new Point(button.Location.X, winHeight - (size * 2 + (size / 3))); //Weird constant that makes the button skim the window boarder
            }
            if (button.Location.Y < 0)
            {
                button.Location = new Point(button.Location.X, 0);
            }
        }


        private void GameForm_Resize(object sender, EventArgs e)
        {
            
            //Goes through all active buttons to see if they are in the window boundries
            foreach(Button button in activeButtons)
            {
                CheckButtonLocation(button, button.Width);
            }

        }
    }
}
