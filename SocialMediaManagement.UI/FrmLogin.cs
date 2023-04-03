using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaManagement.UI
{
	public partial class FrmLogin : Form
	{
		public FrmLogin()
		{
			InitializeComponent();
		}

		private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
		{
			tbUserPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '*';
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{

		}
	}
}
