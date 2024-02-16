using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public int Capacity { get; set; }
        public double Turnover{get;set;}
        public List<Product> Stall { get; set; }

        public void AddProduct(Product product)
        {
           
            if (Stall.Count < Capacity)
                {
                    if (!Stall.Contains(product))
                    { Stall.Add(product); }
                }
        }

        public bool RemoveProduct(string name)
        {
            var product = Stall.FirstOrDefault(x=>x.Name==name);
            if (Stall.Contains(product))
            { Stall.Remove(product); return true; }
            else return false;
        }

        public string SellProduct(string name, double quantity)
        {
            var product = Stall.FirstOrDefault(x => x.Name == name);
            if (Stall.Contains(product))
            {
                double totalPrice = product.Price * quantity;
                Turnover += totalPrice;
                return $"{product.Name} - {totalPrice:F2}$";
            }
            else return "Product not found";
        }

        public string GetMostExpensive()
        {
            var product = Stall.OrderByDescending(x=>x.Price).First();
            return product.ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Groceries Price List:");
            foreach (var item in Stall)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
