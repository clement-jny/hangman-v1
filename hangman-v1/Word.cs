using System;
using System.Collections.Generic;
using System.Text;

namespace hangman_v1
{
    class Word
    {
        private string word;
        private int lenght;

        public Word(string p_word)
        {
            word = p_word;
            lenght = word.Length;
        }

        public string GetSetWord
        {
            get { return word; }
            set { word = value; lenght = word.Length; }
        }

        public int GetLenght
        {
            get { return lenght; }
        }

        public int PositionChar(char p_char)
        {
            return word.IndexOf(p_char);
        }
    }
}