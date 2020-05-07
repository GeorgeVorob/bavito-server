using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bavito_server
{
    class SearchInput
    {
        public string Name;
        public string Category;
        public string Datefrom;
        public string Dateto;
        public string Pricefrom;
        public string Priceto;
        public string GetParam(string ParamName)
        {
            try
            {
                string value = (string)typeof(SearchInput).GetField(ParamName).GetValue(this);
                byte[] bytes = Encoding.Default.GetBytes(value);
                value = Encoding.UTF8.GetString(bytes);
                return value;
            }
            catch
            {
                return null;
            }
        }
    }
}
