using System;
using System.Collections.Generic;

namespace Examination_Systems
{
	public class Program
	{
		public static void Main(string[] args)
		{
			bool flag = true;

		
			TruefalseQuestion TFQues1 = new TruefalseQuestion("Choose True |False :", "Capital of Egypt is cairo", 3, 1);
			TruefalseQuestion TFQues2 = new TruefalseQuestion("Choose True |False :", "Capital of Egypt is New Capital", 3, 2);
			OneOptionQuestion onOpQue1 = new OneOptionQuestion("Choose one option", "What isnot consider oop topic", 5, 3, new List<string> { "Abstraction", "Encapsulation", "Compilation" });
			AllOptionsQuestion AllOpQue1 = new AllOptionsQuestion("Choose All option", "What is consider oop topic", 5, 4, new List<string> { "Abstraction", "Encapsulation", "Polymorphism", "All above" });

			
			QuestionsList fExam1List = new QuestionsList("FExam1");
			fExam1List.Add(TFQues1);
			fExam1List.Add(TFQues2);
			fExam1List.Add(onOpQue1);
			fExam1List.Add(AllOpQue1);
			Console.WriteLine("Question added to the json file");

			FinalExam Fexam1 = new FinalExam(100, 351, 4, 2, "FExam1");
			Fexam1.file = "FExam1";
			Fexam1.StoreQuestionExam_IntoList();
			Console.WriteLine("Question added to the Exam's list Questions");

			Student Std1 = new Student(301, "Aya", "Aya301");
			Student Std2 = new Student(401, "Alaa", "Alaa401");
			Student Std3 = new Student(501, "Yassin", "Yasin501");

			
			Fexam1.AddStudent(Std1);
			Fexam1.AddStudent(Std2);
			Fexam1.AddStudent(Std3);

			
			QuestionsList pExam1List = new QuestionsList("pExam1");
			pExam1List.Add(AllOpQue1);
			pExam1List.Add(TFQues2);
			pExam1List.Add(onOpQue1);
			pExam1List.Add(TFQues1);

			PractiseExam Pexam1 = new PractiseExam(100, 351, 4, 2, "pExam1");
			Pexam1.file = "pExam1";
			Pexam1.StoreQuestionExam_IntoList();
			Console.WriteLine("Question added to the Exam's list Questions");

			
			Pexam1.AddStudent(Std1);
			Pexam1.AddStudent(Std2);
			Pexam1.AddStudent(Std3);

			
			Admin admin1 = new Admin("Admin1", "Admin123");

			do
			{
				Console.WriteLine("1. Admin");
				Console.WriteLine("2. Instructor");
				Console.WriteLine("3. Student");
				Console.WriteLine("4. Log out");

				int se = int.Parse(Console.ReadLine());
				switch (se)
				{
					case 1:
						Console.WriteLine("Welcome Admin");
						Admin.AdminMenu();
						break;

					case 2:
						
						Console.WriteLine("Enter Username:");
						string input_name = Console.ReadLine();

						Console.WriteLine("Enter password:");
						string input_password = Console.ReadLine();

						Instructor instructor = Admin.ValidateInstructor(input_name, input_password);

						if (instructor != null)
						{
							Console.WriteLine($"Welcome Instructor: {input_name}");
							Console.WriteLine("1. Create Exam.");
							Console.WriteLine("2. Add Question.");
							Console.WriteLine("3. Show Exams.");
							int selectedOption = int.Parse(Console.ReadLine());
							instructor.CreateExam();
						}
						else
						{
							Console.WriteLine("Invalid username or password.");
						}
						break;

					case 3:
						
						Console.WriteLine("Enter Username:");
						string input_name2 = Console.ReadLine();

						Console.WriteLine("Enter password:");
						string input_password2 = Console.ReadLine();

						Student student = Admin.ValidateStudent(input_name2, input_password2);

						if (student != null)
						{
							Console.WriteLine($"Welcome Student: {input_name2}");
							Console.WriteLine("1. Attend Exam.");
							int selectedOption = int.Parse(Console.ReadLine());

							student.AttemptExam(Instructor.Exams); 
						}
						else
						{
							Console.WriteLine("Invalid username or password.");
						}
						break;

					case 4:
						flag = false;
						break;
				}
			} while (flag);
		}
	}
}
