using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_Systems
{
   public class Subject
   {

        string id { set; get; }
        string name { set; get; }

        Dictionary< int, string > SubjectDict { get; set; }
        

        public Subject(string _id, string _name)
        {
            this.id = _id;
            this.name = _name;
        }
        public override string ToString() 
        {
            return $" Subject:{this.name}";
        }
   }
}
