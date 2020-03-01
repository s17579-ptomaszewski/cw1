using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cw1
{
    class Program
    {
       public static async Task Main(string[] args)
        {
            //string path = @"Z:\cw1";
            //Console.WriteLine("Hello World!");
            //Person newPerson = new Person { FirstName = "Daniel" };
            var url = "https://www.pja.edu.pl";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            //2xx - oke
            //4xx - zle 
            //5xx - zle
            if(response.IsSuccessStatusCode)
            {
                var htmlContent = await response.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                var matches = regex.Matches(htmlContent);

                foreach (var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
            }
        }
    }
}
