using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bavito_server
{
    class SignUpdate
    {
        public string Name;
        public string Category;
        public string Adress;
        public string Price;
        public string GetParam(string ParamName)
        {
            string value = (string)typeof(SignUpdate).GetField(ParamName).GetValue(this);
            byte[] bytes = Encoding.Default.GetBytes(value);
            value = Encoding.UTF8.GetString(bytes);
            return value;
        }
    }

}
