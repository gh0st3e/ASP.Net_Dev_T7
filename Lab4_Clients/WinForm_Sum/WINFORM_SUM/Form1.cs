using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Flurl;
using Flurl.Http;

namespace WINFORM_SUM
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        SimpleClass objOne = new SimpleClass();
        SimpleClass objTwo = new SimpleClass();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            objOne.numberInt = Convert.ToInt32(textBox1.Text);
            objOne.numberFloat = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
            objOne.str = textBox3.Text;

            objTwo.numberInt = Convert.ToInt32(textBox4.Text);
            objTwo.numberFloat = float.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat);
            objTwo.str = textBox6.Text;

            string soapData = objOne.formSOAP(objTwo);

            var url = new Url("http://localhost:64630/Simplex.asmx").WithHeader("Content-Type", "text/xml");

            var responseString = await url
                .PostStringAsync(soapData)
                .ReceiveString();

            MessageBox.Show(responseString.ToString());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
