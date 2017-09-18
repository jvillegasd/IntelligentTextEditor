using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentTextEditor
{
    public partial class MainFrame : Form
    {
        private SuggestTree suggestTree = new SuggestTree();
        private Database database = new Database();
        private String filePath; //This var save file path that user picked
        private StreamReader fileReader = null;
        private StreamWriter fileWriter = null;
        private String word = "";
        private List<String> suggestWords = new List<String>();
        private bool number = false;

        public MainFrame()
        {
            InitializeComponent();
            textBox.ScrollBars = ScrollBars.Vertical; //Add a scrollbar to textBox
            textBox.WordWrap = true; //Add a word wrap to textBox
            this.database.addToTree(this.suggestTree); //Add databese.txt to the SuggestTree
            this.CenterToScreen();
            this.saveToolStrip.Enabled = false;
        }

        private void setTextBox() //This function set all .txt file into textBox
        {
            fileReader = new StreamReader(filePath);
            textBox.Text = fileReader.ReadToEnd();
            fileReader.Close();
        }

        private void writeTxt() //This function write all textBox text on the .txt file
        {
            fileWriter = new StreamWriter(filePath);
            fileWriter.WriteLine(textBox.Text);
            fileWriter.Close();
        }

        private void setSuggestWords()
        {
            String partialTextBox = textBox.Text.Substring(0, textBox.SelectionStart); //Partial text of textBox, when the last word is the word typed by user
            int index = partialTextBox.LastIndexOf(this.word); //Get index of the last aparition of a word
            Point posRespectTb = textBox.GetPositionFromCharIndex(index); //Get position (x,y) of index respect to textBox
            int length = 0;
            foreach (String word in this.suggestWords)
            {
                if (word.Length > length)
                {
                    length = word.Length;
                }
                listBox.Items.Add(word);
            }
            listBox.SetBounds(posRespectTb.X + textBox.Location.X, posRespectTb.Y + textBox.Location.Y + 15, length * 8 + this.suggestWords.Count, 50);
            listBox.Visible = true;
        }

        private void setNull()
        {
            this.word = "";
            this.suggestTree.setLastWord();
            this.number = false;
        }

        private void openToolStrip_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePicker = new OpenFileDialog();
            filePicker.Filter = "Text Files(*.txt) | *.txt";
            if (filePicker.ShowDialog() == DialogResult.OK)
            {
                filePath = filePicker.FileName;
                setTextBox();
                this.saveToolStrip.Enabled = true;
            }
            filePicker.Dispose();    
        }

        private void newToolStrip_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Title = "Guardar nuevo archivo";
            fileSaver.Filter = "Text Files(*.txt) | *.txt";
            if (fileSaver.ShowDialog() == DialogResult.OK && fileSaver.FileName.Length > 0)
            {
                filePath = fileSaver.FileName;
                File.Create(filePath).Dispose(); //Create new file them dispose it cuz File.Create() return a FileStream and FileStream'll lock new file
                this.saveToolStrip.Enabled = true;
            }
            fileSaver.Dispose();
        }

        private void saveToolStrip_Click(object sender, EventArgs e)
        {
            if (filePath != null)
            {
                writeTxt();
            }
        }

        private void saveAsToolStrip_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileSaver = new SaveFileDialog();
            fileSaver.Title = "Guardar en";
            fileSaver.Filter = "Text Files(*.txt) | *.txt";
            if (fileSaver.ShowDialog() == DialogResult.OK && fileSaver.FileName.Length > 0)
            {
                writeTxt();
                this.saveToolStrip.Enabled = true;
            }
            fileSaver.Dispose();
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            this.setNull();
        }

        private void listBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String listBoxItem = listBox.SelectedItem + "";
                String part1 = textBox.Text.Substring(0, textBox.SelectionStart - this.word.Length);
                String part2 = textBox.Text.Substring(part1.Length + this.word.Length);
                textBox.Text = part1 + listBoxItem + part2;
                textBox.SelectionStart = (part1 + listBoxItem).Length;
                listBox.Visible = false;
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWordForm addWord = new AddWordForm();
            addWord.StartPosition = FormStartPosition.CenterParent; //Set addWord position on center of MainFrame position
            if (addWord.ShowDialog() == DialogResult.OK && addWord.text.Length > 0)
            {
                this.suggestTree.addNode(addWord.text, 0, this.suggestTree.getRoot());
            }
            addWord = null;
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.database.writeDatabase(this.suggestTree.getRoot()); //Overwrite Database.txt with old and new words
        }

        private void textBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            this.setNull();
        }

        private void textBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.setNull();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.suggestWords.Clear();
            listBox.Items.Clear();
            if (Char.IsDigit(e.KeyChar))
            {
                this.number = true;
                this.word = this.word + Convert.ToString(e.KeyChar);
                this.word = this.word.ToLower();
            }
            if (Char.IsLetter(e.KeyChar))
            {
                this.word = this.word + Convert.ToString(e.KeyChar);
                this.word = this.word.ToLower();
                this.suggestWords = this.suggestTree.getSuggestWords(this.word, false);
                if (this.suggestWords.Count != 0)
                {
                    this.setSuggestWords();
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (this.word.Length > 1)
                {
                    this.word = this.word.Substring(0, this.word.Length - 1);
                    this.word = this.word.ToLower();
                    if (!this.number)
                    {
                        this.suggestWords = this.suggestTree.getSuggestWords(this.word, true);
                        if (this.suggestWords.Count != 0)
                        {
                            this.setSuggestWords();
                        }
                    }
                }
                else
                {
                    this.setNull();
                }
            }
            if (!Char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                this.setNull();
            }
            if (this.suggestWords.Count == 0)
            {
                listBox.Visible = false;
            }
        }
    }
}