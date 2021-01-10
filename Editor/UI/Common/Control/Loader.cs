﻿using System.Windows.Forms;

namespace Common.Control
{
    public partial class Loader : UserControl
    {
        public Loader()
        {
            InitializeComponent();
        }

        public void SetStatus(string status) {
            lblStatus.Text = status;
        }
    }
}
