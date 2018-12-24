using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace lab2._2
{   
    [DataContract]
    public class Address
    {
        string city;
        int index;
        string street;
        int house;

        [DataMember]
        public string City { get => city; set => city = value; }
        [DataMember]
        public int Index { get => index; set => index = value; }
        [DataMember]
        public string Street { get => street; set => street = value; }
        [DataMember]
        public int House { get => house; set => house = value; }

        public Address(string city, int index, string street, int house)
        {
            City = city;
            Index = index;
            Street = street;
            House = house;
        }

        public Address()
        {

        }

        public override string ToString()
        {
            return String.Format("{0}, г.{1}, ул. {2}, дом {3}", Index.ToString(), City, Street, House.ToString());
        }

    }
}
