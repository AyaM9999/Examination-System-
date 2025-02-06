using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Examination_Systems
{
    public class PractiseExam : Exam
    {
       

        public PractiseExam(int id, int id_subject, int _quesNums, int _timeLimit, string File) : base( id,  id_subject,  _quesNums,  _timeLimit,  File)
        {
            
        }
        public override string ToString()
        {
            return $" \n Practise Exam  no {this.examId}  of {this.SubjectId} for {this.timeLimit * 60}Minutes \n ";
        }

        public override string GetExamType() => "Practise Exam";


      /**  public override void ShowExam()
        {
            Console.WriteLine($"{this.ExamType} of  {this.Subject.ToString()} for {this.timeLimit}h");

            var loadedQuestionList = _LoadQuestions();
            foreach (var question in loadedQuestionList)
            {
                question.Print();
                Console.WriteLine("Enter your Answer:");
                int userAnswer = int.Parse(Console.ReadLine());
                Console.WriteLine($"Correct Answer is {question.correctAnswer}");
            }
            Console.WriteLine("Question Ended..... Good Luck isa.....Go on ");

        }**/

        public void ShowExam2()
        {
            //Console.WriteLine($"{this.ExamType} of  {this.Subject.ToString()} for {this.timeLimit}h");

            var loadedQuestionList = _LoadQuestions(file);

            for (int i = 0; i < questionsNumber; i++) 
            {
                var question = loadedQuestionList[i];


                question.Print(); 

                Console.WriteLine("Enter your Answer:");
                int userAnswer = int.Parse(Console.ReadLine());

                Console.WriteLine($"Correct Answer is {question.correctAnswer}");

            }
    
            Console.WriteLine("Question Ended..... Good Luck isa.....Go on..! ");

        }
        public override void ShowExam()
        {
            foreach (var question in examQuestions)
            {
                question.Print();

				Console.Write("\nEnter your Answer:\t");
				int userAnswer = int.Parse(Console.ReadLine());

				Console.WriteLine($"Correct Answer is {question.correctAnswer}");
			}

		}



	}
}
