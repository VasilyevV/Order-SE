using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSE.Data;

namespace OrderSE.BL
{
    public interface IOrderGenerator
    {
        ClientEntity GenerateClient();
        Dictionary<string, string> GenerateDataOrder(ClientEntity client);
    }
}       
