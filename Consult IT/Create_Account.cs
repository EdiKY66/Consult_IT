using Consult_IT.ConsultIT_DBDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Consult_IT
{
    public partial class Create_Account : Form
    {
        string num;
        int emp_id;
        int ig;

        public Create_Account(string name, int employee_id, int igi)
        {
            InitializeComponent();
            num = name;
            emp_id = employee_id;
            ig = igi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConsultIT_DBDataSet.AccountsRow newAcc = consultIT_DBDataSet.Accounts.NewAccountsRow(); 

                newAcc.Name = num;  
                newAcc.Username = textBox1.Text;
                newAcc.Employee_Id = emp_id;

                if (ig == 1)
                    newAcc.Permision = 2;
                else
                    newAcc.Permision = 3;   


                if(textBox2.Text == textBox3.Text)
                {
                    newAcc.Password = textBox2.Text;
                    consultIT_DBDataSet.Accounts.AddAccountsRow(newAcc);


                    accountsTableAdapter.Update(consultIT_DBDataSet.Accounts);

                    this.Validate();
                    this.accountsBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

                    MessageBox.Show("Account created successfully.");

                    Employees_Info form = new Employees_Info();
                    this.Hide();
                    form.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is not matching. Try again.");
                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the employee: " + ex.Message);
            }

        }

        private void accountsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

        }

        private void Create_Account_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.consultIT_DBDataSet.Employees);
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.consultIT_DBDataSet.EnforceConstraints = false;
            this.accountsTableAdapter.Fill(this.consultIT_DBDataSet.Accounts);

        }
    }
}
