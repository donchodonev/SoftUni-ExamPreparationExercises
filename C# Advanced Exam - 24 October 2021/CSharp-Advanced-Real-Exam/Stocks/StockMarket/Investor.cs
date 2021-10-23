using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000M && MoneyToInvest >= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock company = FindStock(companyName);

            if (company == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < company.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            MoneyToInvest += sellPrice;
            Portfolio.Remove(company);

            return $"{companyName} was sold.";
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
