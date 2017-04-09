using System;

namespace Happy
{
    public class HappyNumbers
    {  
        private static int maxNumberLength = Int32.MaxValue.ToString().Length;

        private int numberLength = 0;
        private int lastHappyNumber = 0;
        private bool noHappyNumbers = false;

        private int startRange = 0;
        private int endRange = 0;

        /// <summary>  
        /// Конструктор класса  
        /// </summary>  
        /// <param name="length">Длина счастливого билета в цифрах (четное число)</param>  
        public HappyNumbers(int length)
        {
            if ((length > 1) && (length <= maxNumberLength) && IsEven(length)) 
            {
                numberLength = length;
            }
        }
 
        /// <summary>  
        /// Возвращает следующий по порядку счастливый номер или 0, если таких номеров больше нет
        /// </summary>  
        /// <returns>Например, 12344321 (для длины номера 8) или 0 (для длины номера 1)</returns>  
        public int GetHappyNumber()  
        {  
            if ((numberLength == 0) || noHappyNumbers)
            {
                return 0;
            }

            startRange = (lastHappyNumber == 0) ? (int) Math.Pow(10, numberLength - 1) : lastHappyNumber + 1;
            
            if (endRange == 0)
            {
                endRange = (numberLength == maxNumberLength) ? Int32.MaxValue : (int) Math.Pow(10, numberLength);
            } 
            
            for (int number = startRange; number < endRange; number++) 
            {
                if (IsHappyNumber(number))
                {
                    lastHappyNumber = number;
                    return number;
                }
            }
            
            noHappyNumbers = true;

            return 0;
        }

        /// <summary>
        /// Возвращает последний отданный ранее счастливый билет
        /// </summary>
        public int LastHappyNumber
        {
            get { return lastHappyNumber; }
        }

        /// <summary>
        /// Возвращает true, если число счастливое. Поддерживает числа как с четной так и с нечетной длиной
        /// </summary>
        /// <param name="number">Число</param>
        public static bool IsHappyNumber(int number) {
            string numberAsString = number.ToString();
            
            int halfLength = numberAsString.Length / 2;
            int firstHalf = Int32.Parse(numberAsString.Substring(0, halfLength));
            int secondHalf = Int32.Parse(numberAsString.Substring(halfLength + Convert.ToInt32(!IsEven(numberAsString.Length))));

            return (SumDigits(firstHalf) == SumDigits(secondHalf));
        }
        
        /// <summary>
        /// Возвращает true, если число нечетное
        /// </summary>
        /// <param name="number">Число</param>  
        private static bool IsEven(int number) {
            return (number % 2 == 0);
        }

        /// <summary>
        /// Возвращает сумму цифр в числе
        /// </summary>
        /// <param name="number">Число</param> 
        private static int SumDigits(int number) {
            int sum = 0;
            
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
    }
}
