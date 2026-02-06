namespace Rougelike
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ShopButton = new System.Windows.Forms.Button();
            this.GameButton = new System.Windows.Forms.Button();
            this.LevelButton = new System.Windows.Forms.PictureBox();
            this.selectedLevelLabel = new System.Windows.Forms.Label();
            this.levelNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LevelButton)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopButton
            // 
            this.ShopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ShopButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ShopButton.Location = new System.Drawing.Point(716, 0);
            this.ShopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShopButton.Name = "ShopButton";
            this.ShopButton.Size = new System.Drawing.Size(84, 450);
            this.ShopButton.TabIndex = 0;
            this.ShopButton.Text = "Shop";
            this.ShopButton.UseVisualStyleBackColor = true;
            this.ShopButton.Click += new System.EventHandler(this.ShopButton_Click);
            // 
            // GameButton
            // 
            this.GameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GameButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.GameButton.Location = new System.Drawing.Point(0, 0);
            this.GameButton.Name = "GameButton";
            this.GameButton.Size = new System.Drawing.Size(75, 450);
            this.GameButton.TabIndex = 1;
            this.GameButton.Text = "Game";
            this.GameButton.UseVisualStyleBackColor = true;
            this.GameButton.Click += new System.EventHandler(this.GameButton_Click);
            // 
            // LevelButton
            // 
            this.LevelButton.BackColor = System.Drawing.Color.White;
            this.LevelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LevelButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.LevelButton.Image = global::Rougelike.Properties.Resources._99e2228047a93ea65b8e9e9410213e42;
            this.LevelButton.Location = new System.Drawing.Point(350, 237);
            this.LevelButton.Name = "LevelButton";
            this.LevelButton.Padding = new System.Windows.Forms.Padding(2);
            this.LevelButton.Size = new System.Drawing.Size(100, 50);
            this.LevelButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LevelButton.TabIndex = 2;
            this.LevelButton.TabStop = false;
            this.LevelButton.Click += new System.EventHandler(this.LevelButton_Click);
            // 
            // selectedLevelLabel
            // 
            this.selectedLevelLabel.BackColor = System.Drawing.Color.LightGray;
            this.selectedLevelLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedLevelLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.selectedLevelLabel.Location = new System.Drawing.Point(75, 0);
            this.selectedLevelLabel.Name = "selectedLevelLabel";
            this.selectedLevelLabel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 15);
            this.selectedLevelLabel.Size = new System.Drawing.Size(641, 60);
            this.selectedLevelLabel.TabIndex = 3;
            this.selectedLevelLabel.Text = "Selected Level:";
            this.selectedLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // levelNameLabel
            // 
            this.levelNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.levelNameLabel.AutoSize = true;
            this.levelNameLabel.BackColor = System.Drawing.Color.LightGray;
            this.levelNameLabel.Font = new System.Drawing.Font("Myanmar Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelNameLabel.Location = new System.Drawing.Point(324, 6);
            this.levelNameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.levelNameLabel.Name = "levelNameLabel";
            this.levelNameLabel.Size = new System.Drawing.Size(178, 53);
            this.levelNameLabel.TabIndex = 4;
            this.levelNameLabel.Text = "Unselected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.levelNameLabel);
            this.Controls.Add(this.selectedLevelLabel);
            this.Controls.Add(this.LevelButton);
            this.Controls.Add(this.GameButton);
            this.Controls.Add(this.ShopButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LevelButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShopButton;
        private System.Windows.Forms.Button GameButton;
        private System.Windows.Forms.PictureBox LevelButton;
        private System.Windows.Forms.Label selectedLevelLabel;
        private System.Windows.Forms.Label levelNameLabel;
    }
}

