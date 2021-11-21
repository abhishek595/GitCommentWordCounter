using System.Net.Http;

namespace GitCommitWordCounter.Shared
{
    public class GitApiService
    {
        private static readonly string gitApiUrl = "https://api.github.com";
        public HttpClient CreateClient(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0");
            client.DefaultRequestHeaders.Add("Token", token);
            return client;
        }

        public string GetRepoComment(HttpClient client, string owner, string endPoint)
        {
            HttpResponseMessage response = client.GetAsync($"{gitApiUrl}/repos/{owner}/{endPoint}/comments").Result;
            response.EnsureSuccessStatusCode();
            string responseBody =  response.Content.ReadAsStringAsync().Result;
            return responseBody;
        }
    }
}
