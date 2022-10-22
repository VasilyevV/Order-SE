using OrderSE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSE.BL.Test
{
    public class RepositaryMock : IRepositary
    {
        public double GetAmount()
        {
            return 30000.00;
        }

        public string GetBase()
        {
            return "Авансовый отчет";
        }

        public string GetName()
        {
            return "Мехатрон Сервис";
        }

        public int GetNumber()
        {
            return 3;
        }
    }
}
