namespace Rougelike
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.Background = new System.Windows.Forms.PictureBox();
            this.tempoTimer = new System.Windows.Forms.Timer(this.components);
            this.progressCount = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            this.SuspendLayout();
            // 
            // Background
            // 
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(800, 450);
            this.Background.TabIndex = 0;
            this.Background.TabStop = false;
            // 
            // tempoTimer
            // 
            this.tempoTimer.Tick += new System.EventHandler(this.tempoTimer_Tick);
            // 
            // progressCount
            // 
            this.progressCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressCount.AutoSize = true;
            this.progressCount.Location = new System.Drawing.Point(359, 15);
            this.progressCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressCount.Name = "progressCount";
            this.progressCount.Size = new System.Drawing.Size(27, 16);
            this.progressCount.TabIndex = 1;
            this.progressCount.Text = "X/X";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.ForeColor = System.Drawing.Color.Maroon;
            this.progressBar1.Location = new System.Drawing.Point(311, 31);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(133, 28);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressCount);
            this.Controls.Add(this.Background);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.Timer tempoTimer;
        private System.Windows.Forms.Label progressCount;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}