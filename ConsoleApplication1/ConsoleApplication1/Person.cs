using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConsoleApplication1
{
    class Person:IDateAndCopy
    { 
        string Name, Surname;
        DateTime datetime;

        public virtual object DeepCopy()
        {
            DateTime CopyDate = new DateTime(this.datetime.Year,this.datetime.Month,this.datetime.Day);
            Person CopyPerson = new Person(this.Name,this.Surname,CopyDate);
            return CopyPerson;
        }
        public static bool operator ==(Person obj1, Person obj2)
        {
            if (obj1.Equals(obj2)&&obj1.GetHashCode()==obj2.GetHashCode())
                return true;
            else return false;
        }
        public static bool operator !=(Person obj1, Person obj2)
        {
            if (obj1.Equals(obj2) && obj1.GetHashCode() == obj2.GetHashCode())
                return false;
            else return true;
        }
        public Person(string Name, string Surname, DateTime datetime)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.datetime = datetime;
        }
        public Person()
        {
            Name = "null";
            Surname = "null";
            datetime = new DateTime(1, 01, 1);
        }
        public override int GetHashCode()
        {
            int stringg = Convert.ToInt32(Name[0]) + Convert.ToInt32(Surname[0]);
            return datetime.Year*datetime.Month*datetime.Day + stringg;
        }
        public override bool Equals(object obj)
        {
            Person p = (Person)obj;
            if ((this.datetime == p.datetime) && (this.Name == p.Name) && (this.Surname == p.Surname))
                return true;
            return false;
        }
        public string GetSetName
        {
            get { return Name; }
            set { Name = value; }
        }
        public string GetSetSurname
        {
            get { return Surname; }
            set { Surname = value; }
        }
        public int GetSetYear
        {
            get { return datetime.Year; }
            set
            {
                int n = value;
                this.datetime = datetime.AddYears(-this.datetime.Year+1);
                this.datetime = datetime.Date.AddYears(n-1);
            }
        }
        public virtual DateTime Date
        {
            get { return datetime; }
            set { datetime = value; }
        }
        public override string ToString()
        {
            return "Имя: " + Name + "\nФамилия: " + Surname + "\nДата рождения: " + datetime.Day + "." + datetime.Month + "." + datetime.Year;
        }
        public virtual string ToShortString()
        {
            return "Имя: " + Name + "\nФамилия: " + Surname;
        }
    }

}
