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

        //Global Contents
        DataSet ds;
        SqlDataAdapter daStudent;  // Data to fill the data grid view
        SqlDataAdapter daClass;  // Data to fill in the combo box
        SqlDataAdapter daBoth;  // Data Adapter to select data in both student and class Table

        // string connection
        string sConnect = @"Data Source=DESKTOP-IS8NAAN;Initial Catalog=STUDENTMANAGEMENT;
                                     Integrated Security=True";

        int tempStudentID;  // Get the last StudentID in the database

        private void frmStudentManage_Load(object sender, EventArgs e)
        {
            #region Properties
            // Active Radio Box with Page Loaded
            rdbMale.Checked = true;
            #endregion

            #region GridView Student
            // selector connection
            string sSelectStudent = @"Select * From Student";

            // implementing data
            daStudent = new SqlDataAdapter(sSelectStudent, sConnect);
            ds = new DataSet("DsStudentManagement");

            // Fill out the table with loaded data
            daStudent.Fill(ds, "tblStudent");
            dgvStudentInfomation.DataSource = ds.Tables["tblStudent"];

            // Edit Data grid view -- Name Display
            dgvStudentInfomation.Columns["StudentID"].HeaderText = "Student ID";
            dgvStudentInfomation.Columns["StudentName"].HeaderText = "Full Name";
            dgvStudentInfomation.Columns["StudentGender"].HeaderText = "Gender";
            dgvStudentInfomation.Columns["StudentDOB"].HeaderText = "Day of Birth";
            dgvStudentInfomation.Columns["StudentAddress"].HeaderText = "Address";
            dgvStudentInfomation.Columns["ClassID"].HeaderText = "Class ID";

            // Edit Data Grid View -- Size
            dgvStudentInfomation.Columns["StudentID"].Width = 40;
            dgvStudentInfomation.Columns["StudentName"].Width = 120;
            dgvStudentInfomation.Columns["StudentGender"].Width = 50;
            dgvStudentInfomation.Columns["StudentDOB"].Width = 100;
            dgvStudentInfomation.Columns["StudentAddress"].Width = 150;
            dgvStudentInfomation.Columns["ClassID"].Width = 50;

            #endregion

            #region ComboBox Class

            string sSelectClass = @"Select * From Class";
            daClass = new SqlDataAdapter(sSelectClass, sConnect);
            daClass.Fill(ds, "tblClass");

            cbClass.DataSource = ds.Tables["tblClass"];
            cbClass.DisplayMember = "ClassName";
            cbClass.ValueMember = "ClassID";
            #endregion

            #region Data from both tables
            /* Replace the Class ID Columns by Class Name Column
                // Look for name of the class that student is in
                string sSelectBoth = @"Select Student.*, Class.ClassName From Student, Class where Student.ClassID = Class.ClassID";
                // Get the data source
                daBoth = new SqlDataAdapter(sSelectBoth, sConnect);
                daBoth.Fill(ds, "tblBoth");
                dgvStudentInfomation.DataSource = ds.Tables["tblBoth"];
            */

            // A Second way
            DataGridViewColumn clClassName = new DataGridViewColumn();
            DataGridViewCell cellClassName = new DataGridViewTextBoxCell();
            clClassName.CellTemplate = cellClassName;
            clClassName.Name = "ClassName";
            clClassName.HeaderText = "Class";
            dgvStudentInfomation.Columns.Add(clClassName);

            for(int i =0; i<dgvStudentInfomation.RowCount; i++)
            {
                dgvStudentInfomation.Rows[i].Cells["ClassName"].Value = 
                    getClassName(dgvStudentInfomation.Rows[i].Cells["ClassID"].Value.ToString());
            }
            
            // Hidding the class ID column in data grid view
            dgvStudentInfomation.Columns["ClassID"].Visible = false;
            dgvStudentInfomation.Columns["ClassName"].HeaderText = "Class";
            dgvStudentInfomation.Columns["ClassName"].Width = 50;
            #endregion

            #region Connection for Adding
            // create connection using for Adding feature
            SqlConnection con = new SqlConnection(sConnect);
            // create a command to the connect string
            string sAddStudent = @"Insert into Student(StudentName, StudentGender, StudentDOB, StudentAddress, ClassID)
                                    values(@StudentName, @StudentGender, @StudentDOB, @StudentAddress, @ClassID)";
            // Initializing a SQL command for Adding feature
            SqlCommand cmAddStudent = new SqlCommand(sAddStudent, con);
            // Assign value for command
            cmAddStudent.Parameters.Add("@StudentName", SqlDbType.NVarChar, 50, "StudentName");
            cmAddStudent.Parameters.Add("@StudentGender", SqlDbType.NVarChar, 10, "StudentGender");
            cmAddStudent.Parameters.Add("@StudentDOB", SqlDbType.DateTime, 10, "StudentDOB");
            cmAddStudent.Parameters.Add("@StudentAddress", SqlDbType.NVarChar, 100, "StudentAddress");
            cmAddStudent.Parameters.Add("@ClassID", SqlDbType.Int, 10, "ClassID");
            
            // Setting the Adding command for database of student
            daStudent.InsertCommand = cmAddStudent;

            #endregion
        }

        public void getLastStudentID()
        {
            // create connection
            string sGetLastID = @"Select StudentID from Student";
            SqlDataAdapter daGetLastID = new SqlDataAdapter(sGetLastID, sConnect);
            DataTable temp = new DataTable();
            daGetLastID.Fill(temp);

            if(temp.Rows.Count > 0)
            {
                int tempID = temp.Rows.Count - 1;
                tempStudentID = int.Parse(temp.Rows[tempID][0].ToString());
            }

        }

        public string getClassName(string sClassID)
        {
            // create a temp connection
            string sTempConnection = @"Data Source = DESKTOP-IS8NAAN; Initial Catalog=STUDENTMANAGEMENT; Integrated Security=True";
            string sTempCommand = @"Select ClassName From Class where Class.ClassID="+sClassID;
            SqlDataAdapter daClassName = new SqlDataAdapter(sTempCommand, sTempConnection);
            DataTable dt = new DataTable();
            daClassName.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check if found any error
            if (txtStudentName.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Some of the field(s) is/are empty!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Add one line to the table of Student (SQL database)
            DataRow row = ds.Tables["tblStudent"].NewRow();
            // Collect information
            row["StudentName"] = txtStudentName.Text;
            if(rdbMale.Checked == true)
            {
                row["StudentGender"] = "Male";
            } else
            {
                row["StudetnGender"] = "Female";
            }
            row["StudentDOB"] = dtpDayOfBirth.Text;
            row["StudentAddress"] = txtAddress.Text;
            row["ClassID"] = cbClass.SelectedValue;

            // Get the ID of last student in the database
            getLastStudentID();
            tempStudentID++;
            row["StudentID"] = tempStudentID;

            // Add row to the table Student
            ds.Tables["tblStudent"].Rows.Add(row);

            // Add class name to DataGridView
            dgvStudentInfomation.Rows[dgvStudentInfomation.RowCount - 1].Cells["ClassName"].Value
                                                 = getClassName(cbClass.SelectedValue.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                daStudent.Update(ds, "tblStudent");
                MessageBox.Show("Successfully added new Student to DataBase!"
                            , "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                return;
            }
        }
    }
}
