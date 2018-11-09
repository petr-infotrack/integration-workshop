using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Auth0_Lab
{
    public partial class frmMainTest : Form
    {

        private bool _inProgress = false;

        public frmMainTest()
        {
            this.InitializeComponent();

            this.InitControls();
        }

        private void FrmMainTest_Load(object sender, EventArgs e)
        {


            _inProgress = false;
        }

        private void InitControls()
        {
            this.Load += this.FrmMainTest_Load;

            this.btnAuthorize.Click +=  this.BtnAuthorize_Click;

            this.btnRefreshAuth.Click += this.BtnRefreshAuth_Click; 

        }

        private void BtnRefreshAuth_Click(object sender, EventArgs e)
        {
            _inProgress = true;


        }

        private void BtnAuthorize_Click(object sender, EventArgs e)
        {

            this.RequestAuthorization();

            _inProgress = true;



        }



        private void DisplayRequest(string text)
        {
            this.txtRequest.Text = text;
        }

        private void DisplayResponse(string text)
        {
            this.txtResponse.Text = text;

        }



        private void RequestAuthorization()
        {

            using (var client = new HttpClient())
            {
                var request = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        //{"grant_type", "authorization_code"},
                        //{"client_id", "jP9QkZWxVxs1JF6Io8M0cQLRfIhIx6QU"},
                        //{"client_secret", "mfB0J7LplLLTdsGIfGWT-QYpaHG0R6BuiD_4nbXUnBzQSilihEWuNn7xkN5cbRA8"},
                        //{"audience", "https://infotrack-dev.au.auth0.com/api/v2/"}


                        {"response_type", "code"},
                        {"client_id", "HMYzgKx89Q9ICmiTdvTmw2iojR1WWuIIjOwvzRHC"},
//                        {"client_secret", "DNZeqO4CKBpBRfFyzl10LbsVwotgD6UeesO6n6VA"},
  //                      { "code", "s9jGYmL8E00ZyuJP3AEO"},
                        {"redirect_uri", ""}
                        

,                    }
                );
                //request.Headers.Add("content-type", "application/x-www-form-urlencoded");
                var response = client.PostAsync("https://app.clio.com/oauth/authorize", request).Result;
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
