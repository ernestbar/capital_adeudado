using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public class funciones
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void marketing_AsignarComicionesCicloComercial(SqlInt32 id_ciclocomercial)
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();

            //Se obtiene y recorre la lista de promotores que fueron asignados a contratos cuya cuota inicial se pagó dentro de un ciclo comercial
            DataTable tabla_promotor = new DataTable();
            SqlCommand cmd_promotor = new SqlCommand("marketing_AsignarComision_ListaPromotor", conn);
            cmd_promotor.CommandType = CommandType.StoredProcedure;
            cmd_promotor.Parameters.Add(new SqlParameter("@id_ciclocomercial", id_ciclocomercial));
            da.SelectCommand = cmd_promotor;
            da.Fill(tabla_promotor);

            foreach (DataRow fila_promotor in tabla_promotor.Rows)
            {
                DataTable tabla_contrato = new DataTable();
                SqlCommand cmd_contrato = new SqlCommand("marketing_AsignarComision_ListaContrato", conn);
                cmd_contrato.CommandType = CommandType.StoredProcedure;
                cmd_contrato.Parameters.Add(new SqlParameter("@id_ciclocomercial", id_ciclocomercial));
                cmd_contrato.Parameters.Add(new SqlParameter("@id_promotor", (int)fila_promotor["id_promotor"]));
                SqlParameter p_id_parametrocomisionpromotor = new SqlParameter("@id_parametrocomisionpromotor", SqlDbType.Int, 32);
                p_id_parametrocomisionpromotor.Direction = ParameterDirection.Output;
                cmd_contrato.Parameters.Add(p_id_parametrocomisionpromotor);
                da.SelectCommand = cmd_contrato;
                da.Fill(tabla_contrato);

                foreach (DataRow fila_contrato in tabla_contrato.Rows)
                {
                    DataTable tabla_pago = new DataTable();
                    SqlCommand cmd_pago = new SqlCommand("marketing_AsignarComision_ListaPago", conn);
                    cmd_pago.CommandType = CommandType.StoredProcedure;
                    cmd_pago.Parameters.Add(new SqlParameter("@id_contrato", (int)fila_contrato["id_contrato"]));
                    cmd_pago.Parameters.Add(new SqlParameter("@id_parametrocomisionpromotor", (int)p_id_parametrocomisionpromotor.Value));
                    da.SelectCommand = cmd_pago;
                    da.Fill(tabla_pago);

                    foreach (DataRow fila_pago in tabla_pago.Rows)
                    {
                        SqlCommand cmd_pago_comisionar = new SqlCommand("marketing_AsignarComision_ComisionarPago", conn);
                        cmd_pago_comisionar.CommandType = CommandType.StoredProcedure;
                        cmd_pago_comisionar.Parameters.Add(new SqlParameter("@p_id_pago", (int)fila_pago["id_pago"]));
                        int aux = cmd_pago_comisionar.ExecuteNonQuery();
                    }
                }
            }
        }
    }

    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void contrato_RevertirPreasignados()
    {
        using (SqlConnection conn = new SqlConnection("context connection=true"))
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            //Se obtiene y recorre la lista de contratos cuyo plazo de preasignación terminó
            DataTable tabla_contrato = new DataTable();
            SqlCommand cmd_contrato = new SqlCommand("contrato_RevertirPreasignados_ListaContrato", conn);
            cmd_contrato.CommandType = CommandType.StoredProcedure;

            SqlParameter p_id_usuario = new SqlParameter("@id_usuario", SqlDbType.Int, 32);
            SqlParameter p_id_motivoreversion = new SqlParameter("@id_motivoreversion", SqlDbType.Int, 32);
            p_id_usuario.Direction = ParameterDirection.Output;
            p_id_motivoreversion.Direction = ParameterDirection.Output;
            cmd_contrato.Parameters.Add(p_id_usuario);
            cmd_contrato.Parameters.Add(p_id_motivoreversion);

            da.SelectCommand = cmd_contrato;
            da.Fill(tabla_contrato);
            int auxInt = 0; decimal auxDecimal = 0;
            foreach (DataRow fila_contrato in tabla_contrato.Rows)
            {
                SqlCommand cmd_revertir_contrato = new SqlCommand("reversion_Insertar", conn);
                cmd_revertir_contrato.CommandType = CommandType.StoredProcedure;
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@id_usuario_r", (int)p_id_usuario.Value));
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@id_contrato_r", (int)fila_contrato["id_contrato"]));
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@id_motivoreversion_r", (int)p_id_motivoreversion.Value));
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@dias_mora_r", auxInt));
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@cuotas_mora_r", auxInt));
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@capital_pagado_r", auxDecimal));
                cmd_revertir_contrato.Parameters.Add(new SqlParameter("@capital_adeuda_r", (decimal)fila_contrato["precio_final"]));
                int aux = cmd_revertir_contrato.ExecuteNonQuery();
            }
        }
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static DateTime FechaProximoPago(DateTime Interes_fecha, DateTime PlanPago_fecha)
    {
        int Interes_dia = Interes_fecha.Day;
        int PlanPago_dia = PlanPago_fecha.Day;
        if (Interes_dia > PlanPago_dia) return Interes_fecha.AddDays((-1) * (Interes_dia - PlanPago_dia));
        else
        {
            if (Interes_dia == PlanPago_dia) return Interes_fecha.AddMonths(1);
            else return Interes_fecha.AddDays(PlanPago_dia - Interes_dia);
        }
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static bool TransaccionComisionable(bool Dpr, decimal Amortizacion)
    {
        if (Dpr == true) return false;
        else
        {
            if (Amortizacion > 0) return true;
            else return false;
        }
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static int NumCuotasAdeuda(DateTime Fecha_prox, DateTime Fecha_cobro)
    {
        Fecha_prox = Fecha_prox.Date.AddDays(1).AddSeconds(-1);
        int num = 0;
        if (Fecha_cobro > Fecha_prox)
        {
            DateTime Fecha_aux = Fecha_prox;
            while (Fecha_aux < Fecha_cobro)
            {
                num += 1;
                Fecha_aux = Fecha_aux.AddMonths(1);
            }
        }
        return num;
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static string ObtenerCodigo(string num_autorizacion, string num_factura,
        string nit_cliente, string fecha_emision, string monto_bs, string llave_dosificacion)
    {
        string autoriza = num_autorizacion.Trim();
        string factura = num_factura.Trim();

        string nit_ci;
        long n;
        if (long.TryParse(nit_cliente.Trim(), out n) == true) nit_ci = n.ToString();
        else nit_ci = "0";

        string fecha;
        DateTime f;
        if (DateTime.TryParse(fecha_emision, out f) == true) fecha = f.ToString("yyyyMMdd");
        else fecha = DateTime.Now.ToString("yyyyMMdd");
        string monto;
        decimal m;
        if (decimal.TryParse(monto_bs.Trim(), out m) == true) monto = Math.Round(m, 0).ToString();
        else monto = "0";

        string llave = llave_dosificacion.Trim();

        //Paso 1
        factura += ObtenerVerhoeff_N_Digitos(factura, 2);
        nit_ci += ObtenerVerhoeff_N_Digitos(nit_ci, 2);
        fecha += ObtenerVerhoeff_N_Digitos(fecha, 2);
        monto += ObtenerVerhoeff_N_Digitos(monto, 2);
        long sum = long.Parse(factura) + long.Parse(nit_ci) + long.Parse(fecha) + long.Parse(monto);
        char[] Verhoeff5 = ObtenerVerhoeff_N_Digitos(sum.ToString(), 5).ToCharArray();

        //Paso 2
        int num1 = int.Parse(Verhoeff5[0].ToString()) + 1;
        int num2 = int.Parse(Verhoeff5[1].ToString()) + 1;
        int num3 = int.Parse(Verhoeff5[2].ToString()) + 1;
        int num4 = int.Parse(Verhoeff5[3].ToString()) + 1;
        int num5 = int.Parse(Verhoeff5[4].ToString()) + 1;
        autoriza += llave.Substring(0, num1);
        factura += llave.Substring(num1, num2);
        nit_ci += llave.Substring(num1 + num2, num3);
        fecha += llave.Substring(num1 + num2 + num3, num4);
        monto += llave.Substring(num1 + num2 + num3 + num4, num5);

        //Paso 3
        char[] cad_con = CifrarMensajeRC4(autoriza + factura + nit_ci + fecha + monto, llave + Verhoeff5[0] + Verhoeff5[1] + Verhoeff5[2] + Verhoeff5[3] + Verhoeff5[4]).Replace("-", "").ToCharArray();

        //Paso 4
        int ST = 0, SP1 = 0, SP2 = 0, SP3 = 0, SP4 = 0, SP5 = 0;
        for (int i = 0; i < cad_con.Length; i++) ST += Convert.ToByte(cad_con[i]);
        for (int i = 0; i < cad_con.Length; i = i + 5) SP1 += Convert.ToByte(cad_con[i]);
        for (int i = 1; i < cad_con.Length; i = i + 5) SP2 += Convert.ToByte(cad_con[i]);
        for (int i = 2; i < cad_con.Length; i = i + 5) SP3 += Convert.ToByte(cad_con[i]);
        for (int i = 3; i < cad_con.Length; i = i + 5) SP4 += Convert.ToByte(cad_con[i]);
        for (int i = 4; i < cad_con.Length; i = i + 5) SP5 += Convert.ToByte(cad_con[i]);

        //Paso 5
        int RES = (int)Math.Truncate(Convert.ToDecimal(ST * SP1) / Convert.ToDecimal(num1)) +
            (int)Math.Truncate(Convert.ToDecimal(ST * SP2) / Convert.ToDecimal(num2)) +
            (int)Math.Truncate(Convert.ToDecimal(ST * SP3) / Convert.ToDecimal(num3)) +
            (int)Math.Truncate(Convert.ToDecimal(ST * SP4) / Convert.ToDecimal(num4)) +
            (int)Math.Truncate(Convert.ToDecimal(ST * SP5) / Convert.ToDecimal(num5));
        string RES_BASE64 = ObtenerBase64(RES);

        //Paso 6
        return CifrarMensajeRC4(RES_BASE64, llave + Verhoeff5[0] + Verhoeff5[1] + Verhoeff5[2] + Verhoeff5[3] + Verhoeff5[4]);
    }

    //Algoritmo Base 64
    private static string ObtenerBase64(int Numero)
    {
        char[] Dicionario ={ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '+', '/' };
        int Cociente = 1, Resto;
        string Palabra = "";
        while (Cociente > 0)
        {
            Cociente = Numero / 64;
            Resto = Numero % 64;
            Palabra = Dicionario[Resto] + Palabra;
            Numero = Cociente;
        }
        return Palabra;
        //System.Text.StringBuilder ab = new System.Text.StringBuilder();
    }

    //Algoritmo Alleged RC4
    private static string CifrarMensajeRC4(string _mensaje, string _key)
    {
        char[] mensaje = _mensaje.ToCharArray();
        char[] key = _key.ToCharArray();

        int[] State = new int[256];
        int X = 0, Y = 0, Index1 = 0, Index2 = 0, NMen, i;
        string MensajeCifrado = "";
        for (i = 0; i < 256; i++) State[i] = i;
        for (i = 0; i < 256; i++)
        {
            Index2 = (Convert.ToByte(key[Index1]) + State[i] + Index2) % 256;
            //IntercambiaValor(State[i],State[Index2])
            int aux = State[i];
            State[i] = State[Index2];
            State[Index2] = aux;

            Index1 = (Index1 + 1) % key.Length;
        }
        for (i = 0; i < mensaje.Length; i++)
        {
            X = (X + 1) % 256;
            Y = (State[X] + Y) % 256;
            //IntercambiaValor(State[X],State[Y])
            int aux = State[X];
            State[X] = State[Y];
            State[Y] = aux;

            NMen = Convert.ToByte(mensaje[i]) ^ State[(State[X] + State[Y]) % 256];
            MensajeCifrado = MensajeCifrado + "-" + RellenaCero_ConvierteAHexadecimal(NMen);
        }
        return MensajeCifrado.Substring(1, MensajeCifrado.Length - 1);
    }
    private static string RellenaCero_ConvierteAHexadecimal(int deci)
    {
        string hexa = string.Format("{0:x}", deci).ToUpper();
        if (hexa.Length == 1) return "0" + hexa;
        else return hexa;
    }

    //Para el Algoritmo "Verhoeff"
    private static string ObtenerVerhoeff_N_Digitos(string cifra, int n)
    {
        System.Text.StringBuilder Num = new System.Text.StringBuilder();
        System.Text.StringBuilder Cifra = new System.Text.StringBuilder(cifra);
        for (int i = 0; i < n; i++)
        {
            string Verhoeff = ObtenerVerhoeff(Cifra.ToString()).ToString();
            Num.Append(Verhoeff);
            Cifra.Append(Verhoeff);
        }
        return Num.ToString();
    }
    private static int ObtenerVerhoeff(string cifra)
    {
        int[,] Mul = { { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 }, { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 }, { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 }, { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 }, { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 }, { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 }, { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 }, { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 }, { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 } };
        int[,] Per = { { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 }, { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 }, { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 }, { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 }, { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 }, { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 }, { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 } };
        int[] Inv ={ 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };
        int Check = 0;
        char[] NumeroInvertido = cifra.ToCharArray();
        Array.Reverse(NumeroInvertido);
        for (int i = 0; i < NumeroInvertido.Length; i++) { Check = Mul[Check, Per[((i + 1) % 8), Int32.Parse(NumeroInvertido[i].ToString())]]; }
        return Inv[Check];
    }

}
