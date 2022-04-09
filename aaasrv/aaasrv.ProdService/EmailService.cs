using aaabll.Entities;
using aaabll.Repositories;
using aaasrv.ServiceInterface;
using aaasrv.ViewModel.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace aaasrv.ProdService
{
	public class EmailService : BaseService, IEmailService
	{
		private UserRepository userRepository;

		public EmailService()
		{
			userRepository = new UserRepository(Context);
		}

		public void Send(ActivateModel model)
		{
			User user = GetCurrentUser();
			int code = new Random().Next(1000, 9999);

			user.Email = model.Email;
			user.Code = code;
			user.HasValidated = false;
			userRepository.Update();

			MailMessage mail = new MailMessage
			{
				From = new MailAddress("welinc@163.com"),
				Subject = "Activate your Email",
				Body = $"Thanks for your registration, your code is {code}. click <a href='http://localhost:13060/Email/Validate?uid={user.Id}&code={code}'>Activate your Email</a> to complete activation. If the above link cannot be clicked, please copy the following text to the browser for activation: http://localhost:13060/Email/Validate?uid={user.Id}&code={code} .",
				IsBodyHtml = true
			};
			mail.To.Add(model.Email);

			SmtpClient client = new SmtpClient
			{
				Host = "smtp.163.com",
				Port = 25,//465 ssl
				Credentials = new NetworkCredential("welinc", "THKXBWOLFCSIETQC"),
				EnableSsl = false
			};
			client.Send(mail);
		}

		public bool Validate(int uid, int code)
		{
			User user = userRepository.Find(uid);
			bool isValid = user.Code == code;
			if (isValid)
			{
				user.HasValidated = true;
			} // else nothing
			userRepository.Update();
			return isValid;
		}
	}
}
