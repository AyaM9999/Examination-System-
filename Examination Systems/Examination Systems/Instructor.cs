using System;
using System.Collections.Generic;

namespace Examination_Systems
{
	internal class Instructor
	{
		public int InstructorId { get; set; }
		public string InstructorUsername { get; set; }
		public string Password { get; set; }

		public static List<Exam> Exams { get; set; } = new List<Exam>();

		public event Action<Exam> OnExamStarted;

		public Instructor(int id, string username, string password)
		{
			this.InstructorId = id;
			this.InstructorUsername = username;
			this.Password = password;
		}

		// Method to create True/False questions
		public Question CreateTrueFalseQuestion()
		{
			Console.Write("Enter question body: ");
			string body = Console.ReadLine();

			Console.Write("Enter mark: ");
			int mark = int.Parse(Console.ReadLine());

			Console.Write("Enter correct answer ID (True/False): ");
			int correctAnswerId = int.Parse(Console.ReadLine());

			return new TruefalseQuestion("Choose True or False:", body, mark, correctAnswerId);
		}

		// Method to create Single Choice questions
		public Question CreateSingleChoiceQuestion()
		{
			Console.Write("Enter question body: ");
			string body = Console.ReadLine();

			Console.Write("Enter mark: ");
			int mark = int.Parse(Console.ReadLine());

			Console.Write("Enter correct answer ID: ");
			int correctAnswerId = int.Parse(Console.ReadLine());

			Console.Write("Enter choice 1: ");
			string choice1 = Console.ReadLine();

			Console.Write("Enter choice 2: ");
			string choice2 = Console.ReadLine();

			Console.Write("Enter choice 3: ");
			string choice3 = Console.ReadLine();

			return new OneOptionQuestion("Choose one option:", body, mark, correctAnswerId, new List<string> { choice1, choice2, choice3 });
		}

		// Method to create Multiple Choice questions
		public Question CreateMultipleChoiceQuestion()
		{
			Console.Write("Enter question body: ");
			string body = Console.ReadLine();

			Console.Write("Enter mark: ");
			int mark = int.Parse(Console.ReadLine());

			Console.Write("Enter correct answer ID: ");
			int correctAnswerId = int.Parse(Console.ReadLine());

			Console.Write("Enter choice 1: ");
			string choice1 = Console.ReadLine();

			Console.Write("Enter choice 2: ");
			string choice2 = Console.ReadLine();

			Console.Write("Enter choice 3: ");
			string choice3 = Console.ReadLine();

			Console.Write("Enter choice 4: ");
			string choice4 = Console.ReadLine();

			return new OneOptionQuestion("Choose one option:", body, mark, correctAnswerId, new List<string> { choice1, choice2, choice3, choice4 });
		}

		// Method to create and add questions to exam
		public void CreateQuestion()
		{
			Console.WriteLine("1. True/False Question");
			Console.WriteLine("2. Single Choice Question");
			Console.WriteLine("3. Multiple Choice Question");

			var questionList = new QuestionsList("FExam1");
			int questionType = int.Parse(Console.ReadLine());

			switch (questionType)
			{
				case 1:
					var trueFalseQuestion = CreateTrueFalseQuestion();
					questionList.Add(trueFalseQuestion);
					break;

				case 2:
					var singleChoiceQuestion = CreateSingleChoiceQuestion();
					questionList.Add(singleChoiceQuestion);
					break;

				case 3:
					var multipleChoiceQuestion = CreateMultipleChoiceQuestion();
					questionList.Add(multipleChoiceQuestion);
					break;

				default:
					Console.WriteLine("Invalid option. Please choose a valid question type.");
					break;
			}
		}

		// Method to create and add an exam
		public void CreateExam()
		{
			Console.WriteLine("Select exam type:");
			Console.WriteLine("1. Practice Exam");
			Console.WriteLine("2. Final Exam");

			int examType = int.Parse(Console.ReadLine());

			Console.Write("Enter Exam ID: ");
			int examId = int.Parse(Console.ReadLine());

			Console.Write("Enter Subject ID: ");
			int subjectId = int.Parse(Console.ReadLine());

			Console.Write("Enter number of questions in the exam: ");
			int numOfQuestions = int.Parse(Console.ReadLine());

			Console.Write("Enter exam time limit in hours: ");
			int timeLimitHours = int.Parse(Console.ReadLine());

			Console.Write("Enter question file path: ");
			string filePath = Console.ReadLine();

			switch (examType)
			{
				case 1:
					var practiceExam = new PractiseExam(examId, subjectId, numOfQuestions, timeLimitHours, filePath);
					practiceExam.StoreQuestionExam_IntoList();
					Exams.Add(practiceExam);
					Console.WriteLine($"Practice Exam ID {practiceExam.examId} created successfully.");
					break;

				case 2:
					var finalExam = new FinalExam(examId, subjectId, numOfQuestions, timeLimitHours, filePath);
					finalExam.StoreQuestionExam_IntoList();
					Exams.Add(finalExam);
					Console.WriteLine($"Final Exam ID {finalExam.examId} created successfully.");
					break;

				default:
					Console.WriteLine("Invalid exam type. Please try again.");
					break;
			}
		}
	}
}
