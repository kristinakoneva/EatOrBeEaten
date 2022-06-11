namespace EatOrBeEaten
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
            this.timerTimeAlive = new System.Windows.Forms.Timer(this.components);
            this.timerGenerateNewBalls = new System.Windows.Forms.Timer(this.components);
            this.timerMoveBalls = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblFoodEaten = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnEndGame = new System.Windows.Forms.Button();
            this.tsslblTimeAlive = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerTimeAlive
            // 
            this.timerTimeAlive.Interval = 1000;
            this.timerTimeAlive.Tick += new System.EventHandler(this.timerTimeAlive_Tick);
            // 
            // timerGenerateNewBalls
            // 
            this.timerGenerateNewBalls.Tick += new System.EventHandler(this.timerGenerateNewBalls_Tick);
            // 
            // timerMoveBalls
            // 
            this.timerMoveBalls.Tick += new System.EventHandler(this.timerMoveBalls_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblFoodEaten,
            this.tsslblTimeAlive});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblFoodEaten
            // 
            this.tsslblFoodEaten.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsslblFoodEaten.Name = "tsslblFoodEaten";
            this.tsslblFoodEaten.Size = new System.Drawing.Size(78, 17);
            this.tsslblFoodEaten.Text = "Food eaten: 0";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(28, 13);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnEndGame
            // 
            this.btnEndGame.Location = new System.Drawing.Point(123, 13);
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.Size = new System.Drawing.Size(75, 23);
            this.btnEndGame.TabIndex = 2;
            this.btnEndGame.Text = "End Game";
            this.btnEndGame.UseVisualStyleBackColor = true;
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click);
            // 
            // tsslblTimeAlive
            // 
            this.tsslblTimeAlive.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tsslblTimeAlive.Name = "tsslblTimeAlive";
            this.tsslblTimeAlive.Size = new System.Drawing.Size(95, 17);
            this.tsslblTimeAlive.Text = "Time Alive: 00:00";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnNewGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CancelButton = this.btnEndGame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEndGame);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Eat or Be Eaten";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerTimeAlive;
        private System.Windows.Forms.Timer timerGenerateNewBalls;
        private System.Windows.Forms.Timer timerMoveBalls;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblFoodEaten;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnEndGame;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTimeAlive;
    }
}

