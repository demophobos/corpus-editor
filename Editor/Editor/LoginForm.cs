using Model;
using Process;
using System;
using System.Windows.Forms;

namespace Editor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            var user = new UserModel
            {
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            var logged = await AuthProcess.Login(user).ConfigureAwait(true);

            if (logged)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
