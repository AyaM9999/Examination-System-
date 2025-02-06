using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace Examination_Systems
{
    internal class FinalExam : Exam
    {
		public FinalExam(int exid, int id_subject, int _quesNums, int _timeLimit, string File) : base(exid, id_subject, _quesNums, _timeLimit, File)
		{

		}
		public override string ToString()
        {
            return $"\n Final Exam no: {this.examId} of {this.SubjectId} for {this.timeLimit*60} Minutes\n";
        }

        public override string GetExamType() => "Final Exam";


        public  void ShowExam2()
        {
            
             var loadedQuestionList= _LoadQuestions(file);

            for (int i = 0; i< questionsNumber ; i++)
            {
                var question = loadedQuestionList[i];
                question.Print();

                Console.WriteLine("Enter your Answer:");
                int userAnswer = int.Parse(Console.ReadLine());
                questionAnswerPair.Add(question,new Answer(userAnswer));
                Console.WriteLine("__________________________");

                
            }

            Console.WriteLine($" Your Grade:{CalculateScoreOfExam()}");
            Console.WriteLine("Well Done");

        }

        public double CalculateScoreOfExam()
        {
            double score = 0.0d;
            double ExamScore = 0.0d;
            foreach (var kvp in questionAnswerPair)
            {
              var question = kvp.Key;
              var Answer= kvp.Value;
                ExamScore += question.mark;


			   if (question.correctAnswer.Equals(Answer.userAnswer) )
               {
                   
                    score += question.mark;
               }
            }

            Console.WriteLine($"\n YOUR GRADE: {score}:{ExamScore} \n");
            if (ExamScore * (1 / 2) <= score)
            {
                Console.WriteLine("Congratulations, you are successful\n\n");
            }
            else
            {
				Console.WriteLine(" unfortuanly ,you didn't pass the Exam\n\n");
			}
            return score;
        }


		public override void ShowExam()
		{
			foreach (var question in examQuestions)
			{
				question.Print();


				Console.Write("\nEnter your Answer:");
				int userAnswer = int.Parse(Console.ReadLine());
				questionAnswerPair.Add(question, new Answer(userAnswer));
				Console.WriteLine("__________________________");
			}


			Console.WriteLine($" Your Grade:{CalculateScoreOfExam()} ");
			Console.WriteLine("Well Done");

		}

	}





}
