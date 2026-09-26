using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private readonly Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _random = new Random();

            _words = new List<Word>();
            foreach (string wordText in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                _words.Add(new Word(wordText));
            }
        }

        /// Hides up to the given number of words. Only words that are not
        /// already hidden are eligible to be chosen, so this never "re-hides"
        /// a word that is already hidden (the stretch-goal behavior).
        public void HideRandomWords(int numberToHide)
        {
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            int wordsToHide = Math.Min(numberToHide, visibleWords.Count);
            for (int i = 0; i < wordsToHide; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        /// True once every word in the scripture is hidden.
        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        /// Returns the reference and scripture text formatted for display,
        /// with hidden words shown as underscores.
        public string GetDisplayText()
        {
            string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()}{Environment.NewLine}{wordsText}";
        }
    }
}
