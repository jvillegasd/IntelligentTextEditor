using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntelligentTextEditor
{
    class Database
    {
        private String slnPath = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 32);
        private String dbPath;

        public Database()
        {
            this.dbPath = slnPath + @"\Database.txt";
        }

        public void addToTree(PrefixTree sTree)
        {
            String line;
            try
            {
                StreamReader fileReader = new StreamReader(this.dbPath);
                line = fileReader.ReadLine();
                while (line != null)
                {
                    line = line.ToLower();
                    sTree.addNode(line, 0, sTree.getRoot());
                    line = fileReader.ReadLine();
                }
                fileReader.Close();
            }
            catch (Exception)
            {
                File.Create(this.dbPath).Dispose();
            }
        }

        public void writeDatabase(Node root) //In this function I go around root children
        {
            List<String> words = new List<String>();
            int length = root.getChildren().Count;
            for (int i = 0; i < length; i++)
            {
                Node nodeLetter = root.getChildren().ElementAt(i);
                char letter = nodeLetter.getLetter();
                String sLetter = Convert.ToString(letter);
                checkWords(sLetter, nodeLetter, ref words);
            }
            StreamWriter fileWriter = new StreamWriter(dbPath);
            foreach (String word in words)
            {
                fileWriter.WriteLine(word);
            }
            fileWriter.Close();
        }

        private void checkWords(String word, Node actual, ref List<String> words) //Them here i concatenating words
        {
            if (actual.getChildren().Count != 0)
            {
                int length = actual.getChildren().Count;
                for (int i = 0; i < length; i++)
                {
                    Node nodeLetter = actual.getChildren().ElementAt(i);
                    char letter = nodeLetter.getLetter();
                    String sLetter = Convert.ToString(letter);
                    checkWords(word + sLetter, nodeLetter, ref words);
                }
            }
            if (actual.getItsFinal())
            {
                words.Add(word);
            }
        }
    }
}