using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exercise_49_2018
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ExerciseResult> lista = new List<ExerciseResult>();
            using (SqlConnection konekcija = new SqlConnection())
            {
                konekcija.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                konekcija.Open();
                string q = "select* from ExerciseResults";

                SqlCommand sqlCommand = new SqlCommand(q, konekcija);
                using (SqlDataReader citac = sqlCommand.ExecuteReader())
                {


                    while (citac.Read())
                    {
                        ExerciseResult exerciseResult = new ExerciseResult();
                        exerciseResult.Id = (int)citac.GetInt32(0);
                        exerciseResult.StudentName = citac.GetString(1);
                        exerciseResult.StudentIndex = citac.GetString(2);
                        exerciseResult.Point = (int)citac.GetInt32(3);
                        lista.Add(exerciseResult);
                    }


                }


            }
            listBox1.Items.Clear();
            foreach (ExerciseResult exerciseResult1 in lista)
            {
                listBox1.Items.Add(exerciseResult1.StudentName + " " +
                    exerciseResult1.StudentIndex + " " + exerciseResult1.Point);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection konekcija = new SqlConnection())
            {
                konekcija.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FacultyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                konekcija.Open();

                string q = String.Format("INSERT into ExerciseResults values('{0}','{1}','{2}')",
                 txtName.Text, txtIndex.Text, Convert.ToInt32(txtPoint.Text));

                SqlCommand komanda = new SqlCommand(q, konekcija);
                komanda.ExecuteNonQuery();

            }
        }
    }
}
