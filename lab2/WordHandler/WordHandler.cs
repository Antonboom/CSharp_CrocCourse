namespace WordHandler
{
    public class WordBuilder {
        /// <summary>
        /// Можно ли построить слово smallWord из букв, входящих в слово longWord 
        /// (каждую букву слова longWord можно использовать только один раз).
        /// Регистр слов не учитывается: слово "Река" можно построить из слова "Америка".
        /// <param name="smallWord">Слово, которое требуется построить.</param>
        /// <param name="longWord">Слово, из букв которого необходимо построить smallWord.</param>
        /// </summary>
        public static bool CouldBuild(string longWord, string smallWord) {
            if (smallWord.Length > longWord.Length) {
                return false;
            }
            
            longWord = longWord.ToLower();
            smallWord = smallWord.ToLower();

            foreach (char symbol in smallWord) {
                if (!longWord.Contains(symbol.ToString())) {
                    return false;
                }

                longWord = longWord.Remove(longWord.IndexOf(symbol), 1);
            }

            return true;
        }
    }
}
