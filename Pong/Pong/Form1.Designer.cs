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
            this.espaceJeu = new System.Windows.Forms.Panel();
            this.balle = new System.Windows.Forms.PictureBox();
            this.raquette = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.espaceJeu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raquette)).BeginInit();
            this.SuspendLayout();
            // 
            // espaceJeu
            // 
            this.espaceJeu.Controls.Add(this.scoreLabel);
            this.espaceJeu.Controls.Add(this.label);
            this.espaceJeu.Controls.Add(this.balle);
            this.espaceJeu.Controls.Add(this.raquette);
            this.espaceJeu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.espaceJeu.Location = new System.Drawing.Point(0, 0);
            this.espaceJeu.Name = "espaceJeu";
            this.espaceJeu.Size = new System.Drawing.Size(735, 570);
            this.espaceJeu.TabIndex = 0;
            // 
            // balle
            // 
            this.balle.BackColor = System.Drawing.Color.Red;
            this.balle.Location = new System.Drawing.Point(330, 166);
            this.balle.Name = "balle";
            this.balle.Size = new System.Drawing.Size(20, 20);
            this.balle.TabIndex = 1;
            this.balle.TabStop = false;
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
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 23);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(41, 13);
            this.label.TabIndex = 2;
            this.label.Text = "Score :";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(59, 23);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(13, 13);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 570);
            this.Controls.Add(this.espaceJeu);
            this.Name = "Form1";
            this.Text = "Pong";
            this.espaceJeu.ResumeLayout(false);
            this.espaceJeu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raquette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel espaceJeu;
        private System.Windows.Forms.PictureBox balle;
        private System.Windows.Forms.PictureBox raquette;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label label;
    }
}

