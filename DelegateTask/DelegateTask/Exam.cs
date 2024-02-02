using System;
namespace DelegateTask
{
	public class Exam
	{
		public string Subject;
		public DateTime Date;

        public override string ToString()
        {
            return $"{Subject}   -   {Date}";
        }
    }
}

