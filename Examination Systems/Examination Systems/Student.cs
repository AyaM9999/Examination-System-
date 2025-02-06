using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_Systems
{
    public class Student   
    {
        public int stdId { get; set; }
        public string stdUserName { get; set; }
		public string password { get; set; }

		public event Action <Exam> OnExamStarted;


       
        public Student(int _id, string _name,string _pass)
        {
            this.stdId = _id;
            this.stdUserName = _name;
            this.password= _pass;
           
        }

        public void onStartExam(object sender) // fire event
        {
            Console.WriteLine($"Student{this.stdId} has been notified that Exam is satrted!");
        }

        public void onFinishExam(object sender) // fire event 
        {
            Console.WriteLine($"Student{this.stdId} has been notified that Exam is satrted!");
        }



		
		public void AttemptExam(List<Exam> exams)
		{
			bool examFound = false;

			
			Console.WriteLine("Available exams:");
			foreach (var exam in exams)
			{
				Console.WriteLine(exam.ToString());
			}

			// طلب إدخال ID الامتحان
			Console.Write("Enter Exam ID to attempt: ");
			int selectedExamId = int.Parse(Console.ReadLine());

			// البحث عن الامتحان باستخدام الكود
			foreach (var exam in exams)
			{
				if (exam.examId == selectedExamId)
				{
					examFound = true;
					Console.WriteLine($"You have selected the {exam.GetExamType()} exam .");

					// ابدأ الامتحان
					exam.StartExam();

					// عرض الامتحان
					exam.ShowExam();

					// إنهاء الامتحان
					exam.FinishExam();
					break;
				}
			}

			// في حال لم يتم العثور على الامتحان
			if (!examFound)
			{
				Console.WriteLine("Invalid Exam ID! Please try again.\n");
			}
		}
	

}
}
