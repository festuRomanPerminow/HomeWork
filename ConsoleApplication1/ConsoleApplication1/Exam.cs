using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Exam:IDateAndCopy
    {
        public string SubjectName { set; get; }
        public int ScoreofExam { set; get; }
        public DateTime Date { set; get; }
        public Exam(string SubjectName,int ScoreofExam, DateTime DateofExam)
        {
            this.SubjectName = SubjectName;
            this.ScoreofExam = ScoreofExam;
            this.Date = DateofExam;
        }
        public Exam()
        {
            DateTime defoltDate = new DateTime(1,1,1);
            this.SubjectName = "null";
            this.ScoreofExam = 1;
            this.Date = defoltDate;
        }
        public object DeepCopy()
        {
            DateTime CopyDate = new DateTime(this.Date.Day, this.Date.Month, this.Date.Year);
            Exam CopyExam = new Exam(this.SubjectName, this.ScoreofExam, CopyDate);
            return CopyExam;
        }
        public override string ToString()
        {
            return "Название предмета: " + SubjectName + "\nОценка: " + ScoreofExam + "\nДата: " + Date.Day + "." + Date.Month + "." + Date.Year;
        }
    }
}
