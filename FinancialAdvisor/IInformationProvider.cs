using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    public interface IInformationProvider
    {
        decimal GetExchangeRate(string currency);
    }
}
