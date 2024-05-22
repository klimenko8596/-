using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registratura
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "Admin")
            {
                if (textBox2.Text == "Admin")
                {
                    Form1.TableFill("Специализация", "SELECT * FROM  spec  ORDER BY id_spec");

                    Form1.TableFill("Врачи", "SELECT vrach.fam, vrach.nam, vrach.otch, vrach.dat_r, otd.nazv, vrach.kab, spec.nazv, vrach.login, vrach.password FROM vrach join spec on vrach.id_spec = spec.id_spec join otd on vrach.id_otd = otd.id_otd  ORDER BY id_vrach");

                    Form1.TableFill("Пациенты", "SELECT * FROM pac  ORDER BY id_pac");

                    Form1.TableFill("Отделения", "SELECT * FROM otd  ORDER BY id_otd");

                    Form1.TableFill("Мед. карта", "SELECT * FROM med join vrach on med.id_vrach = vrach.id_vrach join pac on med.id_pac = pac.id_pac order by med");


                    Form3 menu = new Form3();
                    this.Size = new Size(872, 470);



                    Form1.tabControl1.TabPages.RemoveAt(0);
                    Form1.tabControl1.Controls.Add(menu.tabControl1.TabPages[0]);
                }
                else
                {
                    MessageBox.Show("Неправильный пароль");
                }
            }
        }

       
        
    }
}
