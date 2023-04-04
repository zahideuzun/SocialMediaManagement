using SocialMediaManagement.DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialMediaManagement.DataAccess.Entities;

namespace SocialMediaManagement.UI
{
	public partial class FrmLogin : Form
	{
		FrmMainPage frmMainPage;
		private LogDAL logDal = null;
		UserDAL userDal = null;
		User user = null;
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
			Login();
		}

		void Login()
		{
			userDal = new UserDAL();
			userDal.UserLogin(tbUserMailAddress.Text, tbUserPassword.Text);
			if (Validation())
			{
				MessageBox.Show("Login Successful!");
				LogSuccess();
				frmMainPage = new FrmMainPage();
				frmMainPage.Show();
			}
			else
			{
				MessageBox.Show("Login failed!");
				LogFailed();
			}
			
		}
		void LogFailed()
		{
			logDal = new LogDAL();
			logDal.Insert(new Log()
				{ UserId = 1, LogTime = DateTime.Now, LogDescription = "User login is failed!", LogTypeId = 5 });
		}

		void LogSuccess()
		{
			logDal = new LogDAL();
			user = new User();
			logDal.Insert(new Log()
				{ UserId = user.UserId , LogTime = DateTime.Now, LogDescription = "User login is successful!", LogTypeId = 4 });
		}
		private bool Validation()
		{
			return true;
		}
	}
}
