using System;
using System.Collections.Generic;
using System.Web;

namespace terrasur
{
    public class FacturaCabecera
    {
        private string _numeroFactura = "";
        private string _nombreRazonSocial = "";
        private string _codigoTipoDocumentoIdentidad = "";
        private string _numeroDocumento = "";
        private string _complemento = "";
        private string _codigoCliente = "";
        private string _codigoMetodoPago = "";
        private string _numeroTarjeta = "";
        private string _montoTotal = "";
        private string _montoTotalSujetoIva = "";
        private string _codigoMoneda = "";
        private string _tipoCambio = "";
        private string _montoTotalMoneda = "";
        private string _montoGiftCard = "";
        private string _descuentoAdicional = "";
        private string _codigoExcepcion = "";
        private string _usuario = "";

        public string numeroFactura { get { return _numeroFactura; } set { _numeroFactura = value; } }
        public string nombreRazonSocial { get { return _nombreRazonSocial; } set { _nombreRazonSocial = value; } }
        public string codigoTipoDocumentoIdentidad { get { return _codigoTipoDocumentoIdentidad; } set { _codigoTipoDocumentoIdentidad = value; } }
        public string numeroDocumento { get { return _numeroDocumento; } set { _numeroDocumento = value; } }
        public string complemento { get { return _complemento; } set { _complemento = value; } }
        public string codigoCliente { get { return _codigoCliente; } set { _codigoCliente = value; } }
        public string codigoMetodoPago { get { return _codigoMetodoPago; } set { _codigoMetodoPago = value; } }
        public string numeroTarjeta { get { return _numeroTarjeta; } set { _numeroTarjeta = value; } }
        public string montoTotal { get { return _montoTotal; } set { _montoTotal = value; } }
        public string montoTotalSujetoIva { get { return _montoTotalSujetoIva; } set { _montoTotalSujetoIva = value; } }
        public string codigoMoneda { get { return _codigoMoneda; } set { _codigoMoneda = value; } }
        public string tipoCambio { get { return _tipoCambio; } set { _tipoCambio = value; } }
        public string montoTotalMoneda { get { return _montoTotalMoneda; } set { _montoTotalMoneda = value; } }
        public string montoGiftCard { get { return _montoGiftCard; } set { _montoGiftCard = value; } }
        public string descuentoAdicional { get { return _descuentoAdicional; } set { _descuentoAdicional = value; } }
        public string codigoExcepcion { get { return _codigoExcepcion; } set { _codigoExcepcion = value; } }
        public string usuario { get { return _usuario; } set { _usuario = value; } }

        public FacturaCabecera()
        {

        }
    }
}