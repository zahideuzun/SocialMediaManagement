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
using static SocialMediaManagement.UI.Validation.ExtensionMethod;

namespace SocialMediaManagement.UI
{
	public partial class FrmLogin : Form
	{
		FrmMainPage frmMainPage;
		private LogDAL logDal = null;
		UserDAL userDal = null;
		public FrmLogin()
		{
			InitializeComponent();
			tbUserPassword.PasswordChar = '*';
		}

		private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
		{
			tbUserPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '*';
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (Validation())
			{
				Login();
			}
			else
				MessageBox.Show("error!");
		}

		private int userId;
		void Login()
		{
			userDal = new UserDAL();
			userId = userDal.UserLogin(tbUserMailAddress.Text, tbUserPassword.Text);
			if (userId>1)
			{
				MessageBox.Show("Login Successful!");
				LogSuccess();
				frmMainPage = new FrmMainPage(userId);
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
			logDal.Insert(new Log()
				{ UserId = userId , LogTime = DateTime.Now, LogDescription = "User login is successful!", LogTypeId = 4 });
		}
		private bool Validation()
		{
			return ValidationTool.BosMu(tbUserMailAddress.Text, tbUserPassword.Text) && ValidationTool.BoslukVarMi(tbUserMailAddress.Text, tbUserPassword.Text) && ValidationTool.EmailKontrol(tbUserMailAddress.Text);
		}
	}
}
