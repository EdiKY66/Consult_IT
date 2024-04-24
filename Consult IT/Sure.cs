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
    public partial class Sure : Form
    {
        public string name;

        public Sure(string nam)
        {
            InitializeComponent();
            name = nam;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeDetailsForm form = new EmployeeDetailsForm(name);
            this.Hide();
            form.Show();
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataRowView row in employeesBindingSource.List)
            {
                if (name == row["Name"].ToString())
                {
                    row.Row.Delete();
                    this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);
                    consultIT_DBDataSet.Employees.AcceptChanges();
                }
            }

            Employees_Info form = new Employees_Info();
            this.Hide();
            form.Show();
            this.Close();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);
            consultIT_DBDataSet.Employees.AcceptChanges();
        }

        private void Sure_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.consultIT_DBDataSet.Employees);

        }
    }
}
