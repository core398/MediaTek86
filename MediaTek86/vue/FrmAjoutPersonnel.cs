using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.modele;

namespace MediaTek86.vue
{
    /// <summary>
    /// Formulaire d'ajout et de modification d'un personnel
    /// </summary>
    public partial class FrmAjoutPersonnel : Form
    {
        /// <summary>
        /// Instance du contrôleur
        /// </summary>
        private readonly Controleur controleur;

        /// <summary>
        /// Personnel à modifier (null si ajout)
        /// </summary>
        private readonly Personnel personnelAModifier;

        /// <summary>
        /// Constructeur pour l'ajout
        /// </summary>
        public FrmAjoutPersonnel()
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
            personnelAModifier = null;
        }

        /// <summary>
        /// Constructeur pour la modification
        /// </summary>
        public FrmAjoutPersonnel(Personnel personnel)
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
            personnelAModifier = personnel;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FrmAjoutPersonnel_Load(object sender, EventArgs e)
        {
            List<Service> services = controleur.GetAllServices();
            cmbService.DataSource = services;
            cmbService.DisplayMember = "Nom";
            cmbService.ValueMember = "Id";

            if (personnelAModifier != null)
            {
                this.Text = "Modifier un personnel";
                txtNom.Text = personnelAModifier.Nom;
                txtPrenom.Text = personnelAModifier.Prenom;
                txtTel.Text = personnelAModifier.Tel;
                txtMail.Text = personnelAModifier.Mail;
                cmbService.SelectedValue = personnelAModifier.IdService;
            }
        }

        /// <summary>
        /// Clic sur le bouton Enregistrer
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "" || txtPrenom.Text == "" || txtTel.Text == "" || txtMail.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Voulez-vous enregistrer ces informations ?", "Confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int idService = (int)cmbService.SelectedValue;

                if (personnelAModifier == null)
                {
                    controleur.AjouterPersonnel(txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, idService);
                }
                else
                {
                    controleur.ModifierPersonnel(personnelAModifier.Id, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, idService);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
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