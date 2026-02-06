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
        //___PUBLIC VARS___
        public int winHeight;
        public int winWidth;

        public bool loopGame;

        public MainForm.Level level = new MainForm.Level();
        Random random = new Random();

        //___FORM CODE___
        public GameForm(MainForm.Player player, MainForm.Level Level)
        {


            InitializeComponent();

            level = Level;

            this.Resize += new EventHandler(GameForm_Resize);
        }
        
        private void GameForm_Load(object sender, EventArgs e)
        {
            winHeight = this.Height;
            winWidth = this.Width;

            loopGame = true;

            //uses await and async run and load GUI
            ExecuteGameLoop();




        }

        private void GameForm_Resize(object sender, EventArgs e)
        {

            //Goes through all active buttons to see if they are in the window boundries
            foreach (Button button in activeButtons)
            {
                CheckButtonLocation(button, button.Width);
            }

        }



        //___CONTROL CODE___

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
            //InitializeButton(X + 50, Y + 50, size, button.BackColor);

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


        //___GAME CODE___

        private void ExecuteGameLoop()
        {

            tempoTimer.Interval = ( 1000 * (60/level.tempo)); // dif 1 is 60/30 so will run every 2 seconds
            tempoTimer.Start();
     
        }

        //private double SetTempo()
        //{
        //    double tempo;

        //    double num1 = 2 * level.Difficulty;

        //    num1 = num1 / 4;

        //    num1 = num1 * 60;


        //    tempo = num1;// 1 = every 2s (30BPM (0.5*60) ), 2 = every 1 second (60BPM (1*60) ), 3 = every 2/3 second (90 BPM (1.5*60) ), etc   

            
        //    return (tempo);
        //}

        private void tempoTimer_Tick(object sender, EventArgs e)
        {
            if (loopGame)
            {
                InitializeButton(random.Next(winWidth), random.Next(winHeight), 30, Color.Green);
            }
            else
            {
                tempoTimer.Stop();
            }
            
        }
    }
}
