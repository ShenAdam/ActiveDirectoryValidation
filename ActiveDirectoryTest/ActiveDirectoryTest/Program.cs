using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;
namespace ActiveDirectoryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("username:");
            var username = Console.ReadLine();

            string password = "";
            Console.WriteLine("password:");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);


            Console.WriteLine();
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "DOMAIN"))
            {
                bool isValid = pc.ValidateCredentials(username, password);
                Console.WriteLine(isValid);
            }

            Console.ReadLine();
        }
    }
}
