namespace ChessGame
{
    partial class ChessBoard
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
            CurrentMovingPlayer = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // CurrentMovingPlayer
            // 
            CurrentMovingPlayer.AutoSize = true;
            CurrentMovingPlayer.BackColor = System.Drawing.Color.Transparent;
            CurrentMovingPlayer.Font = new System.Drawing.Font("Segoe UI", 15F);
            CurrentMovingPlayer.Location = new System.Drawing.Point(859, 163);
            CurrentMovingPlayer.Name = "CurrentMovingPlayer";
            CurrentMovingPlayer.Size = new System.Drawing.Size(81, 35);
            CurrentMovingPlayer.TabIndex = 0;
            CurrentMovingPlayer.Text = "label1";
            // 
            // ChessBoard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1125, 881);
            Controls.Add(CurrentMovingPlayer);
            ForeColor = System.Drawing.SystemColors.ControlText;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ChessBoard";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label CurrentMovingPlayer;
    }
}

