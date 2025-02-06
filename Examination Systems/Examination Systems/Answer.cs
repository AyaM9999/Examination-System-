using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_Systems
{
    public  class Answer
    {
         public Question question {  get; set; }
          public  object  userAnswer{  get; set; }

         public Answer( int _answer)
         {
            
          
            this.userAnswer = _answer;
         }



    }
}
