using NUnit.Framework;
using OrderSE.Data;

namespace OrderSE.BL.Test
{
    [TestFixture]
    public class OrderGeneratorTest
    {
        private IOrderGenerator _generator;

        [SetUp]
        public void Init()
        {
            IRepositary repositary = new RepositaryMock();
            _generator = new OrderGenerator(repositary);
        }

        [Test]
        public void GenerateClient_Name()
        {
            ClientEntity client = _generator.GenerateClient();
            string name = client.Name;

            Assert.That(name, Is.Not.Empty);
        }

        [Test]
        public void GenerateClient_Amount()
        {
            ClientEntity client = _generator.GenerateClient();
            double amount = client.Amount;

            Assert.That(amount, Is.Not.Empty);
        }

        [Test]
        public void GenerateClient_GenerateDataOrder()
        {
            ClientEntity client = new ClientEntity()
            {
                Number = 3,
                Name = "Мехатрон Сервис",
                Amount = 30000.00,
                AmountInWords = "тридцать тысяч",
                VAT = 5000.00,
                Base = "Авансовый отчет",
                OrderDate = new DateTime(2022, 10, 19)
            };
            Dictionary<string, string> expected_result = new Dictionary<string, string>()
                {
                    {"[Number]", "3"},
                    {"[Name]","Мехатрон Сервис" },
                    {"[Base]", "Авансовый отчет" },
                    {"[Money0]", "30000" },
                    {"[Money1]", "00" },
                    {"[Amount]", "30000.00" },
                    {"[AmountInWords]", "тридцать тысяч" },
                    {"[Date0]", "19" },
                    {"[Date1]", "октября" },
                    {"[Date2]", "2022" },
                    {"[Date]", "19.10.2022" },
                    {"[VAT]", "5000.00" }
                };
            
            Dictionary<string, string> result = _generator.GenerateDataOrder(client);

            Assert.That(result, Is.EqualTo(expected_result));
        }
    }
}