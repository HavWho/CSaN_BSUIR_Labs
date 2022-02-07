using System;
using System.ServiceModel;

namespace Server
{
    public class lab5
    {

        [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            int WordCounter(string text);

            [OperationContract]
            string GetStr();
        }

        public static string Mystr="";
        public class MyService : IMyService
        {
            public string GetStr()
            {
                return "\n" + Mystr + "Количество слов в тексте: " + WordCounter(Mystr);
            }

            public int WordCounter(string text)
            {
                text = text.Trim();
                int count = 0;
                if (text[0] != ' ')
                    count++;
                for (int i = 0; i < text.Length - 1; i++)
                {
                    if ((text[i] == ' ') && (text[i + 1] != ' '))
                        count++;
                    if (text[i] == '\n')
                    {
                        count++;
                    }
                }
                Mystr += text + "\n";
                Console.WriteLine(text);
                Console.WriteLine("Количество слов в тексте: " + count + "\n");
                return count;
            }


        }
        class Program
        {
            static void Main(string[] args)
            {
                ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8000/MyService"));
                host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");
                host.Open();
                Console.WriteLine("Сервер запущен");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}