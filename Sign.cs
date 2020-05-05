using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bavito_server
{
    class Sign
    {
        public int Id;
        public string Name;
        public string Category;
        public SqlDateTime Date;
        public string Adress;
        public int Vievs;
        public int Price;
        public string Author;
        public string Status;
    }
}
