using GitCommitWordCounter.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace GitCommitWordCounter.Test
{
    public class GitMessageServiceMock : IGitCommitMessageService
    {
        public List<string> GetGitMessageData(string token, string owner, string repo)
        {
            return new List<string>()
            {
                "My Name is Name               iuo",
                "Hello and thanks for your good question! It is such a good question, it has been asked before, so your question has been closed as a duplicate. If you read that post and still don't feel that your question has been answered, then please feel free to edit this question to reflect what part of the answer in the duplicate you find confusing. If you have questions about why your post was closed, please leave a comment here or ask on"
            };

        }
    }
}
