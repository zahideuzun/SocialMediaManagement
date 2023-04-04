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
		#region Instances

		private int _userId;
		LogDAL logDal = null;
		UserSocialMediaDAL userSocialMediaDal = null;
		UserLoginVM user = null;

		#endregion 

		public FrmMainPage()
		{
			InitializeComponent();
		}

		public FrmMainPage(int userId) : this()
		{
			_userId = userId;
			PasswordChar();
		}

		private void btnInstagramLogin_Click(object sender, EventArgs e)
		{
			if (Validation(tbInstagramUserName.Text, tbInstagramPassword.Text))
			{
				userSocialMediaDal = new UserSocialMediaDAL();
				user = userSocialMediaDal.UserSocialMediaLogin(_userId, Convert.ToInt16(SocialMediaType.Instagram), tbInstagramUserName.Text, tbInstagramPassword.Text);

				if (user != null)
				{
					MessageBox.Show($"Username: {user.Name} {user.Surname}");
					CleanTexbox();
					LogAdd(LogType.SuccessLogin, "Instagram login successful!");
				}
				else
				{
					MessageBox.Show("Login Failed!!");
					CleanTexbox();
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

		#region Methods

		/// <summary>
		/// her giris sonrasi giris sonucuna göre log tablosuna ekleme yapan metot
		/// </summary>
		/// <param name="logType"></param>
		/// <param name="message"></param>
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

		/// <summary>
		/// textboxlarin dogru girisini kontrol eden metot.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		private bool Validation(string email, string password)
		{
			return ValidationTool.BosMu(email, password) && ValidationTool.BoslukVarMi(email, password) /*&& ValidationTool.EmailKontrol(email)*/;
		}

		/// <summary>
		/// login islemini yapan metot.
		/// </summary>
		/// <param name="socialMediaType"></param>
		/// <param name="email"></param>
		/// <param name="password"></param>
		/// <param name="socialMediaName"></param>
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
					CleanTexbox();
					LogAdd(LogType.SuccessLogin, $"{socialMediaName} login successful!");
				}
				else
				{
					MessageBox.Show($"{socialMediaName} login failed!");
					CleanTexbox();
					LogAdd(LogType.LoginFailed, $"{socialMediaName}  login failed!");
				}
			}
			else MessageBox.Show("Please enter the information completely!!!");
		}

		/// <summary>
		/// sifre textboxlarini maskeleyen metot
		/// </summary>
		public void PasswordChar()
		{
			tbInstagramPassword.PasswordChar = '*';
			tbTwitterPassword.PasswordChar = '*';
			tbFacebookPassword.PasswordChar = '*';
			tbLinkedinPassword.PasswordChar = '*';
		}

		/// <summary>
		/// giris yapildiktan sonra textboxlari temizleyen metot.
		/// </summary>
		public void CleanTexbox()
		{
			tbFacebookPassword.Text = tbTwitterPassword.Text = tbInstagramPassword.Text = tbLinkedinPassword.Text
				= tbFacebookUserName.Text =
					tbTwitterUserName.Text = tbLinkedinUserName.Text = tbInstagramUserName.Text = null;
		}

		#endregion


		#region ShowPasswordCheckbox

		private void chbShowPasswordInstagram_CheckedChanged(object sender, EventArgs e)
		{
			tbInstagramPassword.PasswordChar = chbShowPasswordInstagram.Checked ? '\0' : '*';
		}

		private void cbShowPasswordFacebook_CheckedChanged(object sender, EventArgs e)
		{
			tbFacebookPassword.PasswordChar = cbShowPasswordFacebook.Checked ? '\0' : '*';
		}

		private void cbShowPasswordTwitter_CheckedChanged(object sender, EventArgs e)
		{
			tbTwitterPassword.PasswordChar = cbShowPasswordTwitter.Checked ? '\0' : '*';
		}

		private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
		{
			tbLinkedinPassword.PasswordChar = cbShowPassword.Checked ? '\0' : '*';
		}

		#endregion
	}
}
