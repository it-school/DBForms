using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBtest
{
    class DB
    {
        private const string Q1 = "SELECT * FROM users WHERE id > 0;";

        string connectionParams; // Строка с параметрами подключения
        MySqlConnection myConnection;
        MySqlCommand myCommand;
        MySqlDataReader myDataReader;
        string res;
        //        Results results;

        public string Error { get => error; }
        public MySqlCommand MyCommand { get => myCommand; }
        public MySqlDataReader MyDataReader { get => myDataReader; }
        public string Res { get => res; }

        //       internal Results Results { get => results; set => results = value; }

        string error;

        public DB()
        {
 //         this.results = new Results();
            this.myConnection = null;
            this.error = "";
            this.myCommand = null;
            this.myDataReader = null;
            this.res = "";
            this.connectionParams = "Database=abiturient;Data Source=192.168.1.152; User Id=Gateway;Password=64dlei*48&";
            // Database - Имя базы в MySQL
            // Data Source - Имя или IP-адрес сервера (если локально то можно и localhost)
            // User Id - Имя пользователя MySQL
            // Password - Пароль пользователя БД MySQL
        }

        public DB(string connectionParams)
        {
 //          this.results = new Results();
            this.myConnection = null;
            this.error = "";
            this.myCommand = null;
            this.myDataReader = null;
            this.connectionParams = connectionParams;
        }

        public bool Connect()
        {
            bool result = false;
            try
            {
                myConnection = new MySqlConnection(this.connectionParams);
                result = true;
            }
            catch (MySqlException e)
            {
                this.error = e.Message;
            }

            return result;
        }

        public bool SELECTQuery(string query = Q1)
        {
            bool result = false;

            try
            {
                myConnection.Open(); // Устанавливаем соединение с базой данных
                myCommand = new MySqlCommand(query, myConnection); // Выполняем запрос к БД


                myDataReader = myCommand.ExecuteReader();
                this.res = "";
                while (myDataReader.Read())
                {
                    //                   Console.WriteLine(myDataReader.GetInt32(0) + "\t" + myDataReader.GetString(1) + "\t" + myDataReader.GetString(2) + "\t" + myDataReader.GetDateTime(3).ToShortDateString() + "\t" + myDataReader.GetString(4));
                    //                   results.Add(new Net(myDataReader.GetInt32(0), myDataReader.GetString(1), myDataReader.GetString(2), myDataReader.GetDateTime(3), myDataReader.GetString(4)));
                    this.res += myDataReader.GetInt32(0) + "\t" + myDataReader.GetString(1) + "\t" + myDataReader.GetString(2) + "\t" + myDataReader.GetString(3) + "\n";
                }
                myDataReader.Close();

                myConnection.Close(); // Обязательно закрываем соединение!

                result = true;
            }
            catch (MySqlException e)
            {
                this.error = e.Message;
            }

            return result;
        }


        public bool UPDATEQuery(string query = "UPDATE net SET info = 'updated' WHERE id > 1;")
        {
            bool result = false;

            try
            {
                myConnection.Open(); // Устанавливаем соединение с базой данных
                myCommand = new MySqlCommand(query, myConnection); // Выполняем запрос к БД

                myCommand.ExecuteNonQuery();

                myConnection.Close(); // Обязательно закрываем соединение!

                result = true;
            }
            catch (MySqlException e)
            {
                this.error = e.Message;
            }

            return result;
        }

    }
}
