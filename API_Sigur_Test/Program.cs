using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using API_Sigur_Test;
using API_Sigur_Test.Queries;
using System.Threading;

namespace API_Sigur_Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string login;
            string password;
            string urlAuth = "http://172.19.44.32:9500/api/v1/users/auth";
            
            string getPersonal = "http://127.0.0.1:9500/api/v1/users/";

            Console.WriteLine("Введите Логин для генерации токена: ");
            login = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите Пароль для генерации токена: ");
            password = Console.ReadLine();
            string token = await GET.GetGeneratedToken(urlAuth, login, password);
            if (token == null)
            {
                Console.WriteLine("Введены неверные данные или произошла ошибка при генерации токена");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else Console.WriteLine("Генерация токена произошла успешно");
            Thread.Sleep(2000);
            Console.Clear();

            Console.Write("Впишите Id сотрудника для получения информации о нём: ");
            string personalId = Console.ReadLine();
            string username = await GET.GetPersonalRestAPI(personalId, getPersonal, token);
            Console.WriteLine(username);
            Console.ReadKey();
        }
    }
}
