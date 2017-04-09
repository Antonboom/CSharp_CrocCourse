using System;

namespace Happy
{
    public class HappyNumbers
    {  
        private int numberLength = 0;
        private int lastHappyNumber = 0;
        private bool noHappyNumbers = false;

        /// <summary>  
        /// Конструктор класса  
        /// </summary>  
        /// <param name="length">Длина счастливого билета в цифрах (четное число)</param>  
        public HappyNumbers(int length)
        {
            if (length > 1) {
                numberLength = length;
            }
        }
 
        /// <summary>  
        /// Возвращает следующий по порядку счастливый номер или 0, если таких номеров больше нет
        /// </summary>  
        /// <returns>Например, 12344321 (для длины номера 8) или 0 (для длины номера 1)</returns>  
        public int GetHappyNumber()  
        {  
            if ((numberLength == 0) || noHappyNumbers) {
                return 0;
            }

            int startRange = (lastHappyNumber == 0) ? (int) Math.Pow(10, numberLength - 1) : lastHappyNumber;
            int endRange = (int) Math.Pow(10, numberLength);

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
        /// Возвращает true, если число счастливое
        /// </summary>
        /// <param name="number">Число</param>
        private bool IsHappyNumber(int number) {
            if (IsOdd(number)) {
                return false;
            }

            string numberAsString = number.ToString();
            
            int halfLength = numberAsString.Length / 2;
            int firstHalf = Int32.Parse(numberAsString.Substring(0, halfLength));
            int secondHalf = Int32.Parse(numberAsString.Substring(halfLength));
            
            return (SumDigits(firstHalf) == SumDigits(secondHalf));
        }
        
        /// <summary>
        /// Возвращает true, если число нечетное
        /// </summary>
        /// <param name="number">Число</param>  
        private bool IsOdd(int number) {
            return (number % 2 != 0);
        }
        
        /// <summary>
        /// Возвращает сумму цифр в числе
        /// </summary>
        /// <param name="number">Число</param> 
        private int SumDigits(int number) {
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
