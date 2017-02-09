using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ELCSV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string EvaluatePhoneScenario (string[] line)
        {
            if (line[2].StartsWith("07") && !line[3].StartsWith("07")) 
                {
                Console.WriteLine("ML");
                return "ML";
                }
            else if (line[2] == "number1" && line[3] == "number2")
            {
                Console.WriteLine("H");
                return "H";
            }
            else if (!line[2].StartsWith("07") && line[3].StartsWith("07"))
            {
                Console.WriteLine("LM");
                return "LM";
            }
            else if ( (line[2].StartsWith("07") && line[3].StartsWith("07")) &&  (line[2]==line[3]))
            {
                Console.WriteLine("MEM");
                return "MEM";
            }

            else if ((line[2].StartsWith("07") && line[3].StartsWith("07")) && (line[2] != line[3]))
            {
                Console.WriteLine("MDM");
                return "MDM";
            }
            else if (!line[2].StartsWith("07") && !line[3].StartsWith("07")) 
            {
                Console.WriteLine("LL");
                return "LL";
            }
            else if (!line[2].StartsWith("07") && line[3]==" ")
            {
                Console.WriteLine("LB");
                return "LB";
            }
            
            else {
                Console.WriteLine("Other");
                return "Other";
            }

            

        }

        public void ParseFile(string[] line,TextWriter writer)
        {

            string scenario= EvaluatePhoneScenario(line);

            if (scenario == "ML")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }

            else if (scenario == "LM")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[3] + "," + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }

            else if (scenario == "MEM")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }

            else if (scenario == "MDM")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + line[3] + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }

            else if (scenario == "LL")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }

            else if (scenario == "LB")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + line[3] + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }
            else if (scenario == "H")
            {
                writer.WriteLine(line[0] + "," + line[1] + "," + line[2] + "," + line[3] + "," + line[4] + "," + line[5] + "," + line[6] + "," + line[7] + ","
                   + line[8] + "," + line[9] + "," + line[10] + "," + line[11] + "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }
            else if (scenario=="Other")
            { 
            writer.WriteLine(line[0]+","+line[1]+","+line[2]+","+line[3]+","+ line[4] + "," + line[5] + "," + line[6] + "," + line[7]+","
               + line[8] + "," + line[9] + "," + line[10] + "," + line[11]+ "," + line[12] + "," + line[13] + "," + line[14] + "," + line[15]);
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            string sufix = "_"+ localDate.Year.ToString()+ "_" + localDate.Month.ToString()+ "_" + localDate.Day.ToString()+ "_" + 
                localDate.Hour.ToString() + "_"+ localDate.Minute.ToString()+ "_parsed.csv";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open CSV File";
            theDialog.Filter = "CSV files(*.csv)|*.csv";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = theDialog.FileName;
                textBox2.Text = textBox1.Text.Replace(".csv", sufix);        
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var column1 = new List<string>();
            var column2 = new List<string>();
            TextWriter sw = new StreamWriter(textBox2.Text);
            using (StreamReader sr = new StreamReader(textBox1.Text))
            {
               
                while (!sr.EndOfStream)
                {
                    var splits = sr.ReadLine().Split(',');
                    ParseFile(splits, sw);
                }
            }
            MessageBox.Show("Parsing Complete");
            sw.Close();
            Application.Exit();
                   



        }

    }

}
