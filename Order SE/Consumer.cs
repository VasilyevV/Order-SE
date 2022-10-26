using System;
using OrderSE.BL;
using OrderSE.Data;

namespace Order_SE
{
    public class Consumer
    {
        public static void Main(string[] args)
        {
            string path_input = @"C:\dotnet\Order SE\Order SE\Files\InputFile.xlsx";
            string path_output = @"D:\IncomingOrders\Output\Order";

            if (!File.Exists(path_input) || !File.Exists(@"C:\dotnet\Order SE\Order SE\Files\Template.docx"))
            {
                Console.WriteLine("Файлы данных не найдены");
                Console.ReadLine();
                return;
            }
            else
                Console.WriteLine("Файлы найдены");

            var repositary = new Repositary();
            var ClientData = new OrderGenerator(repositary);

            var listClients = new Repositary().Read(path_input);

            string title = "Progress: ";
            Console.WriteLine(title);
            ConsoleProgressBar bar = new ConsoleProgressBar(title.Length, 1, 50);
            int count = 0;

            foreach (var client in listClients)
            {
                count++;
                var data = ClientData.GenerateDataOrder(client);
                OrderPrint.Print(data, path_output);
                bar.ShowProgress(50/listClients.Count*count);
            }
            bar.ShowProgress(50);
            Console.WriteLine("Готово!");

            Console.ReadLine();
        }
    }
}
