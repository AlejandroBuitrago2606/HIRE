using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace HIRE.Logica
{
    public class clEnviarCorreoL
    {

        public bool enviarCorreo(string Destinatario, string nombre, string asunto, string cuerpo)
        {
            bool validacion = false;


            try
            {
                var remitente = new MailAddress("alejo.yb06@gmail.com", "Equipo de cuentas de HIRE");
                var destinatario = new MailAddress(Destinatario, nombre);
                const string contrasenaRemitente = "zhqf owkv hptj xnnd";

                var smtp = new SmtpClient
                {

                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(remitente.Address, contrasenaRemitente)

                };

                using (var mensaje = new MailMessage(remitente, destinatario)
                {

                    Subject = asunto,
                    Body = cuerpo

                })
                {
                    smtp.Send(mensaje);
                    validacion = true;

                }


            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                validacion = false;
            }

            return validacion;


        }


    }
}