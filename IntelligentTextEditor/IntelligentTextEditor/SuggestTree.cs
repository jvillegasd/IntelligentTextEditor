using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentTextEditor
{
    class SuggestTree
    {
        private Node root = null;
        private Node lastWord = null; //This node save the last word that user typed
        private List<String> suggestWords = new List<String>(); //This list save all suggest words respect to lastWord var
        private bool found2 = true; /*This var is for avoid case when user type words that doesn't found in SuggestTree and when type a part of a word and match it, will be appear
                                      the listBox*/

        public SuggestTree()
        {
            this.root = new Node('#', false);
            this.lastWord = this.root;
        }

        public void addNode(String word, int index, Node lastLetter)
        {
            if (index < word.Length)
            {
                int length = lastLetter.getChildren().Count;
                bool found = false;
                char letter = Convert.ToChar(word.Substring(index, 1));
                Node aux = null;
                for (int i = 0; i < length; i++)
                {
                    aux = lastLetter.getChildren().ElementAt(i);
                    if (letter.Equals(aux.getLetter()))
                    {
                        addNode(word, index + 1, aux);
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
            if (index == word.Length && !lastLetter.getItsFinal()) //Case when a new word has coincidence with one or various words
            {
                lastLetter.setItsFinal(true);
            }
        }

        public List<String> getSuggestWords(String word, bool backSpace) //With this fuction i'll move in children list of the last letter typed by user
        {
            this.suggestWords.Clear();
            if (backSpace && this.lastWord.getFather() != null)
            {
                char cLetter = this.lastWord.getLetter();
                String sLetter = Convert.ToString(cLetter);
                
                if (word.Substring(word.Length - 1, 1).Equals(sLetter))
                {
                    this.lastWord = this.lastWord.getFather();
                    this.found2 = true;
                }             
            }
            if (this.found2)
            {
                int length = this.lastWord.getChildren().Count;
                int index = word.Length - 1;
                String wordAux = word.Substring(index, 1);
                for (int i = 0; i < length; i++)
                {
                    found2 = false;
                    Node newLastW = this.lastWord.getChildren().ElementAt(i);
                    String sLetter = Convert.ToString(newLastW.getLetter());
                    if (wordAux.Equals(sLetter))
                    {
                        this.lastWord = newLastW;
                        int cont = 0;
                        this.checkWords(this.lastWord, word, ref cont);
                        found2 = true;
                        break;
                    }
                }
            }
            if (!this.found2)
            {
                this.suggestWords.Clear();
                return this.suggestWords;
            }
            return this.suggestWords;
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
            if (letter.getItsFinal() && cont < 5) //I put it again for case when recursivity doesn't enter to the first conditional and (cont < 5) yet
            {
                cont++;
                this.suggestWords.Add(word);
            }
        }

        public Node getRoot()
        {
            return this.root;
        }

        public void setLastWord() //I call this function when the user finished and start to write a new word
        {
            this.lastWord = this.root;
            this.suggestWords.Clear();
            this.found2 = true;
        }
    }
}