using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    /// <summary>
    /// Formulaire d'ajout et de modification d'une absence
    /// </summary>
    public partial class FrmAjoutAbsence : Form
    {
        /// <summary>
        /// Instance du contrôleur
        /// </summary>
        private readonly Controleur controleur;

        /// <summary>
        /// Id du personnel concerné
        /// </summary>
        private readonly int idPersonnel;

        /// <summary>
        /// Absence à modifier (null si ajout)
        /// </summary>
        private readonly Absence absenceAModifier;

        /// <summary>
        /// Constructeur pour l'ajout
        /// </summary>
        public FrmAjoutAbsence(int idPersonnel)
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
            this.idPersonnel = idPersonnel;
            absenceAModifier = null;
        }

        /// <summary>
        /// Constructeur pour la modification
        /// </summary>
        public FrmAjoutAbsence(int idPersonnel, Absence absence)
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
            this.idPersonnel = idPersonnel;
            absenceAModifier = absence;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FrmAjoutAbsence_Load(object sender, EventArgs e)
        {
            List<Motif> motifs = controleur.GetAllMotifs();
            cmbMotif.DataSource = motifs;
            cmbMotif.DisplayMember = "Libelle";
            cmbMotif.ValueMember = "Id";

            if (absenceAModifier != null)
            {
                this.Text = "Modifier une absence";
                dtpDateDebut.Value = absenceAModifier.DateDebut;
                dtpDateFin.Value = absenceAModifier.DateFin;
                cmbMotif.SelectedValue = absenceAModifier.IdMotif;
            }
        }

        /// <summary>
        /// Clic sur le bouton Enregistrer
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (dtpDateFin.Value < dtpDateDebut.Value)
            {
                MessageBox.Show("La date de fin doit être après la date de début.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Voulez-vous enregistrer cette absence ?", "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int idMotif = (int)cmbMotif.SelectedValue;
                bool succes;

                if (absenceAModifier == null)
                {
                    succes = controleur.AjouterAbsence(idPersonnel, dtpDateDebut.Value, dtpDateFin.Value, idMotif);
                }
                else
                {
                    succes = controleur.ModifierAbsence(absenceAModifier.Id, idPersonnel, dtpDateDebut.Value, dtpDateFin.Value, idMotif);
                }

                if (succes)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Une absence existe déjà sur ce créneau.", "Erreur de chevauchement",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Clic sur le bouton Annuler
        /// </summary>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}