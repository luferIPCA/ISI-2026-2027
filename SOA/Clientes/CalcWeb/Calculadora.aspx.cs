using System;

namespace CalcWeb
{
    public partial class Calculadora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WS.CalcWsSoapClient ws = new WS.CalcWsSoapClient();
            int x = int.Parse(TextBox1.Text);
            int y = int.Parse(TextBox2.Text);
            TextBox3.Text = ws.Soma(x, y).ToString();
        }
    }
}