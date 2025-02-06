using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_Systems
{
    internal class AllOptionsQuestion:Question
    {
        public List<string> options { set; get; }


        public AllOptionsQuestion(string _header, string _body, double _mark, int correctAnswer, List<string> options) : base(_header, _body, _mark, correctAnswer)
        {

            this.options = options;
           
        }
        public override string ToString()
        {
            return $"header:{this.header},body: {this.body},mark:{this.mark},correctAnswer{this.correctAnswer},options{this.options}";
        }
        public  override void Print()
        {
            Console.WriteLine($"{this.header} \n {this.body} ");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}- {options[i]}");
                
            }

            Console.WriteLine($"\nMarks: {this.mark}");
        }

        public override string GetQuestionType() => "AllOptions";
    }
}
