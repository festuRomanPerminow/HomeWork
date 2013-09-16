using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Test:IDateAndCopy
    {
        public string SubjectName { set; get; }
        public bool PassTheTest { set; get; }
        public DateTime Date { set; get; }
        public Test(string SubjectName, bool PassTheTest)
        {
            this.SubjectName = SubjectName;
            this.PassTheTest = PassTheTest;
        }
        public Test()
        {
            this.SubjectName = "null";
            this.PassTheTest = false;
        }
        public object DeepCopy()
        {
            DateTime CopyDate = new DateTime(this.Date.Day,this.Date.Month,this.Date.Year);
            Test CopyTest = new Test(this.SubjectName,this.PassTheTest);
            return CopyTest;
        }
        public override string ToString()
        {
           return "Название предмета: " + SubjectName + "\nОценка за зачет: " + PassTheTest;
        }
    }
}
