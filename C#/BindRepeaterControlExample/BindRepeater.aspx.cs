using System;
using System.Data.SqlClient;

namespace BindRepeaterControlExample {

    public partial class BindRepeater : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                BindData();
            }
        }

        //bind subject details to repeater control
        private void BindData() {
            try {
                string strConn = @"Data Source=datasource;Integrated Security=true;Initial Catalog=TestPractical";
                using (SqlConnection sqlConn = new SqlConnection(strConn)) {
                    using (SqlCommand sqlCmd = new SqlCommand()) {
                        sqlCmd.CommandText = "SELECT * FROM SubjectDetails";
                        sqlCmd.Connection = sqlConn;
                        sqlConn.Open();
                        SqlDataReader objDataReader = sqlCmd.ExecuteReader();
                        rptCustomRepeater.DataSource = objDataReader;
                        rptCustomRepeater.DataBind();
                        sqlConn.Close();
                    }
                }
            } catch { }
        }
    }
}