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
    public partial class Upate_Info_Employee : Form
    {
        public string name;
        public int id;

        public Upate_Info_Employee(string nam)
        {
            InitializeComponent();
            name = nam;
        }

       

        private void Upate_Info_Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.consultIT_DBDataSet.Employees);

            foreach (DataRowView row in employeesBindingSource.List)
            {
                string name2 = row["Name"].ToString();
                if (name2 == name)
                {
                    id = Convert.ToInt32(row["ID"].ToString());
                    textBox1.Text = name;
                    textBox2.Text = row["Adress"].ToString();
                    textBox3.Text = row["Phone"].ToString();
                    textBox4.Text = row["Email"].ToString();
                    textBox5.Text = row["Wage"].ToString();
                    textBox6.Text = row["Hours"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeDetailsForm form = new EmployeeDetailsForm(name);
            this.Hide();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataRowView row in employeesBindingSource.List)
            {
                if (id == Convert.ToInt32(row["ID"].ToString()))
                {
                    if (checkBox1.Checked)
                    {
                        row["Name"] = textBox1.Text;
                        name = textBox1.Text;
                    }
                    if (checkBox2.Checked) row["Adress"] = textBox2.Text;
                    if (checkBox3.Checked) row["Phone"] = textBox3.Text;
                    if (checkBox4.Checked) row["Email"] = textBox4.Text;
                    if (checkBox5.Checked) row["Wage"] = Convert.ToInt32(textBox5.Text);
                    if (checkBox6.Checked) row["hours"] = Convert.ToInt32(textBox6.Text);

                    this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);
                    this.Validate();
                    consultIT_DBDataSet.Employees.AcceptChanges();
                    this.employeesBindingSource.EndEdit();
                }
            }

            Employees_Info form = new Employees_Info();
            this.Hide();
            form.Show();
            this.Close();
        }

    }
}
