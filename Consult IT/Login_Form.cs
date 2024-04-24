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
    public partial class Login_Form : Form
    {

        public Login_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = Username_Box.Text;
            string pass = Pass_Box.Text;
            bool valid = false;
            int prio = 0;


            foreach (DataRowView row in accountsBindingSource.List)
            {
                string dbuser = row["Username"].ToString();
                string dbpass = row["Password"].ToString();
            

                if (dbuser == user && dbpass == pass)
                {
                    valid = true;
                    prio = Convert.ToInt32(row["Permision"]);
                }

            }

            if(valid == true)
            {
                if (prio == 1)
                    timer1.Start();
                else if (prio == 2)
                    timer2.Start();
                else
                    timer3.Start();
            }

            if(valid == false)
            {
                WrongAcc wr = new WrongAcc();
                wr.ShowDialog();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'consultIT_DBDataSet.Accounts' table. You can move, or remove it, as needed.
            this.consultIT_DBDataSet.EnforceConstraints = false;
            this.accountsTableAdapter.Fill(this.consultIT_DBDataSet.Accounts);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                MainPage main = new MainPage();
                this.Hide();
                main.Show();
                DialogResult = DialogResult.OK;
                return;
            }

            progressBar1.Value += 1;
        }

        private void timer1_Click(object sender, EventArgs e)
        { 
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer2.Stop();
                MainInginer m2 = new MainInginer();
                this.Hide();
                m2.Show();
                DialogResult = DialogResult.OK;
                return;
            }

            progressBar1.Value += 1;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer3.Stop();
                MainAngajat m3 = new MainAngajat();
                this.Hide();
                m3.Show();
                DialogResult = DialogResult.OK;
                return;
            }

            progressBar1.Value += 1;
        }

        private void accountsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.consultIT_DBDataSet);

        }
    }
}

