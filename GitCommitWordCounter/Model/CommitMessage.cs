using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GitCommitWordCounter.Model
{
    public class Message
    {
        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class WordCount
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }

}
