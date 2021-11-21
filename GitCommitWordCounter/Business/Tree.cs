using GitCommitWordCounter.Model;
using System;
using System.Collections.Generic;

namespace GitCommitWordCounter.Business
{
	public class Node
	{
		public int _key;
		public int _count;
		public string _word;
		public Node left, right;

		public Node(int key, string word)
		{
			_key = key;
			_count = 1;
			_word = word;
			left = right = null;
		}
	}
	public class Tree
    {
		public Node root;

		public Tree()
		{
			root = null;
		}

		public void Insert(int key, string word)
		{
			root = InsertNode(root, key, word);
		}

		public Node InsertNode(Node root, int key, string word)
		{
			if (root == null)
			{
				root = new Node(key, word);
				return root;
			}

			if (word == root._word)
				root._count = root._count + 1;
			else if (key <= root._key)
				root.left = InsertNode(root.left, key, word);
			else if (key > root._key)
				root.right = InsertNode(root.right, key, word);

			return root;
		}

		public List<WordCount> Merge()
		{

			var wordCountList = new List<WordCount>();
			return MergeToList(root, wordCountList);
		}

		public List<WordCount> MergeToList(Node root,List<WordCount> wordCountList)
		{
			if (root != null)
			{
				MergeToList(root.left, wordCountList);
				wordCountList.Add(new WordCount()
				{
					Word = root._word,
					Count = root._count
				});
				MergeToList(root.right, wordCountList);
			}
			return wordCountList;

		}
	}

}
