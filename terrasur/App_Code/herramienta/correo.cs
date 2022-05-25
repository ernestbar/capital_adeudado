using System;
using System.Net; // Nueva
using System.Net.Mail;

namespace terrasur
{
    public class correo
    {
        public static bool EnviarCorreo(string mensaje, string email)
        {
            try
            {
                MailMessage msg = new MailMessage();
                string[] correos = email.Split('|');
                for (int i = 0; i < correos.Length; i++)
                {
                    msg.To.Add(new MailAddress(correos[i]));
                }
                msg.From = new MailAddress("sistemas@terrasur.com.bo");
                msg.Subject = "Migracion Cartera - Odoo " + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;
                msg.Body = mensaje;

                System.Net.NetworkCredential nt = new System.Net.NetworkCredential("sistemas.bbr.renacer@gmail.com", "$erV1dorNube##Bk%%BbR&&RenaceR");
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 465);
                sc.Port = 25;
                sc.EnableSsl = true;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nt;

                sc.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Console.Write(ex.Message);
                //Console.ReadLine();
            }
        }
    }
}