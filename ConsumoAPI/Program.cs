using Entities.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace ConsumoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste rodando API");

            Thread.Sleep(10000);

            GetProduto();

            foreach (var item in ListaDeProdutos)
            {
                Console.WriteLine($"Código: {item.Id}");
                Console.WriteLine($"Nome: {item.Nome}");
            }

            Console.ReadLine();
        }

        public static string Token { get; set; }

        public static List<Produto> ListaDeProdutos { get; set; }

        public static void GetToken()
        {
            string urlApiGeraToken = "https://localhost:44346/api/CreateToken";

            using (var cliente = new HttpClient())
            {
                string login = "tiago@tiago.com";
                string senha = "Senha.123";

                var dados = new
                {
                    Email = login,
                    Password = senha
                };
                string JsonObjeto = JsonConvert.SerializeObject(dados);

                var content = new StringContent(JsonObjeto, Encoding.UTF8, "application/json");

                var resultado = cliente.PostAsync(urlApiGeraToken, content);
                resultado.Wait();

                if (resultado.Result.IsSuccessStatusCode)
                {
                    var tokenJson = resultado.Result.Content.ReadAsStringAsync();
                    Token = JsonConvert.DeserializeObject(tokenJson.Result).ToString();
                }
            }
        }

        public static void GetProduto()
        {
            GetToken(); // Gera o Token

            if (!string.IsNullOrWhiteSpace(Token))
            {
                using (var cliente = new HttpClient())
               {
                    string urlApiGeraToken = "https://localhost:44346/api/ListaProdutos";
                    cliente.DefaultRequestHeaders.Clear();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    var response = cliente.GetStringAsync(urlApiGeraToken);
                    response.Wait();

                    var listaRetorno = JsonConvert.DeserializeObject<Produto[]>(response.Result).ToList();

                    ListaDeProdutos = listaRetorno;
                }
            }
        }
    }
}
