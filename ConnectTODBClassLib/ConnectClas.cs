using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTODBClassLib
{
    public class ConnectClas
    {
        public static string _connStr;


        public ConnectClas(string connectStr)
        {
            _connStr = connectStr;
        }

        public static string GetString()
        {
            return _connStr;
        }
    }
}
