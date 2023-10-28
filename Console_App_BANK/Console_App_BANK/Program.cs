using Console_App_BANK.Models;

namespace Console_App_BANK
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("AB");

            Console.WriteLine("Welcome to AB Bank");

            string input;
            string name;
            string surname;
            byte age;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("[1] Create new account");
                Console.WriteLine("[2] Deposit money");
                Console.WriteLine("[3] Withdrawal money");
                Console.WriteLine("[4] Transfer money");
                Console.WriteLine("[5] Show all accounts");
                Console.WriteLine("[0] Exit");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Please choose option: ");
                input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Enter your name:");
                            name= Console.ReadLine();
                        } while(!Check(name));

                        do
                        {
                            Console.WriteLine("Enter your surname:");
                            surname= Console.ReadLine();
                        }while(!Check(surname));

                        do
                        {
                            Console.WriteLine("Enter your age:");
                            age=Byte.Parse(Console.ReadLine());
                        } while (age < 0);
                       Account account = new Account(name, surname, age);
                       bank.CreateAccount(account);
                       break;
                }

            } while (input != "0");
        }

        public static bool Check(string name)
        {
            int count = 0;
            if (name.Length >= 3 && name.Length < 50)
            {
                if (Char.IsUpper(name[0]))
                {
                    for (int i = 1; i < name.Length; i++)
                    {
                        if (!Char.IsDigit(name[i]) && Char.IsLower(name[i]))
                            count++;
                    }
                    if (count == name.Length - 1)
                    {
                        return true;
                    }

                }
            }
            return false;
        }
    }
}
