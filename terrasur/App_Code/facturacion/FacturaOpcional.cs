using System;
using System.Collections.Generic;
using System.Web;

namespace terrasur
{
    public class FacturaOpcional
    {
        private string _key = "";
        private string _value = "";

        public string key { get { return _key; } set { _key = value; } }
        public string value { get { return _value; } set { _value = value; } }

        public FacturaOpcional()
        {

        }
    }
}