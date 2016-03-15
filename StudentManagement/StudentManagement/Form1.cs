using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StudentManagement
{
    public partial class frmStudentManage : Form
    {
        public frmStudentManage()
        {
            InitializeComponent();
        }

        private void gbStudentInfo_Enter(object sender, EventArgs e)
        {

        }

        private void lblClass_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentGender_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentID_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentName_Click(object sender, EventArgs e)
        {

        }

        private void lblStudentDOB_Click(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        //Global Content
        DataSet ds;
        SqlDataAdapter daStudent;

        private void frmStudentManage_Load(object sender, EventArgs e)
        {
            // string connection
            string sConnect = @"Data Source=DESKTOP-IS8NAAN;Initial Catalog=STUDENTMANAGEMENT;
                                     Integrated Security=True";
            // selector connection
            string sSelectStudent = @"Select * From Student";

            // implementing data
            daStudent = new SqlDataAdapter(sSelectStudent, sConnect);
            ds = new DataSet("DsStudentManagement");

            // Fill out the table with loaded data
            daStudent.Fill(ds, "tblStudent");
            dgvStudentInfomation.DataSource = ds.Tables["tblStudent"];
        }
    }
}
