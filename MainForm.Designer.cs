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
            this.SuspendLayout();
            // 
            // ShopButton
            // 
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
            this.GameButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.GameButton.Location = new System.Drawing.Point(0, 0);
            this.GameButton.Name = "GameButton";
            this.GameButton.Size = new System.Drawing.Size(75, 450);
            this.GameButton.TabIndex = 1;
            this.GameButton.Text = "Game";
            this.GameButton.UseVisualStyleBackColor = true;
            this.GameButton.Click += new System.EventHandler(this.GameButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameButton);
            this.Controls.Add(this.ShopButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ShopButton;
        private System.Windows.Forms.Button GameButton;
    }
}

