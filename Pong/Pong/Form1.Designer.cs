namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.espaceJeu = new System.Windows.Forms.Panel();
            this.messageLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.raquette = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.espaceJeu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raquette)).BeginInit();
            this.SuspendLayout();
            // 
            // espaceJeu
            // 
            this.espaceJeu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("espaceJeu.BackgroundImage")));
            this.espaceJeu.Controls.Add(this.messageLabel);
            this.espaceJeu.Controls.Add(this.scoreLabel);
            this.espaceJeu.Controls.Add(this.label);
            this.espaceJeu.Controls.Add(this.raquette);
            this.espaceJeu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.espaceJeu.Location = new System.Drawing.Point(0, 0);
            this.espaceJeu.Name = "espaceJeu";
            this.espaceJeu.Size = new System.Drawing.Size(735, 570);
            this.espaceJeu.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Minion Pro Cond", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(304, 261);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 33);
            this.messageLabel.TabIndex = 4;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Modern No. 20", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.scoreLabel.Location = new System.Drawing.Point(142, 23);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(34, 38);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Modern No. 20", 27.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label.Location = new System.Drawing.Point(12, 23);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(124, 38);
            this.label.TabIndex = 2;
            this.label.Text = "Score :";
            // 
            // raquette
            // 
            this.raquette.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.raquette.Location = new System.Drawing.Point(273, 517);
            this.raquette.Name = "raquette";
            this.raquette.Size = new System.Drawing.Size(175, 20);
            this.raquette.TabIndex = 0;
            this.raquette.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 570);
            this.Controls.Add(this.espaceJeu);
            this.Name = "Form1";
            this.Text = "Pong";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.espaceJeu.ResumeLayout(false);
            this.espaceJeu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raquette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel espaceJeu;
        private System.Windows.Forms.PictureBox raquette;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label messageLabel;
    }
}

