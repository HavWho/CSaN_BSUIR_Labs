using System;
using System.ServiceModel;

namespace Client
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        int WordCounter(string text);

        [OperationContract]
        string GetStr();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uri tcpUri = new Uri("http://localhost:8000/MyService");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
            IMyService service = factory.CreateChannel();
            String StrForInter="";
            while (StrForInter != "3")
            {
                Console.WriteLine("\n1) Ввести текст.\n2) Получить множество всех строки.\n3) Выйти");
                StrForInter = Console.ReadLine();
                switch (StrForInter)
                {
                    case "1":
                        Console.WriteLine("Для отправки текста введите '<<' ");
                        String Str="", Str2="";
                        do
                        {
                            Str += Str2;
                            Str2 = Console.ReadLine() + '\n';
                        }
                        while (Str2 != "<<\n");
                        Console.WriteLine("Количество слов в тексте: " + service.WordCounter(Str));
                        break;
                    case "2":
                        Console.Write(service.GetStr());
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
