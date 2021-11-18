using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RepasoMYSQL.Clases
{
    public class EmpleadoHelper
    {
        private HttpClient getCliente()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<IEnumerable<Empleado>> getEmpleado()
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.ruta + "verEmpleados.php");
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Empleado>>(content);
            }
            return Enumerable.Empty<Empleado>();
        }
        public async Task<IEnumerable<Empleado>> traerUnEmpleado(string cedula)
        {
            HttpClient client = getCliente();
            var res = await client.GetAsync(App.ruta + "verempleado.php?cedula="+cedula);
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Empleado>>(content);
            }
            return Enumerable.Empty<Empleado>();
        }
    }
}
