using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _1003_feladat
{
    public partial class Form1 : Form
    {
        public struct diak
        {
            public string code;
            public string name;
            public int score;
        }
        public List<diak> diakList = new List<diak>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            listBox1.Items.Clear();
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            while (!sr.EndOfStream)
            {
                string[] seged = sr.ReadLine().Split(':');
                diak diak = new diak();
                diak.code = seged[0];
                diak.name = seged[1];
                diak.score = Convert.ToInt32(seged[2]);
                diakList.Add(diak);
            }
            sr.Close();

            foreach (var elem in diakList)
            {
                listBox1.Items.Add(elem.code + " " + elem.name + " " + elem.score.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string keres = textBox1.Text;
            foreach (var elem in diakList)
            {
                if (elem.name == keres)
                {
                    listBox1.Items.Add (elem.code + " " + elem.name + " " + elem.score.ToString());
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int max = 0;
            foreach (var elem in diakList)
            {
                if (max < elem.score)
                {
                    max = elem.score;
                }
            }

            foreach (var elem in diakList)
            {
                if (max == elem.score)
                {
                    listBox1.Items.Add(elem.code + " " + elem.name + " " + elem.score.ToString());
                }
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            foreach (var elem in diakList)
            {
                if (elem.score > 20)
                {
                    sw.WriteLine(elem.code + " " + elem.name);
                }
            }
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var elem in diakList)
            {
                if (dict.ContainsKey(elem.score))
                {
                    dict[elem.score]++;
                }
                else
                {
                    dict.Add(elem.score, 1);
                }
            }
            foreach (var elem in dict)
            {
                listBox1.Items.Add(elem.Key+":"+elem.Value);
            }
        }
    }
}
