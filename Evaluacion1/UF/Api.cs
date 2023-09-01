using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Evaluacion1.UF
{
    public class Api
    {
        private static readonly string svcURL = "https://www.mindicador.cl";
        private static readonly string pathAPI = "api";
        private static readonly string fecha = DateTime.Now.ToString("dd-MM-yyyy");

        public static string LlamaServicio(string moneda)
        {
            string EmpResponse = string.Empty;
            var qryString = string.Concat(pathAPI, "/", moneda, "/", fecha);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = client.GetAsync(qryString).Result;
                if (Res.IsSuccessStatusCode)
                {
                    EmpResponse = Res.Content.ReadAsStringAsync().Result;
                }
            }
            return EmpResponse;
        }

        public static string ObtenerUf()
        {
            string response = string.Empty;
            var result = LlamaServicio("uf");
            JObject json = JObject.Parse(result);
            response = json["serie"][0]["valor"].ToString();
            return response;
        }

        public static string ObtenerDolar()
        {
            string response = string.Empty;
            var result = LlamaServicio("dolar");
            JObject json = JObject.Parse(result);
            response = json["serie"][0]["valor"].ToString();
            return response;
        }
    }
}
