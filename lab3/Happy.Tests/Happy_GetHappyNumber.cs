using Xunit;

namespace Happy.Tests
{
    public class Happy_GetHappyNumber
    {   
        /// <summary>
        /// Проверяем корректность работы функции при отрицательных и нечетных длинах "счастливого" билета
        /// </summary>
        [Theory]
        [InlineData(-100)]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(1)]
        [InlineData(7)]
        [InlineData(91)]
        [InlineData(11)]
        [InlineData(273)]
        [InlineData(0)]
        public void ReturnZeroForNegativeAndOddLengths(int length) {
            HappyNumbers happyNumbers = new HappyNumbers(length);
            
            int happyNumber = happyNumbers.GetHappyNumber();
            Assert.Equal(0, happyNumber);
        }

        /// <summary>
        /// Проверяем корректность работы функции при длинах "счастливого" билета, превышающих длину максимального 4-байтного целого числа
        /// </summary>
        [Theory]
        [InlineData(11)]
        [InlineData(12)]
        [InlineData(1000)]
        [InlineData(1001)]
        [InlineData(2147483647)]
        public void ReturnZeroForBigLengths(int length) {
            HappyNumbers happyNumbers = new HappyNumbers(length);
            
            int happyNumber = happyNumbers.GetHappyNumber();
            Assert.Equal(0, happyNumber);
        }
        
        /// <summary>
        /// Проверяем, что функция отдает "счастливые" билеты последовательно, и если билеты закончились, возвращает ноль
        /// </summary>
        [Theory]
        [InlineData(2, (object)(new object[] {11, 22, 33, 44, 55, 66, 77, 88, 99, 0, 0, 0, 0, 0}))]
        [InlineData(4, (object)(new object[] {1001, 1010, 1102, 1111, 1120, 1203, 1212, 1221, 1230, 1304, 1313, 1322, 1331, 1340}))]
        [InlineData(6, (object)(new object[] {100001, 100010, 100100, 101002, 101011, 101020, 101101, 101110, 101200, 102003, 102012}))]
        [InlineData(10, (object)(new object[] {1000000001, 1000000010, 1000000100}))]
        public void TestHappyNumbersSequence(int length, int[] numbers)
        {   
            HappyNumbers happyNumbers = new HappyNumbers(length);
        
            foreach (int number in numbers)
            {
                Assert.Equal(number, happyNumbers.GetHappyNumber());
            }
        }
        
        /// <summary>
        /// Вспомогательная функция IsHappyNumber возвращает true для "счастливых" билетов (чисел)
        /// </summary>
        [Theory]
        [InlineData(90209)]
        [InlineData(3041403)]
        [InlineData(12344321)]
        [InlineData(12340307)]
        [InlineData(90000009)]
        [InlineData(90020209)]
        [InlineData(2147483610)]
        public void ReturnTrueIfHappyNumber(int number)
        {   
            Assert.True(HappyNumbers.IsHappyNumber(number));
        }

        /// <summary>
        /// Вспомогательная функция IsHappyNumber возвращает false для "несчастливых" билетов (чисел)
        /// </summary>
        [Theory]
        [InlineData(8000009)]
        [InlineData(9002109)]
        [InlineData(12345678)]
        [InlineData(14240307)]
        [InlineData(1145583610)]
        public void ReturnFalseIfUnhappyNumber(int number)
        {   
            Assert.False(HappyNumbers.IsHappyNumber(number));
        }

        /// <summary>
        /// Проверим, что механизм сохранения последнего "счастливого" билета исправен
        /// </summary>
        [Fact]
        public void TestSavingLastHappyNumber()
        {   
            HappyNumbers happyNumbers = new HappyNumbers(4);

            int fifthHappyNumberWithLengthFour = 1120;
            int tenthHappyNumberWithLengthFour = 1304;

            for (int i = 0; i < 5; i++) {
                happyNumbers.GetHappyNumber();
            }

            Assert.Equal(happyNumbers.LastHappyNumber, fifthHappyNumberWithLengthFour);

            for (int i = 0; i < 5; i++)
            {
                happyNumbers.GetHappyNumber();
            }

            Assert.Equal(happyNumbers.LastHappyNumber, tenthHappyNumberWithLengthFour);
        }
    }
}
