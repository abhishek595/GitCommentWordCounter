using GitCommitWordCounter.Business;
using GitCommitWordCounter.Model;
using GitCommitWordCounter.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GitCommitWordCounter
{
    public class Program
    {
        public static IGitCommitMessageService _repository = new GitCommitMessageService();
        public static Tree Bst { get; set; }
        public static void Main()
        {
            while (true)
            {
                // sampleInput : abhi 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 https://github.com/octokit/octokit.net
                var input = new string[3];
                while (true)
                {
                    Console.WriteLine("Please Insert UserName,GitAccessToken,Repository Url (Ex: https://github.com/octocat/Hello-World) separated by single space");
                    var inputData = Console.ReadLine().Trim().Split(' ');
                    if (inputData.Count() == 3 && inputData[2].Contains("https://github.com/"))
                    {
                        input = inputData;
                        break;
                    }
                }

                var userName = input[0];
                var token = input[1];
                var repoUrl = input[2];
                var splitRepoUrl = repoUrl.Split('/');

                var repo = splitRepoUrl.Last();
                var owner = splitRepoUrl[^2];


                Bst = new Tree();

                //Get data from the GitHub Api
                var commentList = GetMessageList(token, owner, repo);

                // store the data in the binary search tree
                StoreWord(commentList);

                //merge the data to the list from the Tree
                var wordCountList = GetWordListCount();
                
                //Print the Word Count in Console
                foreach (var word in wordCountList)
                {
                    Console.WriteLine(word.Word + "    " + word.Count);
                }

                // Export csv
                Console.WriteLine("Export As CSV ? \nInsert Y for Yes and any other Key for No");
                string userChoise = Console.ReadLine();

                if (userChoise.ToLower() == "y")
                {
                    var export = new CsvFile();
                    export.Export(wordCountList);
                    Console.WriteLine("You can find the downloaded excel in your Desktop Screen ");
                }

                Console.WriteLine("Press Y to continue or any Key to Exit");
                var option = Console.ReadLine();
                if (option.ToLower() != "y")
                    break;
            }

        }

        public static List<string> GetMessageList(string token,string owner,string repo)
        {
            return _repository.GetGitMessageData(token, owner, repo);
        }
   
        public static void StoreWord(List<string> commentList)
        {
            foreach (var comment in commentList)
            {
                var wordList = comment.Split(new char[] { ' ', ',' , '\\' , '/' , '.' ,'?' });
                foreach (var word in wordList)
                {
                    var sum = 0;
                    var trimWord = word.Replace("\n", "").Trim();

                    if (trimWord.Length == 0 || trimWord.Length == 1)
                        continue;
                    for (int i = 0; i < trimWord.Length; i++)
                    {
                        sum += trimWord[i];
                    }

                    Bst.Insert(sum, trimWord);
                }
            }

        }

        public static List<WordCount> GetWordListCount()
        {
            return  Bst.Merge();
         
        }

    }
}
