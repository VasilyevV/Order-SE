using OrderSE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSE.BL
{
    public class OrderGenerator : IOrderGenerator
    {
        private readonly IRepositary _repositary;
        public OrderGenerator(IRepositary repositary)
        {
            _repositary = repositary;
        }

        public ClientEntity GenerateClient()
        {
            ClientEntity client  = new ClientEntity();

            client.Number = _repositary.GetNumber();
            client.Name = _repositary.GetName();
            client.Amount = _repositary.GetAmount();
            client.AmountInWords = NumberToWords.ToWords((int)client.Amount);
            client.VAT = Math.Round(client.Amount - client.Amount/1.2, 2);
            client.Base = _repositary.GetBase();
            client.OrderDate = DateTime.Now;

            return client;
        }

        public Dictionary<string, string> GenerateDataOrder(ClientEntity client)
        {
            var dataOrder = new Dictionary<string, string>();

            dataOrder.Add("[Number]", client.Number.ToString());
            dataOrder.Add("[Name]", client.Name);
            dataOrder.Add("[Base]", client.Base);

            string[] money = string.Format("{0:0.00}", client.Amount).Split(',');
            dataOrder.Add("[Money0]", money[0]);
            dataOrder.Add("[Money1]", money[1]);
            dataOrder.Add("[Amount]", client.Amount.ToString());
            
            dataOrder.Add("[AmountInWords]", client.AmountInWords);

            string[] Data = (client.OrderDate.ToString("d\tMMMM\tyyyy")).Split();
            dataOrder.Add("[Date0]", Data[0]);
            dataOrder.Add("[Date1]", Data[1]);
            dataOrder.Add("[Date2]", Data[2]);
            dataOrder.Add("[Date]", string.Format("{0:d}", client.OrderDate));

            dataOrder.Add("[VAT]", client.VAT.ToString());

            return dataOrder;
        }
    }
}
