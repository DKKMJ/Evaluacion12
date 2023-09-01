using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Evaluacion1.UF
{
    public class Api
    {
        private static readonly string svcURL = "https://www.mindicador.cl"; // URL base del servicio de indicadores económicos
        private static readonly string pathAPI = "api"; // Ruta de la API dentro del sitio web
        private static readonly string fecha = DateTime.Now.ToString("dd-MM-yyyy"); // Fecha actual en formato "dd-MM-yyyy"

        // Método para llamar al servicio y obtener información sobre una moneda específica
        public static string LlamaServicio(string moneda)
        {
            string EmpResponse = string.Empty;
            var qryString = string.Concat(pathAPI, "/", moneda, "/", fecha); // Construye la consulta a la API con la moneda y la fecha actual
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(svcURL); // Establece la URL base para la solicitud HTTP
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Añade la cabecera de aceptación para JSON
                HttpResponseMessage Res = client.GetAsync(qryString).Result; // Realiza la solicitud GET al servicio con la consulta
                if (Res.IsSuccessStatusCode)
                {
                    EmpResponse = Res.Content.ReadAsStringAsync().Result; // Lee la respuesta del servicio y la almacena como una cadena
                }
            }
            return EmpResponse; // Devuelve la respuesta del servicio
        }

        // Método para obtener el valor de la UF desde el servicio
        public static string ObtenerUf()
        {
            string response = string.Empty;
            var result = LlamaServicio("uf"); // Llama al método LlamaServicio con la moneda "uf"
            JObject json = JObject.Parse(result); // Analiza la respuesta JSON en un objeto JObject
            response = json["serie"][0]["valor"].ToString(); // Obtiene el valor de la UF desde el JSON
            return response; // Devuelve el valor de la UF como una cadena
        }

        // Método para obtener el valor del Dólar desde el servicio
        public static string ObtenerDolar()
        {
            string response = string.Empty;
            var result = LlamaServicio("dolar"); // Llama al método LlamaServicio con la moneda "dolar"
            JObject json = JObject.Parse(result); // Analiza la respuesta JSON en un objeto JObject
            response = json["serie"][0]["valor"].ToString(); // Obtiene el valor del Dólar desde el JSON
            return response; // Devuelve el valor del Dólar como una cadena
        }
    }
}
