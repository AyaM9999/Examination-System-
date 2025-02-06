using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_Systems
{
    public   enum trueFalseAnswer_enum :int
    {
        True=1, False=2
    }

    public class TruefalseQuestion: Question
    {
        
        public TruefalseQuestion(string _header, string _body, double _mark, int TFAnswer ) :base( _header,  _body,  _mark, TFAnswer)
        {
            
        }

        public override string ToString() 
        {
            return $" header:{this.header},body: {body},Mark :{this.mark},correct Answer:{this.correctAnswer}";
        }

        public override void Print()
        {
            Console.WriteLine(this.header);
            Console.WriteLine($"{this.body}:");
            Console.WriteLine($"1-True");
            Console.WriteLine($"2-False");
            Console.WriteLine($"\n Mark:{this.mark}");
           
        }

        public override string GetQuestionType() => "TrueFalse";
    }
}
