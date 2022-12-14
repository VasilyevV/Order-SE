using OrderSE.Data;

namespace OrderSE.BL.Test
{
    public class RepositaryMock : IRepositary
    {
        public string GetBase()
        {
            return "Авансовый отчет";
        }

        public List<ClientEntity> Read(string path)
        {
            var client = new ClientEntity()
            {
                Number = 3,
                Name = "Мехатрон Сервис",
                Amount = 30000.00,
                AmountInWords = "тридцать тысяч",
                VAT = 5000.00,
                Base = "Авансовый отчет",
                OrderDate = new DateTime(2022, 10, 19)
            };
            var clientsList = new List<ClientEntity>();
            clientsList.Add(client);
            return clientsList;
        }
    }
}
