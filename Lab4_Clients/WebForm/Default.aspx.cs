using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices.Example01A;

namespace WebForm
{
    public partial class _Default : Page
    {
        private Server client;
        protected void Page_Load(object sender, EventArgs e)
        {
            client = new Server();
        }

        protected void Add_btn_Click(object sender, EventArgs e)
        {
            try
            {
               int xInt = int.Parse(x.Text);
               int yInt = int.Parse(y.Text);

               int result = client.Add(xInt, yInt);

               AddResult.Text = result.ToString();
            }catch(Exception ex)
            {
                AddResult.Text = ex.Message;
            }
            
        }

        protected void AddS_btn_Click(Object sender, EventArgs e)
        {
            try
            {
                int xInt = int.Parse(xAddS.Text);
                int yInt = int.Parse(yAddS.Text);

                InputData inputData = new InputData();
                inputData.x= xInt;
                inputData.y= yInt;

                string result = client.AddS(inputData);

                AddSResult.Text = result.ToString();

            }catch(Exception ex)
            {
                AddSResult.Text = ex.Message;
            }
        }

        protected void Concat_btn_Click(Object sender, EventArgs e) 
        {
            try
            {
                string sString = s.Text;
                double dDouble = double.Parse(d.Text);

                string result = client.Concat(sString,dDouble);

                ConcatResult.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ConcatResult.Text = ex.Message;
            }
        }

        protected void Sum_btn_Click(object sender, EventArgs e) 
        {
            try
            {
                string s1String = s1.Text;
                int k1Int = int.Parse(k1.Text);
                float f1Float = float.Parse(f1.Text);

                string s2String = s2.Text;
                int k2Int = int.Parse(k2.Text);
                float f2Float = float.Parse(f2.Text);

                A a1 = new A();
                a1.s = s1String;
                a1.k = k1Int;
                a1.f= f1Float;

                A a2 = new A();
                a2.s = s2String;
                a2.k = k2Int;
                a2.f = f2Float;

                A a3 = new A();

                a3 = client.Sum(a1, a2);

                s3.Text = a3.s.ToString();
                k3.Text= a3.k.ToString();
                f3.Text= a3.f.ToString();


            }catch(Exception ex)
            {
                s3.Text = ex.Message;
            }
        }
    }
}