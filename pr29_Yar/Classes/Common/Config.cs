using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr29_Yar.Classes.Common
{
    public class Config
    {
        public static string ConnectionConfig = "server=127.0.0.1;port=3306;uid=root;pwd=;database=films;SslMode=None;";

        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
