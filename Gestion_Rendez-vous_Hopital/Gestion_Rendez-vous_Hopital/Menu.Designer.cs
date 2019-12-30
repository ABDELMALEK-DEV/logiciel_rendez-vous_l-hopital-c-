namespace Gestion_Rendez_vous_Hopital
{
    partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesMedecinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesPatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesRDVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherToutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechercherRDVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherLesRDVDunPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.consultationToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesMedecinsToolStripMenuItem,
            this.gestionDesPatientsToolStripMenuItem,
            this.gestionDesRDVToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // gestionDesMedecinsToolStripMenuItem
            // 
            this.gestionDesMedecinsToolStripMenuItem.Name = "gestionDesMedecinsToolStripMenuItem";
            this.gestionDesMedecinsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gestionDesMedecinsToolStripMenuItem.Text = "Gestion des Medecins";
            this.gestionDesMedecinsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesMedecinsToolStripMenuItem_Click);
            // 
            // gestionDesPatientsToolStripMenuItem
            // 
            this.gestionDesPatientsToolStripMenuItem.Name = "gestionDesPatientsToolStripMenuItem";
            this.gestionDesPatientsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gestionDesPatientsToolStripMenuItem.Text = "Gestion des patients";
            this.gestionDesPatientsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesPatientsToolStripMenuItem_Click);
            // 
            // gestionDesRDVToolStripMenuItem
            // 
            this.gestionDesRDVToolStripMenuItem.Name = "gestionDesRDVToolStripMenuItem";
            this.gestionDesRDVToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gestionDesRDVToolStripMenuItem.Text = "Gestion des RDV";
            this.gestionDesRDVToolStripMenuItem.Click += new System.EventHandler(this.gestionDesRDVToolStripMenuItem_Click);
            // 
            // consultationToolStripMenuItem
            // 
            this.consultationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afficherToutToolStripMenuItem,
            this.rechercherRDVToolStripMenuItem,
            this.afficherLesRDVDunPatientToolStripMenuItem});
            this.consultationToolStripMenuItem.Name = "consultationToolStripMenuItem";
            this.consultationToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.consultationToolStripMenuItem.Text = "Consultation";
            // 
            // afficherToutToolStripMenuItem
            // 
            this.afficherToutToolStripMenuItem.Name = "afficherToutToolStripMenuItem";
            this.afficherToutToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.afficherToutToolStripMenuItem.Text = "Afficher tout";
            this.afficherToutToolStripMenuItem.Click += new System.EventHandler(this.afficherToutToolStripMenuItem_Click);
            // 
            // rechercherRDVToolStripMenuItem
            // 
            this.rechercherRDVToolStripMenuItem.Name = "rechercherRDVToolStripMenuItem";
            this.rechercherRDVToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.rechercherRDVToolStripMenuItem.Text = "Rechercher RDV";
            this.rechercherRDVToolStripMenuItem.Click += new System.EventHandler(this.rechercherRDVToolStripMenuItem_Click);
            // 
            // afficherLesRDVDunPatientToolStripMenuItem
            // 
            this.afficherLesRDVDunPatientToolStripMenuItem.Name = "afficherLesRDVDunPatientToolStripMenuItem";
            this.afficherLesRDVDunPatientToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.afficherLesRDVDunPatientToolStripMenuItem.Text = "Afficher les RDV d\'un patient";
            this.afficherLesRDVDunPatientToolStripMenuItem.Click += new System.EventHandler(this.afficherLesRDVDunPatientToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 455);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Formulaire Principal";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesMedecinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesPatientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesRDVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherToutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechercherRDVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afficherLesRDVDunPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    }
}

