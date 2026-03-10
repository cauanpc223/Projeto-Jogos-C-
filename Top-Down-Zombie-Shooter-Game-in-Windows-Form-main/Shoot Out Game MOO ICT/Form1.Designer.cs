namespace Shoot_Out_Game_MOO_ICT
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtAmmo = new Label();
            txtScore = new Label();
            label1 = new Label();
            healthBar = new ProgressBar();
            player = new PictureBox();
            GameTimer = new System.Windows.Forms.Timer(components);
            buttonReset = new Button();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // txtAmmo
            // 
            txtAmmo.AutoSize = true;
            txtAmmo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAmmo.ForeColor = Color.White;
            txtAmmo.Location = new Point(22, 25);
            txtAmmo.Margin = new Padding(5, 0, 5, 0);
            txtAmmo.Name = "txtAmmo";
            txtAmmo.Size = new Size(139, 33);
            txtAmmo.TabIndex = 0;
            txtAmmo.Text = "Ammo: 0";
            // 
            // txtScore
            // 
            txtScore.AutoSize = true;
            txtScore.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.ForeColor = Color.White;
            txtScore.Location = new Point(613, 25);
            txtScore.Margin = new Padding(5, 0, 5, 0);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(110, 33);
            txtScore.TabIndex = 0;
            txtScore.Text = "Kills: 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(1072, 25);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(123, 33);
            label1.TabIndex = 0;
            label1.Text = "Health: ";
            // 
            // healthBar
            // 
            healthBar.Location = new Point(1208, 25);
            healthBar.Margin = new Padding(5, 6, 5, 6);
            healthBar.Name = "healthBar";
            healthBar.Size = new Size(312, 44);
            healthBar.TabIndex = 1;
            healthBar.Value = 100;
            // 
            // player
            // 
            player.Image = Properties.Resources.up;
            player.Location = new Point(712, 906);
            player.Margin = new Padding(5, 6, 5, 6);
            player.Name = "player";
            player.Size = new Size(71, 100);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // GameTimer
            // 
            GameTimer.Enabled = true;
            GameTimer.Interval = 20;
            GameTimer.Tick += MainTimerEvent;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(613, 76);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(112, 34);
            buttonReset.TabIndex = 3;
            buttonReset.TabStop = false;
            buttonReset.Text = "Reset";
            buttonReset.TabStop = false;
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += ButtonReset;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1540, 1271);
            Controls.Add(buttonReset);
            Controls.Add(player);
            Controls.Add(healthBar);
            Controls.Add(label1);
            Controls.Add(txtScore);
            Controls.Add(txtAmmo);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Zombie Shootout Game MOO ICT";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion

        private System.Windows.Forms.Label txtAmmo;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar healthBar;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private Button buttonReset;
    }
}
