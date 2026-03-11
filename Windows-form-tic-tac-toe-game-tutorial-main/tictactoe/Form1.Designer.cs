namespace tictactoe
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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            AImoves = new System.Windows.Forms.Timer(components);
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(21, 25);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 0;
            label1.Text = "Player Wins - 0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(192, 0, 0);
            label2.Location = new Point(847, 25);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 1;
            label2.Text = "AI Wins - 0";
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(104, 116);
            button1.Margin = new Padding(6, 8, 6, 8);
            button1.Name = "button1";
            button1.Size = new Size(288, 310);
            button1.TabIndex = 2;
            button1.Tag = "play";
            button1.Text = "?";
            button1.UseVisualStyleBackColor = true;
            button1.Click += playerClick;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(405, 116);
            button2.Margin = new Padding(6, 8, 6, 8);
            button2.Name = "button2";
            button2.Size = new Size(288, 310);
            button2.TabIndex = 2;
            button2.Tag = "play";
            button2.Text = "?";
            button2.UseVisualStyleBackColor = true;
            button2.Click += playerClick;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(705, 116);
            button3.Margin = new Padding(6, 8, 6, 8);
            button3.Name = "button3";
            button3.Size = new Size(288, 310);
            button3.TabIndex = 2;
            button3.Tag = "play";
            button3.Text = "?";
            button3.UseVisualStyleBackColor = true;
            button3.Click += playerClick;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(104, 442);
            button4.Margin = new Padding(6, 8, 6, 8);
            button4.Name = "button4";
            button4.Size = new Size(288, 310);
            button4.TabIndex = 2;
            button4.Tag = "play";
            button4.Text = "?";
            button4.UseVisualStyleBackColor = true;
            button4.Click += playerClick;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(405, 442);
            button5.Margin = new Padding(6, 8, 6, 8);
            button5.Name = "button5";
            button5.Size = new Size(288, 310);
            button5.TabIndex = 2;
            button5.Tag = "play";
            button5.Text = "?";
            button5.UseVisualStyleBackColor = true;
            button5.Click += playerClick;
            // 
            // button6
            // 
            button6.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(705, 442);
            button6.Margin = new Padding(6, 8, 6, 8);
            button6.Name = "button6";
            button6.Size = new Size(288, 310);
            button6.TabIndex = 2;
            button6.Tag = "play";
            button6.Text = "?";
            button6.UseVisualStyleBackColor = true;
            button6.Click += playerClick;
            // 
            // button7
            // 
            button7.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.Location = new Point(104, 767);
            button7.Margin = new Padding(6, 8, 6, 8);
            button7.Name = "button7";
            button7.Size = new Size(288, 310);
            button7.TabIndex = 2;
            button7.Tag = "play";
            button7.Text = "?";
            button7.UseVisualStyleBackColor = true;
            button7.Click += playerClick;
            // 
            // button8
            // 
            button8.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.Location = new Point(405, 767);
            button8.Margin = new Padding(6, 8, 6, 8);
            button8.Name = "button8";
            button8.Size = new Size(288, 310);
            button8.TabIndex = 2;
            button8.Tag = "play";
            button8.Text = "?";
            button8.UseVisualStyleBackColor = true;
            button8.Click += playerClick;
            // 
            // button9
            // 
            button9.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.Location = new Point(705, 767);
            button9.Margin = new Padding(6, 8, 6, 8);
            button9.Name = "button9";
            button9.Size = new Size(288, 310);
            button9.TabIndex = 2;
            button9.Tag = "play";
            button9.Text = "?";
            button9.UseVisualStyleBackColor = true;
            button9.Click += playerClick;
            // 
            // button10
            // 
            button10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.Location = new Point(437, 1149);
            button10.Margin = new Padding(6, 8, 6, 8);
            button10.Name = "button10";
            button10.Size = new Size(239, 91);
            button10.TabIndex = 5;
            button10.Tag = "restart";
            button10.Text = "Restart";
            button10.UseVisualStyleBackColor = true;
            button10.Click += restartGame;
            // 
            // AImoves
            // 
            AImoves.Interval = 1000;
            AImoves.Tick += AImove;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(442, 20);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(128, 32);
            label3.TabIndex = 6;
            label3.Text = "Empates - ";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 1055);
            Controls.Add(label3);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button7);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "Form1";
            Text = "Tic Tac Toe - MOO ICT";
            ResumeLayout(false);
            PerformLayout();



        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Timer AImoves;
        private Label label3;
    }
}
