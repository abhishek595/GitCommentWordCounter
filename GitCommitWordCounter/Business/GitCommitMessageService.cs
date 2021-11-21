using GitCommitWordCounter.Model;
using GitCommitWordCounter.Shared;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GitCommitWordCounter.Business
{
    public class GitCommitMessageService: IGitCommitMessageService
    {
        private GitApiService _apiService { get; set; }
        public GitCommitMessageService()
        {
            _apiService = new GitApiService();

        }
        public List<string> GetGitMessageData(string token ,string owner,string repo)
        {
            var client = _apiService.CreateClient(token);
            var result = _apiService.GetRepoComment(client, owner, repo);
            var data = JsonConvert.DeserializeObject<List<Message>>(result);
            return data.Select(x=>x.Body).ToList();
        }
    }
}
