using System;
using System.Collections.Generic;
using System.Web;

namespace terrasur
{
    public class FacturaPrincipal
    {
        private string _businessCode = "";
        private int _branchOfficeSiat = 0;
        private int _pointSaleSiat = 0;
        private int _documentSectorType = 0;
        private string _email = "";
        private bool _useCurrencyType = false;

        public string businessCode { get { return _businessCode; } set { _businessCode = value; } }
        public int branchOfficeSiat { get { return _branchOfficeSiat; } set { _branchOfficeSiat = value; } }
        public int pointSaleSiat { get { return _pointSaleSiat; } set { _pointSaleSiat = value; } }
        public int documentSectorType { get { return _documentSectorType; } set { _documentSectorType = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public bool useCurrencyType { get { return _useCurrencyType; } set { _useCurrencyType = value; } }

        public FacturaPrincipal()
        {

        }
    }
}