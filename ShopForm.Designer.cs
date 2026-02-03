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
            this.ShopBackground = new System.Windows.Forms.PictureBox();
            this.Option_1 = new System.Windows.Forms.PictureBox();
            this.Option_2 = new System.Windows.Forms.PictureBox();
            this.Option_3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ShopBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_3)).BeginInit();
            this.SuspendLayout();
            // 
            // ShopBackground
            // 
            this.ShopBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShopBackground.Location = new System.Drawing.Point(0, 0);
            this.ShopBackground.Name = "ShopBackground";
            this.ShopBackground.Size = new System.Drawing.Size(800, 450);
            this.ShopBackground.TabIndex = 0;
            this.ShopBackground.TabStop = false;
            // 
            // Option_1
            // 
            this.Option_1.Location = new System.Drawing.Point(201, 187);
            this.Option_1.Name = "Option_1";
            this.Option_1.Size = new System.Drawing.Size(90, 90);
            this.Option_1.TabIndex = 1;
            this.Option_1.TabStop = false;
            // 
            // Option_2
            // 
            this.Option_2.Location = new System.Drawing.Point(343, 187);
            this.Option_2.Name = "Option_2";
            this.Option_2.Size = new System.Drawing.Size(90, 90);
            this.Option_2.TabIndex = 2;
            this.Option_2.TabStop = false;
            // 
            // Option_3
            // 
            this.Option_3.Location = new System.Drawing.Point(477, 187);
            this.Option_3.Name = "Option_3";
            this.Option_3.Size = new System.Drawing.Size(90, 90);
            this.Option_3.TabIndex = 3;
            this.Option_3.TabStop = false;
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Option_3);
            this.Controls.Add(this.Option_2);
            this.Controls.Add(this.Option_1);
            this.Controls.Add(this.ShopBackground);
            this.Name = "ShopForm";
            this.Text = "ShopForm";
            this.Load += new System.EventHandler(this.ShopForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShopBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Option_3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ShopBackground;
        private System.Windows.Forms.PictureBox Option_1;
        private System.Windows.Forms.PictureBox Option_2;
        private System.Windows.Forms.PictureBox Option_3;
    }
}