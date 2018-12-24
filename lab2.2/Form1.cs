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
using System.Xml.Serialization;

namespace lab2._2
{
    public partial class Form1 : Form
    {
        BindingList<Student> data = new BindingList<Student>(); //Специальный список List с вызовом события обновления внутреннего состояния, необходимого для автообновления datagridview

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void courseTrackBar_Scroll(object sender, EventArgs e)
        {
            label4.Text = String.Format("Курс: {0}", courseTrackBar.Value);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            data.Add(new Student(nameTextBox.Text, dateOfBirthPicker.Value, qualificationTextBox.Text, courseTrackBar.Value, int.Parse(groupComboBox.Text), Convert.ToDouble(averageMarkTextBox.Text),
                new Address(cityTextBox.Text, Convert.ToInt32(indexTextBox.Text), streetTextBox.Text, Convert.ToInt32(houseTextBox.Text))));
        }


        private void serializeButton_Click(object sender, EventArgs e)
        {
            Serialize("Students.json", data);
        }

        private void deserializeButton_Click(object sender, EventArgs e)
        {
            Desrialize("Students.json");
        }

        void Serialize(string fileName, BindingList<Student> students)
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(Student));

            //using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            //{
            //    foreach(var student in students)
            //    {
            //        formatter.Serialize(fs, student);
            //    }              

            //}

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(BindingList<Student>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, data);
            }

        }

        void Desrialize(string fileName)
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

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                errorProvider1.SetError(nameTextBox, "Не указано имя!");
            }
        }
    }    
}
