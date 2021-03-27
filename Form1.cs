using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLUETEST
{
    public partial class Form1 : Form
    {

        List<int> tempReadings = new List<int>(); 

        int count = 0;
        public Form1()
        {
            InitializeComponent();

            serialPort1.PortName = "COM6";  //name of COM port
            serialPort1.BaudRate = 9600;    //rate of data transfer

            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.Open();
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceived) ;
        }

        private void DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort spl = (SerialPort)sender;
                Console.Write("Data " + count + ": " + spl.ReadLine() + "\n");
                count++;

                textBox1.Invoke(new Action(() => textBox1.Text += "Data" + count + ": " + spl.ReadLine() + "\n"));
                //updateData();

                tempReadings.Add(int.Parse(spl.ReadLine()));
            }
            catch (Exception ex)
            {

            }

            //listBox1.Text += "Data " + count + "" + spl.ReadLine() + "\n";

        }

       /*private void updateData(object sender, EventArgs e)
        {
            
            textBox1.Text = "Hello";
        }
        */
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
