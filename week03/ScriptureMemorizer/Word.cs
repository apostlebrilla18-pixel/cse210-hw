namespace ScriptureMemorizer
{
    public class Word
    {
        private readonly string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }
        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        /// Returns the text that should be shown for this word: the word
        /// itself if it is visible, or a run of underscores matching its
        /// length if it is hidden.
        public string GetDisplayText()
        {
            if (!_isHidden)
            {
                return _text;
            }

            return new string('_', _text.Length);
        }
    }
}
