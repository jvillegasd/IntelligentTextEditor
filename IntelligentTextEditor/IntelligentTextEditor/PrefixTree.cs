using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntelligentTextEditor
{
    class PrefixTree
    {
        private Node root = null;
        private List<String> suggestWords = new List<String>();

        public PrefixTree()
        {
            this.root = new Node('#', false);
        }

        public void addNode(String word, int index, Node lastLetter)
        {
            if (index < word.Length)
            {
                int length = lastLetter.getChildren().Count;
                bool found = false;
                char letter = Convert.ToChar(word.Substring(index, 1));
                Node newLastL = null;
                for (int i = 0; i < length; i++)
                {
                    newLastL = lastLetter.getChildren().ElementAt(i);
                    if (letter.Equals(newLastL.getLetter()))
                    {
                        addNode(word, index + 1, newLastL);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    if (index == (word.Length - 1))
                    {
                        Node newNode = new Node(letter, true);
                        newNode.setFather(lastLetter);
                        lastLetter.getChildren().Add(newNode);
                    }
                    else
                    {
                        Node newNode = new Node(letter, false);
                        newNode.setFather(lastLetter);
                        lastLetter.getChildren().Add(newNode);
                        addNode(word, index + 1, newNode);
                    }
                }
            }
            if (index == word.Length && !lastLetter.getItsFinal()) //Case when a new word is content in one or various words
            {
                lastLetter.setItsFinal(true);
            }
        }

        public List<String> getSuggestWords(String word)
        {
            bool wordFound = false;
            Node nLastLetter = setLastLetter(0, word, this.root, 0); //Last letter node var found in the Prefix Tree
            String wLastLetter = word.Substring(word.Length - 1, 1); //Last letter typed by user
            if (nLastLetter != null)
            {
                String nLetter = Convert.ToString(nLastLetter.getLetter());
                if (wLastLetter.Equals(nLetter))
                {
                    wordFound = true;
                    nLastLetter = nLastLetter.getFather(); //Get the father node for search suggest words
                }
                else
                {
                    wordFound = false;
                }
            }
            if (wordFound)
            {
                int length = nLastLetter.getChildren().Count;
                for (int i = 0; i < length; i++)
                {
                    wordFound = false;
                    Node newLastL = nLastLetter.getChildren().ElementAt(i);
                    String sLetter = Convert.ToString(newLastL.getLetter());
                    if (wLastLetter.Equals(sLetter))
                    {
                        int cont = 0;             
                        this.checkWords(newLastL, word, ref cont);
                        wordFound = true;
                        break;
                    }
                }
            }
            if (!wordFound)
            {
                this.suggestWords.Clear();
                return this.suggestWords;
            }
            return this.suggestWords;
        }   

        private Node setLastLetter(int index, String word, Node actual, int cont) //This function only find the last letter node (if it exists in the Prefix tree)
        {
            if (index < word.Length && index <= cont) //When index (letter position in word typed) is bigger than 
            {                                         //cont (letter position in Prefix tree) the word ISN'T in the Prefix tree
                String wordAux = word.Substring(index, 1);
                int length = actual.getChildren().Count;
                for (int i = 0; i < length; i++)
                {
                    Node newActual = actual.getChildren().ElementAt(i);
                    char cLetter = newActual.getLetter();
                    String sLetter = Convert.ToString(cLetter);
                    if (sLetter.Equals(wordAux))
                    {
                        return setLastLetter(index + 1, word, newActual, cont + 1);
                        break;
                    }
                }
            }
            if (cont == word.Length) //If the number of letters visited in the Prefix tree equals word length them
            {                        //the word typed is in Prefix tree, else the word typed isn't in Prefix tree
                return actual;
            }
            return null;
        }

        private void checkWords(Node letter, String word, ref int cont) //I call it from getSuggestWords() for obtain all words that start in word var
        {
            if (letter.getChildren().Count != 0 && cont < 5)
            {
                if (letter.getItsFinal() && cont < 5) //I only need to set the first five suggest words and I need to get words from the lowest to the biggest length as possible
                {
                    cont++;
                    this.suggestWords.Add(word);
                }
                int length = letter.getChildren().Count;
                for (int i = 0; i < length; i++)
                {
                    Node newLetter = letter.getChildren().ElementAt(i);
                    char cletter = newLetter.getLetter();
                    String sLetter = Convert.ToString(cletter);
                    checkWords(newLetter,  word + sLetter, ref cont);
                }
            }
            if (letter.getItsFinal() && cont < 5) //I put it again for case when recursivity doesn't enter to the first conditional and cont still lower than 5
            {
                cont++;
                this.suggestWords.Add(word);
            }
        }

        public Node getRoot()
        {
            return this.root;
        }
    }
}