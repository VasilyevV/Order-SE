using OrderSE.Data;

namespace OrderSE.BL
{
    public interface IOrderGenerator
    {
        Dictionary<string, string> GenerateDataOrder(ClientEntity client);
    }
}       
