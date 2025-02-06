using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Examination_Systems
{
    // Enumurator of Exam Mode
    public enum ExamMode : int
    {
        statring, queued, finished
    }


    public abstract  class Exam:IComparable<Exam>,ICloneable
    {

        public int examId { set; get; }

        public int  SubjectId { get; set; }
       

        public int questionsNumber {  get; set; }

        public String ExamType {  get; set; }   

        public  ExamMode mode { set; get; }

        public int timeLimit { set; get; }

        public string file { set; get; }

		public List<Question> examQuestions = new List<Question>();

		public Dictionary<Question,Answer> questionAnswerPair=new Dictionary<Question, Answer>();

        public abstract void ShowExam();

        public abstract string GetExamType();


        //Constructor 
        public Exam( int id,int id_subject, int _quesNums,int _timeLimit,string File)
        {
            this.examId = id;

            this.SubjectId = id_subject;

            this.questionsNumber = _quesNums;
            this.questionAnswerPair = new Dictionary<Question, Answer>();//  corrective 

            this.timeLimit = timeLimit;
            this.file=File;
          
        }
       
        public override string ToString()
        {
            return $" Exam no: {this.examId},subject no ${this.SubjectId},Mode:{this.mode},contains {this.questionsNumber} Question";
        }

        public override int GetHashCode()
        {
            return this.SubjectId.GetHashCode();
        }
        

        public int CompareTo(Exam? other)
        {
            if(other != null)
            {
                return this.questionsNumber.CompareTo(other.questionsNumber);
            }
            else
            {
                return 1;
            }

        }
        public override bool Equals(Object? obj)
        {
            if (obj != null)
            {
              Exam exam=obj as Exam;

                if ((this.questionsNumber == exam.questionsNumber)&&(this.examId==exam.examId))
                {

                    return true; 
                }
                else
                {
                    return false;
                }
       
            }
            else
            {
                return false;
            }
        }


        //  implement  Generic Iclonable
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();

        }

        // implement Iclonable
        public object Clone()
        {
            return this.MemberwiseClone();
        }

  


       
    
       public  void StartExam()
       {
            if (this.mode == ExamMode.statring)
            {
                Console.WriteLine("Exam Started..........");
                foreach (var std in StudentsTakingExam)
                {
                    std.onStartExam(this);
                }
                mode = ExamMode.queued;
            }
            else if (this.mode == ExamMode.queued)
            {
                Console.WriteLine("Exam not started");
            }
            else if (this.mode == ExamMode.finished) { Console.WriteLine("Exam Finished");  }
       }

        public void FinishExam()
        {
            if (this.mode == ExamMode.statring)
            {
                Console.WriteLine("Exam finisher..........");

                mode = ExamMode.finished;
            }
            else if (this.mode == ExamMode.queued)
            {
                Console.WriteLine("Exam not started");
            }
            else if (this.mode == ExamMode.finished) { Console.WriteLine("Exam Finished"); }
        }


        

        public List<Student> StudentsTakingExam = new List<Student>();
        public event Action<Exam> OnstudentStartedExam;
        public  void AddStudent( Student student)
        {
            StudentsTakingExam.Add(student);

            student.OnExamStarted += OnstudentStartedExam;

        }




        public List<Question> _LoadQuestions( string file)
        {
            List<Question> loadedQuestions = new List<Question>();

            try
            {
                if (File.Exists(file))
                {
                    // Read all the content of the file as json
                   //then deserialize it by (serialization setting) into list of questions
                    string json = File.ReadAllText(file);

                    var settings = new JsonSerializerSettings();

                    settings.Converters.Add(new QuestionConverter()); 

                    loadedQuestions = JsonConvert.DeserializeObject<List<Question>>(json, settings) ?? new List<Question>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading questions: {e.Message}");
            }

            // Return the list of questions loaded from the file
            return loadedQuestions;
        }

		public void StoreQuestionExam_IntoList()
		{
			var loadedQuestionList = _LoadQuestions(file);

			for (int i = 0; i < questionsNumber; i++)
			{
				var question = loadedQuestionList[i];

				examQuestions.Add(question);  // إضافة الأسئلة إلى قائمة examQuestions
				
			}
			Console.WriteLine("Questions added to exam successfully >>>>>>>>> Question List of exam");
           
		}





	}
}
