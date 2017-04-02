namespace WordHandler
{
    class WordBuilder {
        public static bool CouldBuild(string longWord, string smallWord) {
            if (smallWord.Length > longWord.Length) {
                return false;
            }

            foreach (char symbol in smallWord) {
                if (!longWord.Contains(symbol.ToString())) {
                    return false;
                }

                longWord.Remove(longWord.IndexOf(symbol), 1);
            }

            return true;
        }
    }
}
