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

                    Form1.TableFill("Врачи", "SELECT vrach.id_vrach, vrach.fam, vrach.nam, vrach.otch, vrach.dat_r, otd.nazv as id_otd, vrach.kab, spec.nazv as id_spec, vrach.login, vrach.password, concat(fam, ' ', nam, ' ', otch) as fio FROM vrach join spec on vrach.id_spec = spec.id_spec join otd on vrach.id_otd = otd.id_otd  ORDER BY id_vrach");

                    Form1.TableFill("Пациенты", "SELECT id_pac, fam, nam, otch, pol, dat_r, polic, snils, ser_nom, obl, reg, gorod, yl, dom, kvar, concat(fam, ' ', nam, ' ', otch) as fio FROM pac  ORDER BY id_pac");

                    Form1.TableFill("Отделения", "SELECT * FROM otd  ORDER BY id_otd");

                    Form1.TableFill("Мед. карта", "SELECT id_med, concat(pac.fam, ' ', pac.nam, ' ', pac.otch) as id_pac, concat(vrach.fam, ' ', vrach.nam, ' ', vrach.otch) as id_vrach, dat_pr, simp, diag, lekar, comment FROM med join vrach on med.id_vrach = vrach.id_vrach join pac on med.id_pac = pac.id_pac order by id_med");


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

            else
            {
                string sql = "select * from vrach";
                Form1.TableFill("Врачи", sql);
                Form1.ds.Tables["Врачи"].DefaultView.RowFilter = "login = '" + textBox1.Text + "'";

                for (int i = 0; i < Form1.ds.Tables["Врачи"].DefaultView.Count; i++)
                {
                    if (Form1.ds.Tables["Врачи"].DefaultView[i]["password"].ToString() == textBox2.Text)
                    {


                        Form1.TableFill("Мед. карта", "SELECT id_med, concat(pac.fam, ' ', pac.nam, ' ', pac.otch) as id_pac, concat(vrach.fam, ' ', vrach.nam, ' ', vrach.otch) as id_vrach, dat_pr, simp, diag, lekar, comment FROM med join vrach on med.id_vrach = vrach.id_vrach join pac on med.id_pac = pac.id_pac order by id_med");
                        Form1.TableFill("Пациенты", "SELECT id_pac, fam, nam, otch, pol, dat_r, polic, snils, ser_nom, obl, reg, gorod, yl, dom, kvar, concat(fam, ' ', nam, ' ', otch) as fio FROM pac  ORDER BY id_pac");

                        Form4 menu2 = new Form4();
                        this.Size = new Size(872, 470);



                        Form1.tabControl1.TabPages.RemoveAt(0);
                        Form1.tabControl1.Controls.Add(menu2.tabControl1.TabPages[0]);

                    }
                    else
                    {
                        MessageBox.Show("Неправильный пароль");
                    }
                }
            }
        }

       
        
    }
}
