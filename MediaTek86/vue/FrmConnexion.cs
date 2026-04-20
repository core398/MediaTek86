using System;
using System.Windows.Forms;
using MediaTek86.controleur;
using MediaTek86.vue;

namespace MediaTek86.vue
{
    /// <summary>
    /// Formulaire de connexion à l'application
    /// </summary>
    public partial class FrmConnexion : Form
    {
        /// <summary>
        /// Instance du contrôleur
        /// </summary>
        private readonly Controleur controleur;

        /// <summary>
        /// Constructeur du formulaire de connexion
        /// </summary>
        public FrmConnexion()
        {
            InitializeComponent();
            controleur = Controleur.GetInstance();
        }

        /// <summary>
        /// Clic sur le bouton Se connecter
        /// </summary>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" || txtMotDePasse.Text == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (controleur.VerifierConnexion(txtLogin.Text, txtMotDePasse.Text))
            {
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                frmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.", "Erreur de connexion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotDePasse.Clear();
            }
        }
    }
}