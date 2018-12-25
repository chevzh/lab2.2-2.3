using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2._2
{
    public partial class Form2 : Form
    {
        BindingList<Student> data = new BindingList<Student>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview

        public Form2()
        {
            InitializeComponent();
            InitializeDataGridView();
            Deserialize("Students.json");
        }



        void Deserialize(string fileName)
        {

            //XmlSerializer formatter = new XmlSerializer(typeof(BindingList<Student>));

            //using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            //{
            //    data = (BindingList<Student>)formatter.Deserialize(fs);                          
            //}

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Student[]));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Student[] students = (Student[])jsonFormatter.ReadObject(fs);

                foreach (Student s in students)
                {
                    data.Add(s);
                }
            }
        }

   

        void InitializeDataGridView()
        {
            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].HeaderText = "ФИО";
            dataGridView1.Columns[1].HeaderText = "Дата Рождения";
            dataGridView1.Columns[2].HeaderText = "Специальность";
            dataGridView1.Columns[3].HeaderText = "Курс";
            dataGridView1.Columns[4].HeaderText = "Группа";
            dataGridView1.Columns[5].HeaderText = "Средний Балл";
            dataGridView1.Columns[6].HeaderText = "Адрес";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var newStudents = from d in data
                              where d.Name.ToLower().Contains(textBox1.Text.ToLower())
                              select d;

            BindingList<Student> newData = new BindingList<Student>();

            dataGridView1.DataSource = newData;

            foreach (Student s in newStudents)
            {
                newData.Add(s);
               
            }
           
        }
    }
}
