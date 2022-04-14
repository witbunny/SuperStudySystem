using aaaglb.Global;
using aaasrv.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aaaui.front.Controllers
{
    public class SharedController : Controller
    {
        public ActionResult _User()
		{
			UserModel model = new UserModel
			{
				Id = 1,
				Name = "leo"
			};

			return PartialView(model);
		}

        public ActionResult _GetCaptcha()
		{
			string code = "wert";
			Session[Keys.Captcha] = code;

			Bitmap image = new Bitmap(500, 200);
			Graphics g = Graphics.FromImage(image);
			g.Clear(Color.AliceBlue);

			g.DrawLine(new Pen(Color.Black), new Point(0, 0), new Point(300, 150));
			g.DrawString(code,
				new Font("宋体", 12),
				new SolidBrush(Color.DarkGray),
				new Point(20, 30));

			image.SetPixel(100, 100, Color.Orange);

			//image.Save(@"E:\echo\zero\adn\test\testing\hello.jpg", ImageFormat.Jpeg);

			MemoryStream stream = new MemoryStream();
			image.Save(stream, ImageFormat.Png);
			stream.Seek(0, SeekOrigin.Begin);

			return File(stream/*.ToArray()*/, "image/png");
		}
    }
}