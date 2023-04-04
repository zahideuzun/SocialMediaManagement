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
					LogAdd(LogType.SuccessLogin, "Instagram Giriş Başarılı");
				}
				else
				{
					MessageBox.Show("Başarısız");
					LogAdd(LogType.LoginFailed, "Instagram Başarısız Giriş");
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
				LogId = Convert.ToInt16(logType),
				UserId = _userId,
				LogTime = DateTime.Now,
				LogDescription = message
			});
		}
		private bool Validation(string email, string password)
		{
			return ValidationTool.BosMu(email, password) && ValidationTool.BoslukVarMi(email, password) && ValidationTool.EmailKontrol(email);
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
					MessageBox.Show($"Kullanıcı Adı: {user.Name} {user.Surname} \n {socialMediaName} Giriş Başarılı");
					LogAdd(LogType.SuccessLogin, $"{socialMediaName} Giriş Başarılı");
				}
				else
				{
					MessageBox.Show($"{socialMediaName} Giriş Başarısız");
					LogAdd(LogType.Error, $"{socialMediaName}  Başarısız Giriş");
				}
			}
			else MessageBox.Show("Bilgileri Eksiksiz Giriniz!!!");
		}
	}
}
