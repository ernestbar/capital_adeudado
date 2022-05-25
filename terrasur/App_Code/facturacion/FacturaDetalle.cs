using System;
using System.Collections.Generic;
using System.Web;

namespace terrasur
{
    public class FacturaDetalle
    {
        private string _codigoProducto = "";
        private string _descripcion = "";
        private string _cantidad = "";
        private string _precioUnitario = "";
        private string _montoDescuento = "";
        private string _subTotal = "";
        private string _numeroSerie = "";
        private string _numeroImei = "";

        public string codigoProducto { get { return _codigoProducto; } set { _codigoProducto = value; } }
        public string descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string cantidad { get { return _cantidad; } set { _cantidad = value; } }
        public string precioUnitario { get { return _precioUnitario; } set { _precioUnitario = value; } }
        public string montoDescuento { get { return _montoDescuento; } set { _montoDescuento = value; } }
        public string subTotal { get { return _subTotal; } set { _subTotal = value; } }
        public string numeroSerie { get { return _numeroSerie; } set { _numeroSerie = value; } }
        public string numeroImei { get { return _numeroImei; } set { _numeroImei = value; } }

        public FacturaDetalle()
        {

        }
    }
}