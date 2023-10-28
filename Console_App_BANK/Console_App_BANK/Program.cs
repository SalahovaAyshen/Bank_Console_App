using Console_App_BANK.Models;
using Console_App_BANK.Utilities.Exceptions;

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
            int id;
            decimal amount;
            int fromid;
            int toid;
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

                       Console.WriteLine("Account created");
                        Console.WriteLine(account);
                        break;

                    case "2":

                        try
                        {
                            do
                            {
                                Console.WriteLine("Enter account id: ");
                                id = int.Parse(Console.ReadLine());
                            } while (id <= 0);
                            do
                            {
                                Console.WriteLine("Enter amount:");
                                amount = int.Parse(Console.ReadLine());
                            } while (amount <= 0);

                            bank.DepositMoney(id, amount);

                        }
                        catch(AccountNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch(InvalidAmountException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch(Exception e) { Console.WriteLine(e.Message); }

                        break;
                    case "3":
                        try
                        {
                            do
                            {
                                Console.WriteLine("Enter account id:");
                                id = int.Parse(Console.ReadLine());
                            } while (id <= 0);
                            do
                            {
                                Console.WriteLine("Enter amount:");
                                amount = int.Parse(Console.ReadLine());
                            } while (amount <= 0);

                            bank.WithDrawal(id, amount);

                        }
                        catch (AccountNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (InsufficientFundsException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }

                        break;

                        case "4":
                        try
                        {
                            do
                            {
                                Console.WriteLine("Enter FROM account id: ");
                                fromid = int.Parse(Console.ReadLine());
                            } while (fromid <= 0);
                            do
                            {
                                Console.WriteLine("Enter TO account id:");
                                toid = int.Parse(Console.ReadLine());
                            } while (toid <= 0);
                            do
                            {
                                Console.WriteLine("Enter amount");
                                amount = int.Parse(Console.ReadLine());
                            } while (amount <= 0);

                            bank.TransferMoney(fromid, toid, amount);
                        }
                        catch (InsufficientFundsException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (AccountNotFoundException e)
                        {

                            Console.WriteLine(e.Message);

                        }
                        catch (InvalidAmountException e)
                        {

                            Console.WriteLine(e.Message);

                        }
                        catch (SameAccountException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "5":
                        bank.GetAllAccounts();
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
