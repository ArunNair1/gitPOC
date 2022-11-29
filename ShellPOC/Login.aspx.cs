using ShellPOC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShellPOC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            var namefield = (TextBox)Page.FindControl("name");
            var username = namefield.Text;
            var passfield = (TextBox)Page.FindControl("pass");
            var pass = passfield.Text;
            MyController cntrl = new MyController();
            var token = cntrl.CraftJwt();

        }
    }
}