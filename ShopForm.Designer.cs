namespace Rougelike
{
    partial class ShopForm
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
            this.ExitLabel = new System.Windows.Forms.Label();
            this.Option_3 = new System.Windows.Forms.PictureBox();
            this.Option_2 = new System.Windows.Forms.PictureBox();
            this.Option_1 = new System.Windows.Forms.PictureBox();
            this.ShopBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Option_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShopBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ExitLabel.Location = new System.Drawing.Point(544, 337);
            this.ExitLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(24, 13);
            this.ExitLabel.TabIndex = 4;
            this.ExitLabel.Text = "Exit";
            this.ExitLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // Option_3
            // 
            this.Option_3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Option_3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Option_3.Location = new System.Drawing.Point(358, 152);
            this.Option_3.Margin = new System.Windows.Forms.Padding(2);
            this.Option_3.Name = "Option_3";
            this.Option_3.Size = new System.Drawing.Size(68, 73);
            this.Option_3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Option_3.TabIndex = 3;
            this.Option_3.TabStop = false;
            this.Option_3.Click += new System.EventHandler(this.Option_3_Click);
            // 
            // Option_2
            // 
            this.Option_2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Option_2.Location = new System.Drawing.Point(257, 152);
            this.Option_2.Margin = new System.Windows.Forms.Padding(2);
            this.Option_2.Name = "Option_2";
            this.Option_2.Size = new System.Drawing.Size(68, 73);
            this.Option_2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Option_2.TabIndex = 2;
            this.Option_2.TabStop = false;
            this.Option_2.Click += new System.EventHandler(this.Option_2_Click);
            // 
            // Option_1
            // 
            this.Option_1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Option_1.Location = new System.Drawing.Point(151, 152);
            this.Option_1.Margin = new System.Windows.Forms.Padding(2);
            this.Option_1.Name = "Option_1";
            this.Option_1.Size = new System.Drawing.Size(68, 73);
            this.Option_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Option_1.TabIndex = 1;
            this.Option_1.TabStop = false;
            this.Option_1.Click += new System.EventHandler(this.Option_1_Click);
            // 
            // ShopBackground
            // 
            this.ShopBackground.BackgroundImage = global::Rougelike.Properties.Resources.Table;
            this.ShopBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ShopBackground.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShopBackground.Location = new System.Drawing.Point(0, 0);
            this.ShopBackground.Margin = new System.Windows.Forms.Padding(2);
            this.ShopBackground.Name = "ShopBackground";
            this.ShopBackground.Size = new System.Drawing.Size(600, 366);
            this.ShopBackground.TabIndex = 0;
            this.ShopBackground.TabStop = false;
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.ExitLabel);
            this.Controls.Add(this.Option_3);
            this.Controls.Add(this.Option_2);
            this.Controls.Add(this.Option_1);
            this.Controls.Add(this.ShopBackground);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ShopForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ShopForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Option_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShopBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ShopBackground;
        private System.Windows.Forms.PictureBox Option_1;
        private System.Windows.Forms.PictureBox Option_2;
        private System.Windows.Forms.PictureBox Option_3;
        private System.Windows.Forms.Label ExitLabel;
    }
}