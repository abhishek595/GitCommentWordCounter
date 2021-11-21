using GitCommitWordCounter.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitCommitWordCounter.Shared
{
    public interface IGitCommitMessageService
    {
        List<string> GetGitMessageData(string token, string owner, string repo);
    }
}
