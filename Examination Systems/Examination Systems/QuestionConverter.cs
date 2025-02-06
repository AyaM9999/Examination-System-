using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Examination_Systems
{
    public  class QuestionConverter:JsonConverter
    {

        // determine if the the json convertor can deal with question type.
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Question);
        }

        // convert json to objects of questions.
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var QuestionObj = JObject.Load(reader); 
            string questionType = QuestionObj["QuestionType"]?.ToString();


            // Determine question type 
            Question question = questionType switch
            {
                "AllOptions" => QuestionObj.ToObject<AllOptionsQuestion>(serializer),

                "TrueFalse" => QuestionObj.ToObject<TruefalseQuestion>(serializer),

                "OneOption" => QuestionObj.ToObject<OneOptionQuestion>(serializer),

                _ => throw new Exception(" Cann't know the question type....")  
            };

            return question;
        }

        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
