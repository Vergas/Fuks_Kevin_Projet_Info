namespace Tetris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.espaceJeu = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // espaceJeu
            // 
            this.espaceJeu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("espaceJeu.BackgroundImage")));
            this.espaceJeu.Location = new System.Drawing.Point(78, 30);
            this.espaceJeu.Name = "espaceJeu";
            this.espaceJeu.Size = new System.Drawing.Size(200, 440);
            this.espaceJeu.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 519);
            this.Controls.Add(this.espaceJeu);
            this.Name = "Form1";
            this.Text = "Tetris";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel espaceJeu;
    }
}

