using System;
using OrderSE.BL;
using OrderSE.Data;

namespace Order_SE
{
    public class Consumer
    {
        static void Main()
        {
            var client = new ClientEntity();
            var repositary = new Repositary();
            var ClientData = new OrderGenerator(repositary);

            foreach (var data in ClientData.GenerateDataOrder(client))
            {
                Console.WriteLine(data);
            }
            Console.ReadLine();
        }

    }
}
