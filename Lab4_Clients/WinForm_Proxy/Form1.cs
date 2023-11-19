using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using FinReportWebServiceClient.ProxyClass;
using System.Windows.Forms.VisualStyles;

namespace WinForm_Proxy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void sendADD_Click(object sender, EventArgs e)
        {
            try
            {
                Simplex simplex = new Simplex();

                int x = int.Parse(textBox1.Text);
                int y = int.Parse(textBox2.Text);

                int result = simplex.Add(x,y);
                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке HTTP-запроса: " + ex.Message);
            }
            
        }

        private void sendAddS_Click(object sender, EventArgs e)
        {
            try
            {
                Simplex simplex = new Simplex();

                int x = int.Parse(textBox3.Text);
                int y = int.Parse(textBox4.Text);

                InputData inputData = new InputData();

                inputData.x = x;
                inputData.y = y;

                string result = simplex.AddS(inputData);
                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке HTTP-запроса: " + ex.Message);
            }
        }

        private void ConcatSend_Click(object sender, EventArgs e)
        {
            try
            {
                Simplex simplex = new Simplex();

                string s = textBox5.Text;
                double d = double.Parse(textBox6.Text);

                string result = simplex.Concat(s,d);
                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке HTTP-запроса: " + ex.Message);
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void SumSend_Click(object sender, EventArgs e)
        {
            try
            {
                Simplex simplex = new Simplex();

                string s1 = textBox7.Text;
                int i1 = int.Parse(textBox8.Text);
                float f1 = float.Parse(textBox9.Text);

                string s2 = textBox10.Text;
                int i2 = int.Parse(textBox11.Text);
                float f2 = float.Parse(textBox12.Text);

                A a1 = new A();
                a1.s = s1;
                a1.k = i1;
                a1.f = f1;

                A a2 = new A();
                a2.s = s2;
                a2.k = i2;
                a2.f = f2;

                A result = simplex.Sum(a1,a2);
                MessageBox.Show(result.s.ToString()+"\n"+result.k.ToString()+"\n"+result.f.ToString()+"\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке HTTP-запроса: " + ex.Message);
            }
        }
    }
}
