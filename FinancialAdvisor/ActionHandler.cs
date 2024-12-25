using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    public class ActionHandler
    {
        private readonly IInformationProvider _informationProvider;

        public ActionHandler(IInformationProvider informationProvider)
        {
            _informationProvider = informationProvider;
        }

        public void LogDecision(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidInputException("Log message cannot be null or empty.");
            }

            // Simuleer logging (bijvoorbeeld naar de console)
            Console.WriteLine($"[LOG]: {message}");
        }

        public void SendNotification(string recipient, string content)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new InvalidInputException("Recipient cannot be null or empty.");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidInputException("Notification content cannot be null or empty.");
            }

            // Simuleer een notificatie sturen
            Console.WriteLine($"[NOTIFICATION]: Sent to {recipient} - {content}");
        }

        public void ExecuteAction(string action)
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                throw new InvalidInputException("Action cannot be null or empty.");
            }

            // Simuleer een actie uitvoeren
            Console.WriteLine($"[ACTION]: Executed action - {action}");
        }

        public decimal GetExchangeRate(string currency)
        {
            return _informationProvider.GetExchangeRate(currency);
        }
    }
}
