using NUnit.Framework;
using OrderSE.Data;

namespace OrderSE.Data.Test
{
    [TestFixture]
    public class RepositaryTest
    {
        [Test]
        public void Read_test()
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
            var expected_clientsList = Repositary.Read()
        }

    }
}