using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using jscreate;

namespace javascriptcreate
{
    public partial class Form1 : Form
    {
        Class2 klas = new Class2();
        public Form1()
        {
            InitializeComponent();
        }

        private void javascript_Click(object sender, EventArgs e)
        {

            string root = @"C:\Documents and Settings\user\Рабочий стол\jscreate\poi";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            DataTable dtGruplar = klas.getdatatable(@"

SELECT    UPPER(Replace( Replace(Replace(d.unvan,CHAR(13)+CHAR(10),''),CHAR(34),CHAR(39)),'\','/'))  as dskunvan,CONVERT(varchar,d.dsk_n) +' '+ UPPER(Replace( Replace( Replace(d.dsk_ad,CHAR(13)+CHAR(10),''),CHAR(34),CHAR(39)),'\','/')) as dsk_ad,
d.ggx,d.ggy,d.dsk_n,m.mnt_n,m.ggx as mggx ,m.ggy as mggy,m.mnt_nv,
CONVERT(varchar,m.mnt_n) +N' SAYLI SEÇKİ MƏNTƏQƏSİ <br> '+ UPPER(Replace(Replace(Replace(m.unvan,CHAR(13)+CHAR(10),'') ,CHAR(34),CHAR(39)),'\','/')) as menunvan,
CONVERT(varchar,m.mnt_n) +N' SAYLI SEÇKİ MƏNTƏQƏSİ' as seckimen

FROM         daire as d INNER JOIN 
                menteqe as m ON d.dsk_n = m.dsk_n 
         where (m.ggx <> '0' or m.ggy <> '0')  and m.mnt_nv=1 
         order by dsk_n,mnt_n
");

            string s1 = "";
            
            for (var i = 0; i < dtGruplar.Rows.Count; i++)
            {
                if (i != 0)
                {
                    if (dtGruplar.Rows[i - 1]["dsk_n"].ToString() != dtGruplar.Rows[i]["dsk_n"].ToString())
                    {
                        s1 = "";
                    }
                }
                s1 = s1 + System.Environment.NewLine + "{" + '"' + "id" + '"' + ":" + '"' + dtGruplar.Rows[i]["mnt_n"].ToString() + '"'+","+
                   System.Environment.NewLine + '"' + "x" + '"' + ":" + '"' + dtGruplar.Rows[i]["mggx"].ToString() + '"' + "," +
                   System.Environment.NewLine + '"' + "y" + '"' + ":" + '"' + dtGruplar.Rows[i]["mggy"].ToString() + '"' + "," +
                   System.Environment.NewLine + '"' + "nm" + '"' + ":" + '"' + dtGruplar.Rows[i]["seckimen"].ToString() + '"' + "," +
                   System.Environment.NewLine + '"' + "addr" + '"' + ":" + '"' + dtGruplar.Rows[i]["menunvan"].ToString() + '"' + "},";
                if (i != 0 && i != dtGruplar.Rows.Count-1)
                {
                    if (dtGruplar.Rows[i ]["dsk_n"].ToString() != dtGruplar.Rows[i+1]["dsk_n"].ToString())
                    {
                        s1 = s1.Substring(0, s1.Length-1);
                        richTextBox1.Text = s1;   
                    }
                }
                else if (i != 0 && i == dtGruplar.Rows.Count-1)
                {
                    s1 = s1.Substring(0, s1.Length-1);
                }
                TextWriter tw = new StreamWriter(@"C:\Documents and Settings\user\Рабочий стол\jscreate\poi\" + dtGruplar.Rows[i]["dsk_n"] + ".js");
                tw.WriteLine("{" + '"' + "Number" + '"' + ":" + '"' + dtGruplar.Rows[i]["dsk_n"].ToString() + '"' + ',' +
         System.Environment.NewLine + '"' + "x" + '"' + ":" + '"' + dtGruplar.Rows[i]["ggx"].ToString() + '"'+"," +
         System.Environment.NewLine + '"' + "y" + '"' + ":" + '"' + dtGruplar.Rows[i]["ggy"].ToString() + '"' + "," +
         System.Environment.NewLine + '"' + "z" + '"' + ":" + '"' + "3" + '"' + "," +
         System.Environment.NewLine + '"' + "nm" + '"' + ":" + '"' + dtGruplar.Rows[i]["dsk_ad"].ToString() + '"' + "," +
         System.Environment.NewLine + '"' + "addr" + '"' + ":" + '"' + dtGruplar.Rows[i]["dsk_ad"].ToString() + " <br> " + dtGruplar.Rows[i]["dskunvan"].ToString() + '"' + "," +
         System.Environment.NewLine + '"' + "rows" + '"' + ":[" + s1   + System.Environment.NewLine+ "]}");

                tw.Close();
            
            }

            label1.Text = "Başa çatdı";

          



            //FileStream fs2 = new FileStream("D:\\Yourfile.js", FileMode.OpenOrCreate, FileAccess.Read);
            //StreamReader reader = new StreamReader(fs2);
            //textBox1.Text = reader.ReadToEnd();
            //reader.Close();
        }
    }
}
