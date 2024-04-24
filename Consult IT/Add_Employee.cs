using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Consult_IT
{
    public partial class Add_Employee : Form
    {
        string name;
        int id;
        int ig;

        public Add_Employee()
        {
            InitializeComponent();
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.consultIT_DBDataSet.Employees);

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

            try
            {
                ConsultIT_DBDataSet.EmployeesRow newEmployee = consultIT_DBDataSet.Employees.NewEmployeesRow();

                newEmployee.Name = textBox1.Text;
                newEmployee.Adress = textBox2.Text;
                newEmployee.Phone = textBox3.Text;
                newEmployee.Email = textBox4.Text;
                newEmployee.Wage = Convert.ToInt32(textBox5.Text); 
                newEmployee.Hours = Convert.ToInt32(textBox6.Text); 
                if (checkBox1.Checked)
                newEmployee.Engineer = 1; 
                else
                newEmployee.Engineer = 0;

                consultIT_DBDataSet.Employees.AddEmployeesRow(newEmployee);
                this.Validate();
                this.employeesBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);
                employeesTableAdapter.Update(consultIT_DBDataSet.Employees);

                name = newEmployee.Name;
                id = newEmployee.Id;
                ig = newEmployee.Engineer;

                

                MessageBox.Show("Employee added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the employee: " + ex.Message);
            }

            

            Create_Account form = new Create_Account(name, id,ig);
            this.Hide();
            form.Show();
            this.Close();


        }
    }
}
