using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TheSafaryC
{
    public partial class highscore : Form
    {
        //List<user> arruser = new List<user>();
        XmlDocument xmldoc = new XmlDocument();
        String nama;
        String warna;
        String wincause;
        String memakan;
        public highscore(String nama,String warna, String wincause,String memakan)
        {
            InitializeComponent();
            this.nama = nama;
            this.warna = warna;
            this.wincause = wincause;
            this.memakan = memakan;
            refresh();
            if(nama != "" && warna != "" && wincause != "" && memakan != "")
            {
                savebaru();
            }
            refresh();
        }
        public void savebaru()
        {
            xmldoc.Load("user.xml");
            XmlNode rootnode = xmldoc.SelectSingleNode("//users");
            XmlNode usernode = xmldoc.CreateElement("user");
            XmlAttribute xmlatt = xmldoc.CreateAttribute("nama");
            xmlatt.Value = nama;
            usernode.Attributes.Append(xmlatt);
            xmlatt = xmldoc.CreateAttribute("warna");
            xmlatt.Value = warna;
            usernode.Attributes.Append(xmlatt);
            xmlatt = xmldoc.CreateAttribute("kondisi");
            xmlatt.Value = wincause;
            usernode.Attributes.Append(xmlatt);
            xmlatt = xmldoc.CreateAttribute("memakan");
            xmlatt.Value = memakan;
            usernode.Attributes.Append(xmlatt);
            rootnode.AppendChild(usernode);
            xmldoc.AppendChild(rootnode);
            xmldoc.Save("user.xml");
        }
        public void refresh()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            if (File.Exists("user.xml"))
            {
                xmldoc.Load("user.xml");
                XmlNodeList usernode = xmldoc.SelectNodes("//users/user");
                foreach (XmlNode usernodes in usernode)
                {
                    String nama = usernodes.Attributes["nama"].Value;
                    String warna = usernodes.Attributes["warna"].Value;
                    String kondisi = usernodes.Attributes["kondisi"].Value;
                    String memakan = usernodes.Attributes["memakan"].Value;
                    dataGridView1.Rows.Add(nama, warna, kondisi,memakan);
                }
                xmldoc.Save("user.xml");
            }
            else
            {
                xmldoc = new XmlDocument();
                XmlNode rootnode = xmldoc.CreateElement("users");
                xmldoc.AppendChild(rootnode);
                xmldoc.Save("user.xml");
            }
        }
    }
}
