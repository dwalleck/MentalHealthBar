using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MentalHealthBar.Client.Models;

namespace MentalHealthBar.Client
{
    public class MentalHealthBarClient
    {
        private readonly HttpClient _client;

        public MentalHealthBarClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ActivityDto>> GetActvities()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/activities");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await _client.SendAsync(request);
            var activities = await response.Content.ReadFromJsonAsync<List<ActivityDto>>();
            response.EnsureSuccessStatusCode();
            return activities;
        }

    }
}