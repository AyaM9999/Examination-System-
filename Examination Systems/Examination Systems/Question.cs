using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examination_Systems
{
    public  abstract  class Question
    {
        public string body { set; get; }
        public string header { set; get; }

        public double mark { set; get; }

        public int correctAnswer {  set; get; }

        public Question(string _header, string _body, double _mark,int _correctAnswer)
        {
            this.body = _body;   
            this.header = _header;
            this.mark = _mark;
            this.correctAnswer = _correctAnswer;

        }
      

        public override string ToString()
        { 
            return $" header{this.header}: body{this.body}:Mark {this.mark}";
        }

        public abstract void Print();


        [JsonIgnore] // هذه الخاصية لن تُسلسل مباشرة
        public virtual string QuestionType => GetQuestionType();

        public abstract string GetQuestionType();   
    }
}
