using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{
    class Student:Person,IDateAndCopy
    {
        Education education;
        int NumberGroup;
        ArrayList Testlist;
        Exam[] Exam;
        public Student(Person InfoPerson, Education InfoEducation,int NumberGroup)
        {
            Testlist = new ArrayList();
            base.GetSetName = InfoPerson.GetSetName;
            base.GetSetSurname = InfoPerson.GetSetSurname;
            base.Date = base.Date.AddDays(InfoPerson.Date.Day - 1);
            base.Date = base.Date.AddMonths(InfoPerson.Date.Month - 1);
            base.Date = base.Date.AddYears(InfoPerson.Date.Year - 1);
            this.education = InfoEducation;
            this.GetSetNumberGeroup = NumberGroup;
        }
        public Student()
        {
            Testlist = new ArrayList();
            base.GetSetName = null;
            base.GetSetSurname = null;
            base.Date = base.Date.AddDays(0);
            base.Date = base.Date.AddMonths(0);
            base.Date = base.Date.AddYears(0);
        }
        public override DateTime Date
        {
            get { return base.Date; }
            set { base.Date = value; }
        }
        public int GetSetNumberGeroup
        {
            get
            {
                return NumberGroup;
            }
            set
            {
                if (value < 100 || value > 599)
                    throw new System.ArgumentOutOfRangeException("GetSetNumberGroup", "Группы начинаються с 100-й по 599-ю.");
                else NumberGroup = value;
            }
        }
        public override object DeepCopy()
        {
            DateTime date = new DateTime(base.Date.Year, base.Date.Month, base.Date.Day);
            Person CopyPerson = new Person(base.GetSetName, base.GetSetSurname, date);
            Education CopyEducation = this.education;
            Student CopyStudent = new Student(CopyPerson, CopyEducation, this.NumberGroup);
            CopyStudent.Exam = this.Exam;
            CopyStudent.Testlist = this.Testlist;
            return CopyStudent;
        }
        public Person Person 
        { 
            get
            {
                DateTime returnDate = new DateTime(base.Date.Year,base.Date.Month,base.Date.Day);
                Person Person1 = new Person(base.GetSetName, base.GetSetSurname, returnDate);
                return Person1;
            }
            set
            {
                Person = value;

                DateTime newDate = new DateTime(Person.Date.Year, Person.Date.Month, Person.Date.Day);
                base.Date = newDate;
                base.GetSetName = Person.GetSetName;
                base.GetSetSurname = Person.GetSetSurname;
            }
        }
        public override string ToString()
        {
            string Test = "Зачеты: \n", Exam = "\nЭкзамены: \n";
            for (int i = 0; i < GetSetExam.Length; i++)
                Exam += "Название предмета: " + GetSetExam[i].SubjectName + "\nБалл: " + GetSetExam[i].ScoreofExam + "\nДата сдачи: " + GetSetExam[i].Date.Day + "." + GetSetExam[i].Date.Month + "." + GetSetExam[i].Date.Year + "\n";
            Exam += "Средний балл:" + MiddleBall;
            for(int j=0;j<GetSetTest.Count;j++)
                Test += GetSetTest[j] + "\n";
            return "Имя: " + GetSetName + "\nФамилия: " + GetSetSurname + "\nНомер группы: " + NumberGroup + "\nДата рождения: " + base.Date.Day + "." + base.Date.Month + "." + base.Date.Year + Exam + "\n" + Test;
        }
        public override string ToShortString()
        {
            return "Имя: " + GetSetName + "\nФамилия: " + GetSetSurname + "\nНомер группы: " + NumberGroup + "\nДата рождения: " + base.Date.Day + "." + base.Date.Month + "." + base.Date.Year;
        }
        public ArrayList GetSetTest
        {
            get
            {
                return Testlist;
            }
            set
            {
                Testlist = value;
            }
        }
        public double MiddleBall
        {
            get
            {
                try
                {
                    int count = 0;
                    double middleball = 0;
                    for (int i = 0; i < Exam.Length; i++)
                    {
                        middleball += this.Exam[i].ScoreofExam;
                        count++;
                    }
                    middleball = middleball / count;
                    return middleball;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public Exam[] GetSetExam
        {
            get
            {
                return Exam;
            }
            set
            {
                Exam = value;
            }
        }
        public void AddExam(params Exam[] Exams)
        {
            Exam = new Exam[Exams.Length];
            for (int i = 0; i < Exam.Length; i++)
                this.Exam[i] = Exams[i];
        }
        public void AddTest(params Test[] Tests)
        {
            for (int i = 0; i < Tests.Length; i++ )
                Testlist.Add(Tests[i]);
        }
    }
}
