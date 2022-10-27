using OrderSE.BL;
using OrderSE.Data;

namespace Order_SE
{
    public class Consumer
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Найстройки:");
                Console.WriteLine("1.Файл с входными данными");
                Console.WriteLine("2.Папка с ордерами");
                Console.ReadLine();
                return;
            }

            string path_input = args[0];
            if (!File.Exists(path_input) || !File.Exists(@"C:\dotnet\Order SE\Order SE\Files\Template.docx"))
            {
                Console.WriteLine("Файлы данных не найдены");
                Console.ReadLine();
                return;
            }
            else
                Console.WriteLine("Файлы найдены");

            string path_output = args[1];

            var repositary = new Repositary();
            var ClientData = new OrderGenerator(repositary);
            var listClients = new List<ClientEntity>();
            
            try
            {
                listClients = new Repositary().Read(path_input);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Файл {path_input} недоступен");
                Console.WriteLine(ex);
            }

            string title = "Progress: ";
            Console.WriteLine(title);
            ConsoleProgressBar bar = new ConsoleProgressBar(title.Length, 1, 50);
            int count = 0;

            try
            {
                foreach (var client in listClients)
                {
                    count++;
                    var data = ClientData.GenerateDataOrder(client);
                    OrderPrint.Print(data, path_output);
                    bar.ShowProgress(50 / listClients.Count * count);
                }
                bar.ShowProgress(50);
                Console.WriteLine("Готово!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ордера не сформированы");
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }
    }
}
