using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Collections.Generic;
/// <summary>
/// Summary description for logica
/// </summary>
namespace terrasur
{
    public class logica
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas

        //Propiedades públicas
        #endregion

        #region Constructores
        public logica() { }
        #endregion

        #region Métodos que NO requieren constructor
        public static DateTime FechaProximoPago(DateTime Interes_fecha, DateTime PlanPago_fecha)
        {
            if (PlanPago_fecha.Day > 28)
                if (DateTime.DaysInMonth(Interes_fecha.Year, Interes_fecha.Month) == Interes_fecha.Day)
                    Interes_fecha = Interes_fecha.AddDays(1);

            int Interes_dia = Interes_fecha.Day;
            int PlanPago_dia = PlanPago_fecha.Day;
            if (Interes_dia > PlanPago_dia) return Interes_fecha.AddDays((-1) * (Interes_dia - PlanPago_dia)).AddMonths(1);
            else
            {
                if (Interes_dia == PlanPago_dia) return Interes_fecha.AddMonths(1);
                else return Interes_fecha.AddDays(PlanPago_dia - Interes_dia);
            }
        }

        public static DateTime FechaCobro(bool Preferencial, DateTime Fecha_prox)
        {
            if (Preferencial == true) return Fecha_prox;
            else return DateTime.Now;
        }

        public static bool TransaccionComisionable(bool Dpr, decimal Amortizacion)
        {
            if (Dpr == true) return false;
            else
            {
                if (Amortizacion > 0) return true;
                else return false;
            }
        }

        public static int NumMesesSeguroManten(DateTime Fecha_control, DateTime Fecha_cobro)
        {
            Fecha_control = Fecha_control.Date.AddDays(1).AddSeconds(-1);
            int num = 0;
            if (Fecha_control < Fecha_cobro)
            {
                DateTime Fecha_aux = Fecha_control;
                while (Fecha_aux < Fecha_cobro)
                {
                    num += 1;
                    Fecha_aux = Fecha_aux.AddMonths(1);
                }
            }
            return num;
        }

        public static bool ContratoEnMora(int Estado_contrato, bool Preferencial, DateTime Fecha_prox, DateTime Fecha_cobro, decimal Saldo)
        {
            if (Estado_contrato == 1 && Preferencial == false && Saldo > 0 && Fecha_cobro > Fecha_prox)
            {
                TimeSpan Tiempo = Fecha_cobro.Subtract(Fecha_prox);
                int Num_dias = Convert.ToInt32(Tiempo.TotalDays);
                int Plazo_mora = Convert.ToInt32(new parametro("plazo_mora").valor);
                if (Num_dias > Plazo_mora)
                    return true;
            }
            return false;
        }
        public static int AñosContrato(DateTime  Fecha_contrato, DateTime Fecha_ultimo_pago)
        {
            TimeSpan Tiempo = Fecha_ultimo_pago.Subtract(Fecha_contrato);
                int Num_años = (Tiempo.Days / 365);
                int Num_meses = 0;
                do
                {
                    for (int i = 0; i <= 12; i++)
                    {
                        if (Fecha_ultimo_pago.Subtract(Fecha_contrato.AddYears(Num_años).AddMonths(i)).Days >= 0)
                        {
                            Num_meses = i;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (Num_meses > 12) { Num_años = Num_años + 1; }
                } while (Num_meses > 12);
                //return Num_años + " años y " + Num_meses + " meses";
                return Num_años;
        }
        public static int MesesContrato(DateTime Fecha_contrato)
        {
            TimeSpan Tiempo = DateTime.Now.Subtract(Fecha_contrato);
            int Num_años = (Tiempo.Days / 365);
            int Num_meses = 0;
            do
            {
                for (int i = 0; i <= 12; i++)
                {
                    if (DateTime.Now.Subtract(Fecha_contrato.AddYears(Num_años).AddMonths(i)).Days >= 0)
                    {
                        Num_meses = i;
                    }
                    else
                    {
                        break;
                    }
                }

                if (Num_meses > 12) { Num_años = Num_años + 1; }
            } while (Num_meses > 12);
            //Total de meses
            Num_meses = Num_meses + (Num_años * 12);
            return Num_meses;
        }
        public static decimal ServicioLiquidacionITRCalculado(decimal Precio_venta_final, decimal Pagos_Dpr)
        {
            decimal ITR;
            ITR = (Precio_venta_final - Pagos_Dpr) * new parametro("it").valor;
            return ITR;
        }
        public static decimal ServicioLiquidacionDRECalculado(decimal Precio_venta_final, decimal Pagos_Dpr)
        {
            decimal DRE;
            DRE = (Precio_venta_final - Pagos_Dpr) * new parametro("ddrr").valor;
            return DRE;
        }
        public static decimal ServicioLiquidacionIMPCalculado(int Num_años_contrato, decimal Superficie_m2)
        {
            decimal IMP;
            IMP = (Num_años_contrato * Superficie_m2 * new parametro("factor_impuestos").valor);
            return IMP;
        }
        //public static int NumDiasInteres(bool Preferencial, string Codigo_negocio, DateTime Fecha_cobro, DateTime Fecha_interes, DateTime Fecha_prox)
        //{
        //    Fecha_interes = Fecha_interes.Date.AddDays(1).AddSeconds(-1);

        //    if (Preferencial == true) { return NumDiasDiferencia(Fecha_prox, Fecha_interes); }
        //    else { return NumDiasDiferencia(Fecha_cobro, Fecha_interes); }
        //}
        //public static int NumDiasInteres_Modificado(bool Preferencial, string Codigo_negocio, DateTime Fecha_cobro, DateTime Fecha_interes, DateTime Fecha_prox)
        //{
        //    Fecha_interes = Fecha_interes.Date.AddDays(1).AddSeconds(-1);

        //    if (Preferencial == true) { return NumDiasDiferencia(Fecha_prox, Fecha_interes); }
        //    else
        //    {
        //        if (Codigo_negocio != "nafibo") { return NumDiasDiferencia(Fecha_cobro, Fecha_interes); }
        //        else
        //        {
        //            if (Fecha_cobro.DayOfWeek == DayOfWeek.Saturday || Fecha_cobro.DayOfWeek == DayOfWeek.Sunday)
        //            {
        //                if (Fecha_cobro.DayOfWeek == DayOfWeek.Saturday)
        //                {
        //                    DateTime p_fecha_limite = parametro.ConvertDecimalToDateTime(Fecha_cobro, new parametro("fuera_hora_sabado_hora").valor);
        //                    if (Fecha_cobro < p_fecha_limite) { return NumDiasDiferencia(Fecha_cobro, Fecha_interes); }
        //                    else
        //                    {
        //                        Fecha_cobro = Fecha_cobro.AddDays(Convert.ToDouble(new parametro("fuera_hora_sabado_dias").valor));
        //                        return NumDiasDiferencia(Fecha_cobro, Fecha_interes);
        //                    }
        //                }
        //                else { return NumDiasDiferencia(Fecha_cobro, Fecha_interes); }
        //            }
        //            else
        //            {
        //                DateTime p_fecha_limite = parametro.ConvertDecimalToDateTime(Fecha_cobro, new parametro("fuera_hora_lun_vie_hora").valor);
        //                if (Fecha_cobro < p_fecha_limite) { return NumDiasDiferencia(Fecha_cobro, Fecha_interes); }
        //                else
        //                {
        //                    Fecha_cobro = Fecha_cobro.AddDays(Convert.ToDouble(new parametro("fuera_hora_lun_vie_dias").valor));
        //                    return NumDiasDiferencia(Fecha_cobro, Fecha_interes);
        //                }
        //            }
        //        }
        //    }
        //}
        //private static int NumDiasDiferencia(DateTime Fecha_cobro, DateTime Fecha_interes)
        //{
        //    if (Fecha_cobro > Fecha_interes)
        //    {
        //        TimeSpan Tiempo;
        //        Tiempo = Fecha_cobro.Subtract(Fecha_interes);
        //        return Convert.ToInt32(Tiempo.TotalDays);
        //    }
        //    else return 0;
        //}

        public static DateTime FechaCobroInteres(bool Preferencial, DateTime Fecha_cobro, DateTime Fecha_prox)
        {
            if (Preferencial == true) { return Fecha_prox; }
            else { return Fecha_cobro; }
        }
        public static DateTime FechaCobroInteres_Modificado(bool Preferencial, string Codigo_negocio, DateTime Fecha_cobro, DateTime Fecha_prox)
        {
            if (Preferencial == true) { return Fecha_prox; }
            else
            {
                if (Fecha_cobro.Date != DateTime.Now.Date) return Fecha_cobro;
                else
                {
                    if (Codigo_negocio != "nafibo") { return Fecha_cobro; }
                    else
                    {
                        string par_fuera_hora_sabado_hora = "fuera_hora_sabado_hora";
                        string par_fuera_hora_sabado_dias = "fuera_hora_sabado_dias";
                        string par_fuera_hora_lun_vie_hora = "fuera_hora_lun_vie_hora";
                        string par_fuera_hora_lun_vie_dias = "fuera_hora_lun_vie_dias";
                        if (int.Parse(ConfigurationManager.AppSettings["num_sucursal"]) > 0)
                        {
                            par_fuera_hora_sabado_hora = "sucursal_fuera_hora_sabado_hora";
                            par_fuera_hora_sabado_dias = "sucursal_fuera_hora_sabado_dias";
                            par_fuera_hora_lun_vie_hora = "sucursal_fuera_hora_lun_vie_hora";
                            par_fuera_hora_lun_vie_dias = "sucursal_fuera_hora_lun_vie_dias";
                        }
                        if (Fecha_cobro.DayOfWeek == DayOfWeek.Saturday || Fecha_cobro.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (Fecha_cobro.DayOfWeek == DayOfWeek.Saturday)
                            {
                                DateTime p_fecha_limite = parametro.ConvertDecimalToDateTime(Fecha_cobro, new parametro(par_fuera_hora_sabado_hora).valor);
                                if (Fecha_cobro < p_fecha_limite) { return Fecha_cobro; }
                                else { return Fecha_cobro.AddDays(Convert.ToDouble(new parametro(par_fuera_hora_sabado_dias).valor)); }
                            }
                            else { return Fecha_cobro; }
                        }
                        else
                        {
                            DateTime p_fecha_limite = parametro.ConvertDecimalToDateTime(Fecha_cobro, new parametro(par_fuera_hora_lun_vie_hora).valor);
                            if (Fecha_cobro < p_fecha_limite) { return Fecha_cobro; }
                            else { return Fecha_cobro.AddDays(Convert.ToDouble(new parametro(par_fuera_hora_lun_vie_dias).valor)); }
                        }
                    }
                }
            }
        }

        public static int NumCuotasAdeuda(DateTime Fecha_prox, DateTime Fecha_cobro)
        {
            //Fecha_prox = Fecha_prox.Date.AddDays(1).AddSeconds(-1);
            int num = 0;
            DateTime Fecha_aux = Fecha_prox;
            while (Fecha_aux < Fecha_cobro)
            {
                num += 1;
                Fecha_aux = Fecha_aux.AddMonths(1);
            }
            return num;
        }
        public static int NumDiasMora(int Estado_contrato, bool Preferencial, DateTime Fecha_prox, DateTime Fecha_cobro, decimal Saldo)
        {
            Fecha_prox = Fecha_prox.Date.AddDays(1).AddSeconds(-1);
            Fecha_cobro = Fecha_cobro.Date.AddDays(1).AddSeconds(-1);
            if (Estado_contrato == 1 && Preferencial == false && Saldo > 0 && Fecha_cobro > Fecha_prox)
            {
                TimeSpan Tiempo = Fecha_cobro.Subtract(Fecha_prox);
                int Num_dias = Convert.ToInt32(Tiempo.TotalDays);
                int Plazo_mora = Convert.ToInt32(new parametro("plazo_mora").valor);
                if (Num_dias > Plazo_mora)
                    return (Num_dias - Plazo_mora);
            }
            return 0;
        }

        public static int NumCuotasPagadas(DateTime Anterior_fecha_proximo, DateTime Nueva_fecha_interes)
        {
            Anterior_fecha_proximo = Anterior_fecha_proximo.Date.AddDays(1).AddSeconds(-1);
            Nueva_fecha_interes = Nueva_fecha_interes.Date.AddDays(1).AddSeconds(-1);
            int num = 0;
            DateTime Fecha_aux = Anterior_fecha_proximo;
            while (Fecha_aux < Nueva_fecha_interes)
            {
                num += 1;
                Fecha_aux = Fecha_aux.AddMonths(1);
            }
            return num;
        }

        // Facturacion Sintesis
        public static string MetodoPagoFacturacion(terrasur.tmpFormaPago metodoPago)
        {
            bool efectivo = false;
            bool tarjeta = false;
            bool cheque = false;
            bool deposito = false;
            string codigoMetodoPago = "";

            if (metodoPago.efectivo_bs > 0 || metodoPago.efectivo_sus > 0) {
                efectivo = true;
            }
            if (metodoPago.tarjeta_bs > 0 || metodoPago.tarjeta_sus > 0) {
                tarjeta = true;
            }
            if (metodoPago.cheque_bs > 0 || metodoPago.cheque_sus > 0) {
                cheque = true;
            }
            if (metodoPago.deposito_bs > 0 || metodoPago.deposito_sus > 0)
            {
                deposito = true;
            }

            if (efectivo == true && tarjeta == false && cheque == false && deposito == false) {
                codigoMetodoPago = "1";
            }
            if (efectivo == true && tarjeta == true && cheque == false && deposito == false)
            {
                codigoMetodoPago = "10";
            }
            if (efectivo == true && tarjeta == false && cheque == true && deposito == false)
            {
                codigoMetodoPago = "11";
            }
            if (efectivo == true && tarjeta == false && cheque == false && deposito == true)
            {
                codigoMetodoPago = "14";
            }
            if (tarjeta == true && efectivo == false && cheque == false && deposito == false)
            {
                codigoMetodoPago = "2";
            }
            if (cheque == true && efectivo == false && tarjeta == false && deposito == false)
            {
                codigoMetodoPago = "3";
            }
            if (deposito == true && efectivo == false && tarjeta == false && cheque == false)
            {
                codigoMetodoPago = "8";
            }

            return codigoMetodoPago;
        }

        public static bool ValidaEmail(string email) {
            string emailPattern = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            if (!(Regex.IsMatch(email, emailPattern)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool enviarCorreo(string urlFactura, string email, string subject)
        {
            try
            {
                string email_terra = "sistemas.bbr.renacer@gmail.com";
                System.Net.Mail.MailAddress eTerrasur = new MailAddress(email_terra);
                string linkFactura = urlFactura;
                System.Net.Mail.MailMessage mensaje = new System.Net.Mail.MailMessage();
                mensaje.From = eTerrasur;
                mensaje.To.Add(email);
                mensaje.Subject = subject;
                mensaje.IsBodyHtml = true;
                mensaje.Body = "Gracias por su pago, haciendo click en el link puede descargar su <b>FACTURA:</b> <br />" + linkFactura;
                System.Net.NetworkCredential nt = new System.Net.NetworkCredential("sistemas.bbr.renacer@gmail.com", "vxbfwiitkeswnncg");
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 465);
                sc.Port = 25;
                sc.EnableSsl = true;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nt;
                sc.Send(mensaje);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool enviarCorreoLista(List<string> urlFactura, string email, string subject)
        {
            try
            {
                string email_terra = "sistemas.bbr.renacer@gmail.com";
                System.Net.Mail.MailAddress eTerrasur = new MailAddress(email_terra);
                System.Net.Mail.MailMessage mensaje = new System.Net.Mail.MailMessage();
                mensaje.From = eTerrasur;
                mensaje.To.Add(email);
                mensaje.Subject = subject;
                mensaje.IsBodyHtml = true;
                mensaje.Body = "Gracias por su pago, haciendo click en los links puede descargar su(s) <b>FACTURA(S):</b> <br />";
                foreach (string linkFactura in urlFactura) 
                {
                    mensaje.Body = mensaje.Body + linkFactura + "<br />";
                }

                System.Net.NetworkCredential nt = new System.Net.NetworkCredential("sistemas.bbr.renacer@gmail.com", "vxbfwiitkeswnncg");
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 465);
                sc.Port = 25;
                sc.EnableSsl = true;
                sc.UseDefaultCredentials = false;
                sc.Credentials = nt;
                sc.Send(mensaje);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //

        #endregion

        #region Métodos que requieren constructor
        #endregion
    }
}