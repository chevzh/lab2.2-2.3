using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab2._2
{
    [DataContract]
    public class Student
    {
        private string name;
        private DateTime dateOfBirth;
        private string qualification;
        private int course;
        private int group;
        private double averageMark;
        private Address address;

        [DataMember]
        public string Name { get => name; set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        [DataMember]
        public string Qualification { get => qualification; set => qualification = value; }
        [DataMember]
        public int Course { get => course; set => course = value; }
        [DataMember]
        public int Group { get => group; set => group = value; }
        [DataMember]
        public double AverageMark { get => averageMark; set => averageMark = value; }
        [DataMember]
        public Address Address { get => address; set => address = value; }


        public Student(string name, DateTime dateofBirth, string qualification, int course, int group, double averageMark, Address address)
        {
            Name = name;
            DateOfBirth = dateofBirth;
            Qualification = qualification;
            Course = course;
            Group = group;
            AverageMark = averageMark;
            Address = address;
        }
        
        public Student()
        {

        }
    }
}
