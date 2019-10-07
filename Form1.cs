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

namespace mrz0008_module4activity
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
        class SR
        {
            public StreamReader streamReader;
            public string location;

        }

        SR stream = new SR();
        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                stream.location = openFileDialog1.FileName;
                
            }             
        }

        public void ButtonSearch_Click(object sender, EventArgs e)
        {
            listBoxResult.Items.Clear();
            stream.streamReader = File.OpenText(stream.location);
            try
            {
                while (stream.streamReader.EndOfStream == false)
                {

                    string line = stream.streamReader.ReadLine().ToLower();
                    if (line.Contains(textBoxSearch.Text.ToLower()))
                    {
                        listBoxResult.Items.Add(line);
                    }
                }
            }
            finally
            {
                stream.streamReader.Close();
            }
        }

    }
    
}
