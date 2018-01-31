using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWCFServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TeaStoreClient client = new TeaStoreClient();

            // asking user to input different commands
            Console.WriteLine("Please enter command to execute:");
            Console.WriteLine("<names> to return all tea names from DB; <tea> to get data about specified tea; <all> to get all tea data from DB; <exit> to exit");
            string command = "";
            command = Console.ReadLine();

            // continue while true
            bool cont = true;

            while (cont)
            {
                // while command doesn't match, keep asking to repeat entry
                while (!command.Equals("names") && !command.Equals("tea") && !command.Equals("all") &&
                !command.Equals("exit"))
                {
                    Console.WriteLine("Command not recognized! Please, try again.");
                    command = Console.ReadLine();
                }
                // return tea names
                if (command.Equals("names"))
                {
                    Console.WriteLine("Querying all tea names...");

                    var names = client.GetTeaNames();
                    Console.WriteLine(names);
                    Console.ReadLine();

                    Console.WriteLine("Enter new command:");
                    command = Console.ReadLine();
                }
                // return data for specified tea
                else if (command.Equals("tea"))
                {
                    // enter tea name
                    Console.WriteLine("Please, enter tea name to display...");
                    string teaname = "";
                    teaname = Console.ReadLine();

                    Console.WriteLine("Querying tea {0}...", teaname);

                    var result = client.GetTeaInfo(teaname);
                    Console.WriteLine(result);
                    Console.ReadLine();

                    Console.WriteLine("Please, enter next command:");
                    command = Console.ReadLine();
                }
                // return all db entries
                else if (command.Equals("all"))
                {
                    Console.WriteLine("Queryng all DB entries...");

                    var all = client.GetAllTeas();
                    // if db is empty
                    if (all == null)
                    {
                        Console.WriteLine("No entries in the database!");
                        Console.ReadLine();

                        Console.WriteLine("Please, enter next command:");
                        command = Console.ReadLine();
                    }

                    else
                    {
                        //can add different logic here to display whatever properties required
                        Console.WriteLine("ID | TYPE | NAME | Qty | PRICE | YEAR");
                        foreach (var tea in all)
                        {
                            Console.WriteLine(tea.Id + ", " + tea.Type + ", " + tea.Name + ", " + tea.Qty + ", " + tea.Price + ", " + tea.Year);
                        }
                        Console.ReadLine();

                        Console.WriteLine("Please, enter next command:");
                        command = Console.ReadLine();
                    }
                }
                // exit from console app
                else if (command.Equals("exit"))
                {
                    Console.WriteLine("Exiting...");
                    cont = false;
                }

            }
            
            client.Close();

        }
    }
}
