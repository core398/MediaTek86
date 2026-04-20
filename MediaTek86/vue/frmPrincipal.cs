using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    /// <summary>
    /// Formulaire principal affichant la liste du personnel
    /// </summary>
    public partial class FrmPrincipal : Form
    {
        /// <summary>
        /// Instance du contrôleur
        /// </summary>
        private readonly Controleur controleur;

        /// <summary>
        /// Constructeur du formulaire principal
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            ChargerPersonnel();
        }

        /// <summary>
        /// Charge et affiche la liste du personnel
        /// </summary>
        private void ChargerPersonnel()
        {
            lvwPersonnel.Items.Clear();
            List<Personnel> listePersonnel = controleur.GetAllPersonnel();
            foreach (Personnel p in listePersonnel)
            {
                ListViewItem item = new ListViewItem(p.Nom);
                item.SubItems.Add(p.Prenom);
                item.SubItems.Add(p.Tel);
                item.SubItems.Add(p.Mail);
                item.SubItems.Add(p.NomService);
                item.Tag = p;
                lvwPersonnel.Items.Add(item);
            }
        }

        /// <summary>
        /// Clic sur le bouton Ajouter
        /// </summary>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmAjoutPersonnel frm = new FrmAjoutPersonnel();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChargerPersonnel();
            }
        }

        /// <summary>
        /// Clic sur le bouton Modifier
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (lvwPersonnel.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Personnel personnel = (Personnel)lvwPersonnel.SelectedItems[0].Tag;
            FrmAjoutPersonnel frm = new FrmAjoutPersonnel(personnel);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChargerPersonnel();
            }
        }

        /// <summary>
        /// Clic sur le bouton Supprimer
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (lvwPersonnel.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Personnel personnel = (Personnel)lvwPersonnel.SelectedItems[0].Tag;
            if (MessageBox.Show("Voulez-vous vraiment supprimer " + personnel.Nom + " " + personnel.Prenom + " ?",
                "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controleur.SupprimerPersonnel(personnel.Id);
                ChargerPersonnel();
            }
        }

        /// <summary>
        /// Clic sur le bouton Gérer les absences
        /// </summary>
        private void btnGererAbsences_Click(object sender, EventArgs e)
        {
            if (lvwPersonnel.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Personnel personnel = (Personnel)lvwPersonnel.SelectedItems[0].Tag;
            FrmAbsences frm = new FrmAbsences(personnel);
            frm.ShowDialog();
        }
    }
}