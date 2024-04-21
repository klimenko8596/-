using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace registratura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static NpgsqlConnection connection =
    new NpgsqlConnection("Server=localhost; Port=5432; User Id=postgres; Password=admin; Database=reg;");

        public static DataSet ds = new DataSet();
        public static TabControl tabControl1 = new TabControl();
        public static DataSet nextValue = new DataSet();

        public static void TableFill(string name, string sql)
        {

            if (ds.Tables[name] != null)
                ds.Tables[name]?.Clear();
            NpgsqlDataAdapter dat;
            dat = new NpgsqlDataAdapter(sql, connection);
            dat.Fill(ds, name);
            connection.Close();
        }

        public static bool ModificationExecute(string sql)
        {
            NpgsqlCommand com;
            com = new NpgsqlCommand(sql, connection);
            connection.Open();
            try
            {
                com.ExecuteNonQuery();
            }
            catch (NpgsqlException)
            {
                MessageBox.Show("Обновление базы данных не было выполнено из-за неуказания обновляемых данных, " +
                    "несоответствия их типов или невозможности и удаления!!", "Ошибка");
                connection.Close();
                return false;
            }
            connection.Close();
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(872, 470);
            this.Controls.Add(tabControl1);

            Form2 form2 = new Form2();
            tabControl1.Controls.Add(form2.tabControl1.TabPages[0]);
        }
    }
}
