namespace MoneyTransactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(",");
                Dictionary<string, double> accounts = new();
            foreach (var item in input)
            {
                string[] tokens = item.Split('-');
                string accountN = tokens[0];
                double balance = double.Parse(tokens[1]);
                accounts.Add(accountN, balance);
            }
            string lines;
            while ((lines = Console.ReadLine()) != "End")
            {
                string[] splitCommand = lines.Split();
                string command = splitCommand[0];
                string account = splitCommand[1];
                double sum = double.Parse(splitCommand[2]);

                try
                {
                    string currAccount = accounts.FirstOrDefault(x=>x.Key==account).Key;
                    if(currAccount==null)
                    {
                        throw new ArgumentException("Invalid account!");
                    }
                   else if (command == "Deposit")
                    {
                        accounts[account] += sum;
                    }
                    else if (command == "Withdraw")
                    {
                        if (accounts[account] < sum)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        
                        }
                        accounts[account] -= sum;

                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {account} has new balance: {accounts[account]:F2}");

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { Console.WriteLine("Enter another command"); }
            }
        }
    }
}
/*
1-45.67,2-3256.09,3-97.34
Deposit 1 50
Withdraw 3 100
End

1473653-97.34,44643345-2347.90
Withdraw 1473653 150.50
Deposit 44643345 200
Block 1473653 30
Deposit 1 30
End
 */