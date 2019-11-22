using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace jscreate
{
 

  class Class2
    {
        //public static SqlConnection SqlConn { get { return new SqlConnection(Config.ConvertString(System.Configuration.ConfigurationManager.ConnectionStrings["DBBusinessTrip"])); } }

        public SqlConnection baglan()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=192.168.150.2\dais;Initial Catalog=DAIRE;User ID=dais;Password=d@1s2014");

            baglan.Open();
            return baglan;

        }
        public int cmd(string sqlcumle)
        {
            SqlConnection baglan = this.baglan();
            SqlCommand cmd = new SqlCommand(sqlcumle, baglan);
            int sonuc = 0;
            try
            {
                sonuc = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message + "(" + sqlcumle + ")");
            }
            cmd.Dispose();
            baglan.Close();

            baglan.Dispose();
            return (sonuc);
        }
        public DataSet getdatagridview(string sqlcumle)
        {
            SqlConnection baglan = this.baglan();
            SqlDataAdapter dap = new SqlDataAdapter(sqlcumle, baglan);
            DataSet ds = new DataSet();
            try
            {
                dap.Fill(ds, "Person_Details");
                SqlCommandBuilder cmbld = new SqlCommandBuilder(dap);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message + "(" + sqlcumle + ")");
            }
            dap.Dispose();
            baglan.Close();
            baglan.Dispose();
            return ds;
        }
        public DataTable getdatatable(string sqlcumle)
        {
            SqlConnection baglan = this.baglan();
            SqlDataAdapter dap = new SqlDataAdapter(sqlcumle, baglan);
            DataTable dt = new DataTable();
            try
            {
                dap.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message + "(" + sqlcumle + ")");
            }

            dap.Dispose();
            baglan.Close();
            baglan.Dispose();
            return dt;
        }
        public DataRow GetDataRow(string sqlcumle)
        {
            DataTable dt = getdatatable(sqlcumle);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0];
        }
        public string getdatacell(string sqlcumle)
        {
            DataTable dt = getdatatable(sqlcumle);
            if (dt.Rows.Count == 0)
                return null;
            else
                return dt.Rows[0][0].ToString();
        }
        public static string vitrin(string vitrin)
        {
            string deger = "";
            if (vitrin == "1")
            {
                deger = "evet";
            }
            else
            {
                deger = "hayir";
            }
            return deger;
        }
        public static string vezife(string uygun)
        {
            string qiymet = "";
            if (uygun == "1")
            {
                qiymet = "Hə";
            }
            else
            {
                qiymet = "Yox";
            }
            return qiymet;
        }
        public static string vitrin2(string vitrin2)
        {
            string deger = "";
            if (vitrin2 == "1")
            {
                deger = "yok.png";
            }
            else
            {
                deger = "onay.png";
            }
            return deger;
        }
        public static string muracietebax(string muracietebax2)
        {
            string deger = "";
            if (muracietebax2 == "130")
            {
                deger = "true";
            }
            else
            {
                deger = "false";
            }
            return deger;
        }
        public static string sozukes(string kes)
        {
            string subString = "";
            if (kes.Length >= 10)
            {
                subString = kes.Substring(0, 10);

            }
            return subString;
        }
        public static string sozukes1(string kes)
        {
            string subString = "";
            if (kes.Length >= 10)
            {
                subString = kes.Substring(0, 5);

            }
            return subString;
        }
        public static string reng(string regideyiw)
        {
            string deger = "";
            if (regideyiw != "")
            {
                if (int.Parse(regideyiw) >= 10)
                {
                    deger = "Green";
                }
                else
                {
                    deger = "Red";
                }
            }
            return deger;
        }

        public static string notekrar(string notekrar1)
        {
            string deger = "";
            if (notekrar1 == "130")
            {
                deger = "true";
            }
            else
            {
                deger = "false";
            }
            return deger;
        }
        public static string planagirme(string planagirme2)
        {
            string deger = "";
            if (planagirme2 == "1" || planagirme2 == "2" || planagirme2 == "4")
            {
                deger = "false";
            }
            else
            {
                deger = "true";
            }
            return deger;
        }
        public static string planagirme1(string planagirme2)
        {
            string deger = "";
            if (planagirme2 == "1" || planagirme2 == "2" || planagirme2 == "4")
            {
                deger = "Təqdim olunub";
            }
            else
            {
                deger = "Təqdim olunmayıb";
            }
            return deger;
        }
        public static string planagirme2(string planagirme2)
        {
            string deger = "";
            if (planagirme2 == "1" || planagirme2 == "2" || planagirme2 == "4")
            {
                deger = "Green";
            }
            else
            {
                deger = "Red";
            }
            return deger;
        }


        public DataTable tekrarlama(string sutunadi, string sn, DataTable dt1)
        {
            dt1.Columns.Add(sn);
            int index = 1;
            if (dt1.Rows.Count > 0)
                dt1.Rows[0][sn] = index + ".";

            int m = 0;
            for (int i = 0; i < dt1.Rows.Count - 1; i++)
            {
                string birinci = dt1.Rows[m][sutunadi].ToString();
                if (birinci == dt1.Rows[i + 1][sutunadi].ToString())
                {
                    dt1.Rows[i + 1][sutunadi] = "";
                }
                else
                {
                    index++;
                    m = i + 1;
                    dt1.Rows[m][sn] = index + ".";
                }
            }
            return dt1;
        }
    }
}