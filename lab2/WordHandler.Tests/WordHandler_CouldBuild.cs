using Xunit;

namespace WordHandler.Tests
{
    public class WordHandler_CouldBuild
    {   
        /// <summary>
        /// Проверяем корректность работы функции при длине маленького слова большей, чем у большого слова.
        /// </summary>
        [Theory]
        [InlineData("Word", "LongWord")]
        [InlineData("Dog", "Dachshund")]
        [InlineData("C#", "Python")]
        public void ReturnFalseIfGivenSmallWordLongerThenLongWord(string longWord, string smallWord)
        {
            bool result = WordBuilder.CouldBuild(longWord, smallWord);
            Assert.False(result);
        }
        
        /// <summary>
        /// Проверяем корректность работы функции при "нормальных" условиях.
        /// </summary>
        [Theory]
        [InlineData("Anatomy", "Tom")]
        [InlineData("Hotdog", "Dog")]
        [InlineData("MrRobbins", "Bob")]
        [InlineData("Teacher", "Teacher")]
        [InlineData("Teacher", "Tea")]
        [InlineData("Teacher", "Reach")]
        [InlineData("Illustrator", "Rotartsulli")]
        public void ReturnTrueIfSmallWordCouldBuildFromLongWord(string longWord, string smallWord)
        {
            bool result = WordBuilder.CouldBuild(longWord, smallWord);
            Assert.True(result, $"{smallWord} should be possible to build from {longWord})");
        }
        
        /// <summary>
        /// Проверяем, что при составлении маленького слова из букв большого эти буквы используются единожды.
        /// </summary>
        [Theory]
        [InlineData("Anatomy", "Toomy")]
        [InlineData("Hotdog", "Hotdoog")]
        [InlineData("MrRobbins", "Bobbo")]
        [InlineData("Teacher", "Teeaa")]
        public void VerifyThatTheLetterOfTheLongWordIsUsedOnce(string longWord, string smallWord)
        {
            bool result = WordBuilder.CouldBuild(longWord, smallWord);
            Assert.False(result, $"{smallWord} should use one letter from another word {longWord})");
        }

        [Fact]
        public void SharpCanNotBeConstructedFromShark()
        {
            bool result = WordBuilder.CouldBuild("Sharp", "Shark");
            Assert.False(result, $"# is not fish!");
        }
    }
}
