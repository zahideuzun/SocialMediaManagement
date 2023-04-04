using SocialMediaManagement.DataAccess.DAL;
using SocialMediaManagement.DataAccess.Entities.Enum;
using SocialMediaManagement.DataAccess.Entities;
using System;
using System.Windows.Forms;
using SocialMediaManagement.DataAccess.VM;
using static SocialMediaManagement.UI.Validation.ExtensionMethod;
using LogType = SocialMediaManagement.DataAccess.Entities.Enum.LogType;

namespace SocialMediaManagement.UI
{
	public partial class FrmMainPage : Form
	{
		private int _userId;
		LogDAL logDal = null;
		UserSocialMediaDAL userSocialMediaDal = null;
		UserLoginVM user = null;
		public FrmMainPage()
		{
			InitializeComponent();
		}

		public FrmMainPage(int userId) : this()
		{
			_userId = userId;
		}

		private void btnInstagramLogin_Click(object sender, EventArgs e)
		{
			if (Validation(tbInstagramUserName.Text, tbInstagramPassword.Text))
			{
				userSocialMediaDal = new UserSocialMediaDAL();
				user = userSocialMediaDal.UserSocialMediaLogin(_userId, Convert.ToInt16(SocialMediaType.Instagram), tbInstagramUserName.Text, tbInstagramPassword.Text);

				if (user != null)
				{
					MessageBox.Show($"Kullanıcı Adı: {user.Name} {user.Surname}");
					LogAdd(LogType.SuccessLogin, "Instagram login successful!");
				}
				else
				{
					MessageBox.Show("Başarısız");
					LogAdd(LogType.LoginFailed, "Instagram login failed!");
				}
			}
		}

		private void btnFacebookLogin_Click(object sender, EventArgs e)
		{
			Login(SocialMediaType.Facebook, tbFacebookUserName.Text, tbFacebookPassword.Text, "Facebook");
		}

		private void btnTwitterLogin_Click(object sender, EventArgs e)
		{
			Login(SocialMediaType.Twitter, tbTwitterUserName.Text, tbTwitterPassword.Text, "Twitter");
		}

		private void btnLinkedinLogin_Click(object sender, EventArgs e)
		{
			Login(SocialMediaType.Linkedin, tbLinkedinUserName.Text, tbLinkedinPassword.Text, "Linkedin");
		}
		public void LogAdd(LogType logType, string message)
		{
			logDal = new LogDAL();
			logDal.Insert(new Log()
			{
				LogTypeId = Convert.ToInt16(logType),
				UserId = _userId,
				LogTime = DateTime.Now,
				LogDescription = message
			});
		}
		private bool Validation(string email, string password)
		{
			return ValidationTool.BosMu(email, password) && ValidationTool.BoslukVarMi(email, password) /*&& ValidationTool.EmailKontrol(email)*/;
		}
		private void Login(SocialMediaType socialMediaType, string email, string password, string socialMediaName)
		{
			if (Validation(email, password))
			{
				userSocialMediaDal = new UserSocialMediaDAL();
				user = userSocialMediaDal.UserSocialMediaLogin(_userId, Convert.ToInt16(socialMediaType),
				email, password);

				if (user != null)
				{
					MessageBox.Show($"Username: {user.Username} \n {socialMediaName} login successful!");
					LogAdd(LogType.SuccessLogin, $"{socialMediaName} login successful!");
				}
				else
				{
					MessageBox.Show($"{socialMediaName} login failed!");
					LogAdd(LogType.LoginFailed, $"{socialMediaName}  login failed!");
				}
			}
			else MessageBox.Show("Please enter the information completely!!!");
		}
	}
}
