using DBtest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBForms
{
    public partial class Form1 : Form
    {
        DB db;
        public Form1()
        {
            InitializeComponent();
            db = new DB();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (db.Connect() == false)
                MessageBox.Show("Error conection: " + db.Error);
            else
            {
                ActiveForm.Text = "Connected sucessfuly";
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                db.SELECTQuery("SELECT * FROM department;");
                dbGrid.DataSource = db.MyDataReader;

                //dbGrid.Refresh();
                //MessageBox.Show(db.Res);
                MessageBox.Show(db.MyDataReader.ToString());

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

// CREATE TABLE `test`.`users` ( `id` INT NOT NULL , `name` VARCHAR(64) NOT NULL , `login` VARCHAR(16) NOT NULL , `password` VARCHAR(16) NULL DEFAULT NULL , PRIMARY KEY (`id`), UNIQUE (`login`))
// INSERT INTO `users` (`id`, `name`, `login`, `password`) VALUES ('1', 'Ivan', 'user', 'password'), ('2', 'Egor', 'root', 'password');
