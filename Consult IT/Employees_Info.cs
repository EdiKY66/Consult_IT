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
    public partial class Employees_Info : Form
    {
        public Employees_Info()
        {
            InitializeComponent();
        }

        private void Genereaza_Butoane()
        {
            flowLayoutPanel1.Padding = new Padding(10);

            int buttonHeight = 50;
            int buttonWidth = flowLayoutPanel1.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            flowLayoutPanel1.Controls.Clear();

            foreach (DataRowView row in employeesBindingSource.List)
            {
                int ing = Convert.ToInt32(row["Engineer"]);
                if (ing == 1)
                {
                    string nam = row["Name"].ToString();

                    Button but = new Button();
                    but.Text = nam;
                    but.Size = new Size(buttonWidth, buttonHeight);
                    but.TextAlign = ContentAlignment.MiddleCenter;
                    but.Margin = new Padding(0, 10, 0, 10);
                    but.BackColor = Color.White;
                    but.Font = new Font(but.Font.FontFamily, 16, FontStyle.Bold);

                  
                    but.Click += (sender, e) =>
                    {
                        // Creem o instanță a formularului de detalii cu numele angajatului
                        EmployeeDetailsForm detailsForm = new EmployeeDetailsForm(nam);
                        detailsForm.Text = "Engineer - " + nam;
                        this.Hide();
                        detailsForm.Show(); // Afișăm formularul
                        this.Close();   
                        
                    };

                    flowLayoutPanel1.Controls.Add(but);
                }
            }
        }

        private void Genereaza_Butoane2()
        {
            flowLayoutPanel1.Padding = new Padding(10);

            int buttonHeight = 50;
            int buttonWidth = flowLayoutPanel1.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
           

            foreach (DataRowView row in employeesBindingSource.List)
            {
                int ing = Convert.ToInt32(row["Engineer"]);
                if (ing == 0)
                {
                    string nam = row["Name"].ToString();

                    Button but = new Button();
                    but.Text = nam;
                    but.Size = new Size(buttonWidth, buttonHeight);
                    but.TextAlign = ContentAlignment.MiddleCenter;
                    but.Margin = new Padding(0, 10, 0, 10);
                    but.BackColor = Color.White;
                    but.Font = new Font(but.Font.FontFamily, 16, FontStyle.Regular);

                    but.Click += (sender, e) =>
                    {
                        // Creem o instanță a formularului de detalii cu numele angajatului
                        EmployeeDetailsForm detailsForm = new EmployeeDetailsForm(nam);
                        detailsForm.Text = "Employee - " + nam;
                        this.Hide();
                        detailsForm.Show(); // Afișăm formularul
                        this.Close();

                    };

                    flowLayoutPanel1.Controls.Add(but);
                }
            }
        }

        private void But_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage mp = new MainPage();   
            mp.Show();  
            this.Close();

        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

        }

        private void Employees_Info_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.consultIT_DBDataSet.Employees);

            Genereaza_Butoane();
            Genereaza_Butoane2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Employee form = new Add_Employee();
            this.Hide();
            form.Show();
            this.Close();
        }

        private void employeesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

        }
    }
}
