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
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
                if (textBox1.Text == "Admin")
                {
                    if (textBox2.Text == "Admin")
                    {
                        Form1.TableFill("Специализация", "SELECT * FROM  special  ORDER BY id_sp");

                        Form1.TableFill("Врачи", "SELECT * FROM vrach join special on vrach.id_sp = special.id_sp  ORDER BY id_v");

                        Form1.TableFill("Пациенты", "SELECT * FROM pacient  ORDER BY id_p");

                        Form1.TableFill("ПацРег", "SELECT * FROM pacient_region  ORDER BY id_p_r");

                        Form1.TableFill("Регион", "SELECT * FROM region  ORDER BY id_r");

                        Form1.TableFill("Учёт", "SELECT * FROM card_pacienta  ORDER BY id_c");

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
