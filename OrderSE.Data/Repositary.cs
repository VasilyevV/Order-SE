using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
namespace OrderSE.Data
{
    public class Repositary : IRepositary
    {
        Excel.Application excelDoc = null;
        Excel.Workbook book = null;
        Excel.Worksheet workSheet = null;
        public List<ClientEntity> Read(string Path)//считывание данных из Excel файла и формирование списка данных клиентов
        {
            excelDoc = new Excel.Application();
            book = excelDoc.Workbooks.Open(Path, 0, true);
            workSheet = book.Sheets[1];

            var clients = new List<ClientEntity>();

            for (int i = 2; i <= workSheet.UsedRange.Rows.Count; i++)
            {
                var client = new ClientEntity();
                client.Number = Convert.ToInt16(workSheet.Cells[i, "A"].Value);
                client.Name = workSheet.Cells[i, "B"].Value.ToString();
                client.Amount = Convert.ToDouble(workSheet.Cells[i, "C"].Value);
                client.AmountInWords = NumberToWords.ToWords((int)client.Amount);
                client.VAT = Math.Round(client.Amount - client.Amount / 1.2, 2);
                client.Base = GetBase();
                client.OrderDate = DateTime.Now;

                clients.Add(client);
            }

            Marshal.FinalReleaseComObject(workSheet);
            book.Close();
            Marshal.FinalReleaseComObject(book);
            excelDoc.Quit();
            Marshal.FinalReleaseComObject(excelDoc);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            return clients;
        }

        public string GetBase()//метод-заглушка, выдающий случайным образом основание приходного ордера 
        {
            Random rnd = new Random();
            var path = @"C:\dotnet\Order SE\OrderSE.Data\Files\Base.txt";
            if (File.Exists(path))
            {
                string[] Base = File.ReadAllLines(path);
                string PrintBase = Base[rnd.Next(0, Base.Length)];
                return PrintBase;
            }
            else
                return null;
        }
    }
}
