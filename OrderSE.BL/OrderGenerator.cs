using OrderSE.Data;

namespace OrderSE.BL
{
    public class OrderGenerator : IOrderGenerator
    {
        private readonly IRepositary _repositary;
        public OrderGenerator(IRepositary repositary)
        {
            _repositary = repositary;
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
            dataOrder.Add("[Amount]", string.Format("{0:0.00}", client.Amount));
            
            dataOrder.Add("[AmountInWords]", client.AmountInWords);

            string[] Data = (client.OrderDate.ToString("d\tMMMM\tyyyy")).Split();
            dataOrder.Add("[Date0]", Data[0]);
            dataOrder.Add("[Date1]", Data[1]);
            dataOrder.Add("[Date2]", Data[2]);
            dataOrder.Add("[Date]", string.Format("{0:d}", client.OrderDate));

            dataOrder.Add("[VAT]", string.Format("{0:0.00}", client.VAT));  

            return dataOrder;
        }
    }
}
