using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_Systems
{
	internal class Admin
	{
		public string UserName { get; set; }
		public string Password { get; set; }

		public static List<Student> StudentsAsUsers { get; set; } = new List<Student>();  // Initialize the list here

		public static List<Instructor> InstructorsAsUsers { get; set; } = new List<Instructor>();  // Initialize the list here


		public Admin(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}

		// Validate if the student exists based on username and password
		public static Student ValidateStudent(string userName, string password)
		{
			return StudentsAsUsers.FirstOrDefault(std => std.stdUserName == userName && std.password == password);
		}

		// Validate if the instructor exists based on username and password
		public static Instructor ValidateInstructor(string userName, string password)
		{
			return InstructorsAsUsers.FirstOrDefault(ins => ins.InstructorUsername == userName && ins.Password == password);
		}

		// Admin menu to register students and instructors
		public static void AdminMenu()
		{
			bool continueOption = true;
			while (continueOption)
			{
				Console.WriteLine("Admin Panel:");
				Console.WriteLine("1. Register Student Data");
				Console.WriteLine("2. Register Instructor Data");
				Console.WriteLine("3. Log out");
				Console.Write("Enter your option: ");
				if (!int.TryParse(Console.ReadLine(), out int choice))
				{
					Console.WriteLine("Invalid input! Please enter a valid number.");
					continue;
				}

				switch (choice)
				{
					case 1:
						RegisterStudent();
						break;

					case 2:
						RegisterInstructor();
						break;

					case 3:
						continueOption = false;
						break;

					default:
						Console.WriteLine("Please enter a valid option number!");
						break;
				}
			}
		}

		// Register a new student
		private static void RegisterStudent()
		{
			Console.WriteLine("Student Registration Data");
			int stdId;
			string stdUserName, stdPassword;

			Console.Write("Enter your Student ID: ");
			while (!int.TryParse(Console.ReadLine(), out stdId))
			{
				Console.Write("Invalid ID. Please enter a valid Student ID: ");
			}

			Console.Write("Enter your UserName: ");
			stdUserName = Console.ReadLine();

			Console.Write("Enter your Password: ");
			stdPassword = Console.ReadLine();

			StudentsAsUsers.Add(new Student(stdId, stdUserName, stdPassword));
			Console.WriteLine("Student has been registered successfully.");
		}

		// Register a new instructor
		private static void RegisterInstructor()
		{
			Console.WriteLine("Instructor Registration Data");
			int insId;
			string insUserName, insPassword;

			Console.Write("Enter your Instructor ID: ");
			while (!int.TryParse(Console.ReadLine(), out insId))
			{
				Console.Write("Invalid ID. Please enter a valid Instructor ID: ");
			}

			Console.Write("Enter your UserName: ");
			insUserName = Console.ReadLine();

			Console.Write("Enter your Password: ");
			insPassword = Console.ReadLine();

			InstructorsAsUsers.Add(new Instructor(insId, insUserName, insPassword));
			Console.WriteLine("Instructor has been registered successfully.");
		}
	}
}
