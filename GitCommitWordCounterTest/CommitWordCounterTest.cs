using GitCommitWordCounter;
using GitCommitWordCounter.Business;
using GitCommitWordCounter.Model;
using GitCommitWordCounter.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitCommitWordCounterTest
{
    [TestClass]
    public class CommitWordCounterTest
    {
        [TestMethod]
        public void CompletePathTest()
        {
            Program._repository = new GitMessageServiceMock();
            Program.Bst = new Tree();

            //Getting the Message List from Mock data
            var messageList = Program.GetMessageList("", "", "");

            //storing the words 
            Program.StoreWord(messageList);

            //Getting the word list
            var list = Program.GetWordListCount();

            Assert.AreEqual(list.Count(), 58);
            Assert.AreEqual(list.First(x => x.Word == "It").Count, 1);
            Assert.AreEqual(list.First(x => x.Word == "If").Count, 2);
        }

        [TestMethod]
        public void ExportCsvTest()
        {
            var file = new CsvFile();
            var path = Directory.GetCurrentDirectory();
            var parentFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(path).ToString()).ToString());
            CsvFile.savePath = Path.Combine(parentFolder.ToString(), "OutputFile.csv");
            var wordList = new List<WordCount>()
            {
                new WordCount()
                {
                    Word ="Hello",
                    Count= 1

                }
            };

            file.Export(wordList);
            var result = File.ReadAllText(CsvFile.savePath).Replace("\r", "").Replace("\n", "");
            var expected = File.ReadAllText(Path.Combine(parentFolder.ToString(), "ExpectedFile.csv")).Replace("\r", "").Replace("\n", "");

            Assert.AreEqual(result, expected);

        }
    }
}
