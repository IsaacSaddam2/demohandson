using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;



namespace Com.Cognizant.Truyum.Dao
{
    public class Helper
    {

        static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Saddhu\source\repos\TruYumConsole\TruyumConsole\TruYum.mdf;Integrated Security = True";

        public static string Constr
        {
            get => conStr;
        }
    }
}
