 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consult_IT
{
    public partial class EmployeeDetailsForm : Form
    {
        public string EmployeeName { get; set; }
        public EmployeeDetailsForm(string employeeName)
        {
            InitializeComponent();
            EmployeeName = employeeName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.consultIT_DBDataSet.Employees);

            foreach (DataRowView row in employeesBindingSource.List)
            {
                string nam = row["Name"].ToString();
                if (nam == EmployeeName)
                {
                    textBox1.Text = EmployeeName;
                    textBox2.Text = row["Adress"].ToString();
                    textBox3.Text = row["Phone"].ToString();
                    textBox4.Text = row["Email"].ToString();
                    textBox5.Text = row["Wage"].ToString();
                    textBox6.Text = row["Hours"].ToString();
                }
            }
        }


        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employees_Info form = new Employees_Info();
            this.Hide();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sure form = new Sure(EmployeeName);
            this.Hide();
            form.Show();
            this.Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Upate_Info_Employee form = new Upate_Info_Employee(EmployeeName);
            this.Hide();
            form.Show();    
            this.Close();   
        }
    }
}
