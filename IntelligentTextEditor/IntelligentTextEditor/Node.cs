using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentTextEditor
{
    class Node
    {
        private char letter;
        private List<Node> children;
        private bool itsFinal = false;
        private Node father;

        public Node(char letter, bool itsFinal)
        {
            this.letter = letter;
            this.itsFinal = itsFinal;
            this.children = new List<Node>();
        }

        public char getLetter()
        {
            return this.letter;
        }

        public List<Node> getChildren()
        {
            return this.children;
        }

        public void setChildren(List<Node> children)
        {
            this.children = children;
        }

        public bool getItsFinal()
        {
            return this.itsFinal;
        }

        public Node getFather()
        {
            return this.father;
        }

        public void setFather(Node father)
        {
            this.father = father;
        }

        public void setItsFinal(bool itsFinal)
        {
            this.itsFinal = itsFinal;
        }
    }
}