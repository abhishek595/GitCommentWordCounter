using GitCommitWordCounter.Model;
using System.Collections.Generic;

namespace GitCommitWordCounter.Shared
{
    public interface IFile
    {
        void Export(List<WordCount> wordCountList);
    }
}
