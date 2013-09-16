using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Создать один объект типа Student, преобразовать данные в текстовый вид с
            //помощью метода ToShortString() и вывести данные.
            Education edu = Education.SecondEducation;
            DateTime birthdate = new DateTime(1993, 08, 1);
            Person Person1 = new Person("Роман", "Перминов", birthdate);
            Student teststudent = new Student(Person1, edu, 405);
            Console.WriteLine(teststudent.ToShortString());
            Console.WriteLine("-------------------");
            //2. Присвоить значения всем определенным в типе Student свойствам,
            //преобразовать данные в текстовый вид с помощью метода ToString() и
            //вывести данные.
            DateTime DateOfExam = new DateTime(2007, 04, 23);
            DateTime DateOfExam1 = new DateTime(2007, 04, 24);
            Exam exam = new Exam("Физика", 95, DateOfExam);
            Exam exam1 = new Exam("Химия", 99, DateOfExam1);
            Test Test = new Test("История", true);
            Test Test1 = new Test("Социология", false);
            teststudent.GetSetTest.Add(Test);
            teststudent.GetSetTest.Add(Test1);
            Exam[] allexam = new Exam[2];
            allexam[0] = exam;
            allexam[1] = exam1;
            teststudent.GetSetExam = allexam;
            Console.WriteLine(teststudent.ToString());
            Console.WriteLine("-------------------");
            //3. C помощью метода AddExams(params Exam[]) добавить элементы в список
            //экзаменов и вывести данные объекта Student, используя метод ToString().
            DateTime DateOfExam2 = new DateTime(2007, 04, 27);
            DateTime DateOfExam3 = new DateTime(2007, 04, 28);
            Exam exam2 = new Exam("Программирование", 20, DateOfExam2);
            Exam exam3 = new Exam("Сапр", 45, DateOfExam3);
            teststudent.AddExam(exam2, exam3);
            Console.WriteLine(teststudent.ToString());
            Console.WriteLine("-------------------");
            //4. Создать два объекта типа Person с совпадающими данными и проверить, что
            //ссылки на объекты не равны, а объекты равны, вывести значения хэш-кодов для
            //объектов.
            DateTime date = new DateTime(1993,08,1);
            Person person2 = new Person("Роман", "Перминов", date);
            DateTime date1 = new DateTime(1993, 08, 1);
            Person person3 = new Person("Роман", "Перминов", date);
            Console.WriteLine(person2.ToString());
            Console.WriteLine(person3.ToString());
            //4.1 меняем данные в одном из обьектов, если ссылки совпадают, данные
            //поменяються в 2х обьектах.
            person2.GetSetName = "Петр";
            Console.WriteLine(person2.ToString());
            Console.WriteLine(person3.ToString());
            Console.WriteLine(person2.GetHashCode());
            Console.WriteLine(person3.GetHashCode());
            Console.WriteLine("-------------------");
            //5. Создать объект типа Student, добавить элементы в список экзаменов и
            //зачетов, вывести данные объекта Student.
            Student teststudent1 = new Student();
            DateTime DateOfExam4 = new DateTime(2007, 04, 23);
            DateTime DateOfExam5 = new DateTime(2007, 04, 24);
            Exam exam4 = new Exam("Физика", 95, DateOfExam4);
            Exam exam5 = new Exam("Химия", 99, DateOfExam5);
            Test Test2 = new Test("История", true);
            Test Test3 = new Test("Социология", false);
            teststudent1.AddExam(exam4, exam5);
            teststudent1.AddTest(Test2, Test3);
            Console.WriteLine(teststudent1.ToString());
            Console.WriteLine("-------------------");
            //6. Вывести значение свойства типа Person для объекта типа Student.
            Console.WriteLine(teststudent.Person.ToString());
            Console.WriteLine("-------------------");
            //7. С помощью метода DeepCopy() создать полную копию объекта Student.
            //Изменить данные в исходном объекте Student и вывести копию и исходный
            //объект, полная копия исходного объекта должна остаться без изменений.
            DateTime DateOfExam6 = new DateTime(2007, 04, 28);
            Exam exam6 = new Exam("Сапр", 45, DateOfExam3);
            Student CopyStudent = new Student();
            CopyStudent = (Student)teststudent.DeepCopy();
            CopyStudent.GetSetName = "ghj";
            CopyStudent.AddExam(exam5);
            //Копирование элементов НЕ ПО ССЫЛКЕ я показал на поле типа Exam и свойства GetSetName остальный элементы
            //были скопированы аналогично, так что нет смысла изменять все элементы, чтобы показать работоспособность
            //метода DeepCopy
            Console.WriteLine("\nКопия\n"+CopyStudent.ToString());
            Console.WriteLine("\nОригинал\n" + teststudent.ToString());
            Console.WriteLine("-------------------");
            //8. В блоке try/catch присвоить свойству с номером группы некорректное
            //значение, в обработчике исключения вывести сообщение, переданное через
            //объект-исключение.
            CopyStudent.GetSetNumberGeroup = 6;
            //9. С помощью оператора foreach вывести список всех зачетов и экзаменов.
            foreach (Exam element in teststudent1.GetSetExam)
            {
                Console.WriteLine(element);
            }
            foreach (Test element in teststudent1.GetSetTest)
            {
                Console.WriteLine(element);
            }
            //10. С помощью оператора foreach для итератора с параметром вывести список
            //всех экзаменов с оценкой выше 3.
            foreach (Exam element in teststudent1.GetSetExam)
            {
                //Т.к. оценку ставил по 100 бальной шкалу по условию сделаем не больше 3, а больше 96.
                if (element.ScoreofExam>96)
                Console.WriteLine(element);
            }

            Console.ReadLine();
        }
    }
}