using Model;
using Process;
using System;
using System.Windows.Forms;

namespace Auth
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            txtAPI.Text = Properties.Settings.Default.APIAuthUrl;

            txtEmail.Text = Properties.Settings.Default.Email;

            txtPassword.Text = Properties.Settings.Default.Pwd;
        }

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {

            Properties.Settings.Default.APIAuthUrl = txtAPI.Text;

            Properties.Settings.Default.APIBaseUrl = txtAPI.Text.Trim('/') + "/v1/";

            Properties.Settings.Default.Save();

            var user = new UserModel
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var logged = await AuthProcess.Login(user, Properties.Settings.Default.APIAuthUrl).ConfigureAwait(true);

            if (logged)
            {

                Properties.Settings.Default.Email = user.Email;

                Properties.Settings.Default.Pwd = user.Password;

                Properties.Settings.Default.Save();

                DialogResult = DialogResult.OK;
            }
        }

        private void txtAPI_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = txtAPI.Text.Length > 0 
                && txtEmail.Text.Length > 0 
                && txtPassword.Text.Length > 0 
                && Uri.IsWellFormedUriString(txtAPI.Text, UriKind.Absolute);
        }
    }
}
