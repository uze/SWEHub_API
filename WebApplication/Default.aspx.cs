using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class _Default : Page
    {
        SWEHubAPI.Service1Client SWEHubAPI = new SWEHubAPI.Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = SWEHubAPI.Crime(TextBox1.Text);
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Label1.Text = SWEHubAPI.Crime(TextBox1.Text);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = SWEHubAPI.Weather(TextBox2.Text);
        }


    }
}