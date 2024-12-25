using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    public class DecisionModule
    {
        private readonly IInformationProvider _informationProvider;

        public DecisionModule(IInformationProvider informationProvider)
        {
            _informationProvider = informationProvider;
        }

        public string MakeDecission(decimal budget, decimal expense)
        {
            if (budget <= 0 || expense <= 0)
            {
                throw new InvalidInputException("Budget or expense cannot be zero or negative.");
            }

            if (expense > budget)
            {
                return "Rejected: Expense exceeds budget.";
            }
            else if (expense > budget * 0.8m)
            {
                return "Approved: Expense is within 80% of budget.";
            }
            else
            {
                return "Approved: Expense is within budget.";
            }
        }
    }
}
