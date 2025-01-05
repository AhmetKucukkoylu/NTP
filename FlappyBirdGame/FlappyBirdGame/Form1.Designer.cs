namespace FlappyBirdGame
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox_bird = new System.Windows.Forms.PictureBox();
            this.pictureBox_bottom = new System.Windows.Forms.PictureBox();
            this.pictureBox_up = new System.Windows.Forms.PictureBox();
            this.pictureBox_ground = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_GameController = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_up)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ground)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_bird
            // 
            this.pictureBox_bird.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_bird.Image")));
            this.pictureBox_bird.Location = new System.Drawing.Point(51, 234);
            this.pictureBox_bird.Name = "pictureBox_bird";
            this.pictureBox_bird.Size = new System.Drawing.Size(76, 64);
            this.pictureBox_bird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_bird.TabIndex = 0;
            this.pictureBox_bird.TabStop = false;
            // 
            // pictureBox_bottom
            // 
            this.pictureBox_bottom.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_bottom.Image")));
            this.pictureBox_bottom.Location = new System.Drawing.Point(339, 438);
            this.pictureBox_bottom.Name = "pictureBox_bottom";
            this.pictureBox_bottom.Size = new System.Drawing.Size(104, 199);
            this.pictureBox_bottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_bottom.TabIndex = 1;
            this.pictureBox_bottom.TabStop = false;
            this.pictureBox_bottom.Click += new System.EventHandler(this.pictureBox_bottom_Click);
            // 
            // pictureBox_up
            // 
            this.pictureBox_up.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_up.Image")));
            this.pictureBox_up.Location = new System.Drawing.Point(586, -5);
            this.pictureBox_up.Name = "pictureBox_up";
            this.pictureBox_up.Size = new System.Drawing.Size(100, 241);
            this.pictureBox_up.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_up.TabIndex = 2;
            this.pictureBox_up.TabStop = false;
            // 
            // pictureBox_ground
            // 
            this.pictureBox_ground.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_ground.Image")));
            this.pictureBox_ground.Location = new System.Drawing.Point(-3, 634);
            this.pictureBox_ground.Name = "pictureBox_ground";
            this.pictureBox_ground.Size = new System.Drawing.Size(750, 82);
            this.pictureBox_ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ground.TabIndex = 3;
            this.pictureBox_ground.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Score:";
            // 
            // timer_GameController
            // 
            this.timer_GameController.Enabled = true;
            this.timer_GameController.Interval = 20;
            this.timer_GameController.Tick += new System.EventHandler(this.GameTimer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(743, 710);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_ground);
            this.Controls.Add(this.pictureBox_up);
            this.Controls.Add(this.pictureBox_bottom);
            this.Controls.Add(this.pictureBox_bird);
            this.Name = "Form1";
            this.Text = "Flappy Bird Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.game_Down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.game_Up);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_up)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_bird;
        private System.Windows.Forms.PictureBox pictureBox_bottom;
        private System.Windows.Forms.PictureBox pictureBox_up;
        private System.Windows.Forms.PictureBox pictureBox_ground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer_GameController;
    }
}

