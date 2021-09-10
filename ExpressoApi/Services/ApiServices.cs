using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ExpressoApi.Models;
using Newtonsoft.Json;

namespace ExpressoApi.Services
{
    public class ApiServices
    {
        public async Task<List<Menu>> GetMenu()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://expressoapipj.azurewebsites.net/api/menus");
            return JsonConvert.DeserializeObject<List<Menu>>(response);

        }

        public async Task<bool> ReserveTable(Reservation reservation)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(reservation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://expressoapipj.azurewebsites.net/api/reservations", content);
            return response.IsSuccessStatusCode;

        }
    }
}