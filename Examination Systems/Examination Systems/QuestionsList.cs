using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json; 
using System.Text.Json.Serialization;

namespace Examination_Systems
{
    public class QuestionsList : List<Question>
    {
        private string logFilePath { get; set; }
        public string logFilePath2 { get; set; }

        // every list has its self Json File.

        public QuestionsList(string filename)
        {
            logFilePath = filename;
       

        }


        public new void Add(Question question)
        {


            // Check if the question is already in the list based on its unique properties (e.g., Header, Body)
            if (!Contains(question))
            {
                base.Add(question);
                _logQuestions();  // Store all questions after adding a new one
                Console.WriteLine("Question Added to the json file");
            }
            else
            {
                Console.WriteLine("The question already exists in the list.");
            }
            
            
   


        }
   

        public void logQuestion(Question q)
        {
            try
            {
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine(JsonConvert.SerializeObject(q));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


    

        
        public List<Question> LoadQuestion()
        {
            List<Question> loadedlistt= new List<Question> ();
            
            try
            {
                using (FileStream fileStream = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var question = JsonConvert.DeserializeObject<Question>(line);
                        if (question != null)
                        {
                            loadedlistt.Add(question);
                        }
                     
                    }
                }
            }
            catch ( Exception e) { Console.WriteLine(e.Message); }
            return loadedlistt;
        }


        /**
       public   void logQuestion2( )
       {
           try
           {
               var json = File.ReadAllText(logFilePath);
               var QuestionsList = JsonConvert.DeserializeObject<QuestionsList>>(json);
               foreach (var question in QuestionsList)
               {
                   Add(question);
               }
           }
           catch (FileNotFoundException)
           {
               File.Create(logFilePath).Dispose();
           }
           catch (JsonException)
           {
               //handle Json Paresing exception
               throw;
           }
           catch (Exception ex) { Console.WriteLine(ex.Message) }

               
       }*/





        public void SaveQuestionsToFile()
        {
            // Serialize the list to JSON
            // var  jsonStr = JsonConvert.SerializeObject(this, Formatting.Indented);
           //var json = JsonConvert.SerializeObject<QuestionsList>(this);
            // Write the JSON to the file
            //File.WriteAllText(logFilePath, json);

            Console.WriteLine("Question added and saved to file.");
        }


        public bool Contains(Question question)
        {
            // Assuming that the combination of Header and Body can uniquely identify a question
            return this.Any(q => q.header == question.header && q.body == question.body);
        }
        public void _logQuestions()
        {
            try
            {
                // Serialize the entire list to JSON with indentation for readability
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);

                // Write the serialized JSON to the file (overwrite the entire file)
                File.WriteAllText(logFilePath, json);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error logging questions: {e.Message}");
            }
        }

        /*************************************************************************/
        // Method to load all questions from the file and return them as a list


        public List<Question> _LoadQuestions()
        {
            List<Question> loadedQuestions = new List<Question>();

            try
            {
                if (File.Exists(logFilePath))
                {
                    // Read all the content of the file
                    string json = File.ReadAllText(logFilePath);

                    // Deserialize the JSON content into a list of questions
                    var settings = new JsonSerializerSettings();
                    settings.Converters.Add(new QuestionConverter()); // استخدام المحول هنا
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

    }
}
