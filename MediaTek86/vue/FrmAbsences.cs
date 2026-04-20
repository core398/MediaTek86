using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    /// <summary>
    /// Formulaire de gestion des absences d'un personnel
    /// </summary>
    public partial class FrmAbsences : Form
    {
        /// <summary>
        /// Instance du contrôleur
        /// </summary>
        private readonly Controleur controleur;

        /// <summary>
        /// Personnel sélectionné
        /// </summary>
        private readonly Personnel personnel;

        /// <summary>
        /// Constructeur du formulaire des absences
        /// </summary>
        public FrmAbsences(Personnel personnel)
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
            this.personnel = personnel;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FrmAbsences_Load(object sender, EventArgs e)
        {
            lblNomPrenom.Text = personnel.Nom + " " + personnel.Prenom;
            ChargerAbsences();
        }

        /// <summary>
        /// Charge et affiche la liste des absences
        /// </summary>
        private void ChargerAbsences()
        {
            lvwAbsences.Items.Clear();
            List<Absence> listeAbsences = controleur.GetAbsencesByPersonnel(personnel.Id);
            foreach (Absence a in listeAbsences)
            {
                ListViewItem item = new ListViewItem(a.DateDebut.ToShortDateString());
                item.SubItems.Add(a.DateFin.ToShortDateString());
                item.SubItems.Add(a.LibelleMotif);
                item.Tag = a;
                lvwAbsences.Items.Add(item);
            }
        }

        /// <summary>
        /// Clic sur le bouton Ajouter
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutAbsence frm = new FrmAjoutAbsence(personnel.Id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChargerAbsences();
            }
        }

        /// <summary>
        /// Clic sur le bouton Modifier
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (lvwAbsences.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une absence.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Absence absence = (Absence)lvwAbsences.SelectedItems[0].Tag;
            FrmAjoutAbsence frm = new FrmAjoutAbsence(personnel.Id, absence);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChargerAbsences();
            }
        }

        /// <summary>
        /// Clic sur le bouton Supprimer
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lvwAbsences.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une absence.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Absence absence = (Absence)lvwAbsences.SelectedItems[0].Tag;
            if (MessageBox.Show("Voulez-vous vraiment supprimer cette absence ?", "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controleur.SupprimerAbsence(absence.Id);
                ChargerAbsences();
            }
        }
    }
}