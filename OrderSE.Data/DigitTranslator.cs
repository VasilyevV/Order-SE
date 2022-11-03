namespace OrderSE.Data
{
    public class Translator
    {
        internal static int[] Splitting(long number)//Разбиваем число на разряды 
        {
            int digitCount = (int)Math.Log10(number) + 1;// определяем количество знаков в числе
            int[] result = new int[digitCount];
            int m = digitCount - 1;

            for (int i = digitCount - 1; i >= 0; i--)
            {
                result[i] = Convert.ToInt32(number / (long)Math.Pow(10, m));
                number -= result[i] * (long)Math.Pow(10, m);
                m--;
            }
            return result;
        }

        internal static int[][] ConvertArray(int[] a, int columns)//Преобразуем одномерный массив в массив массивов
        {
            int rows = a.Length / columns;
            if (a.Length % columns > 0)
                rows++;

            int[][] b = new int[rows][];
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] row = new int[columns];
                for (int j = 0; j < columns; j++, count++)
                {
                    if (count == a.Length)
                        break;
                    row[j] = a[count];
                }
                b[i] = row;
            }

            return b;
        }

        internal static string Units(int unit, int genus)//Сопоставление единиц
        {
            switch (unit)
            {
                case 1: if (genus == 1) return " один"; else return " одна";
                case 2: if (genus == 1) return " два"; else return " две";
                case 3: return " три";
                case 4: return " четыре";
                case 5: return " пять";
                case 6: return " шесть";
                case 7: return " семь";
                case 8: return " восемь";
                case 9: return " девять";
                default: return "";
            }
        }

        internal static string Dozens(int dozen)//Сопоставление десятков
        {
            dozen = dozen * 10;
            switch (dozen)
            {
                case 10: return " десять";
                case 20: return " двадцать";
                case 30: return " тридцать";
                case 40: return " сорок";
                case 50: return " пятьдесят";
                case 60: return " шестьдесят";
                case 70: return " семьдесят";
                case 80: return " восемьдесят";
                case 90: return " девяносто";
                default: return "";
            }
        }

        internal static string ExceptionsDozen(int dozen)//Сопоставление чисел 10 - 19
        {
            switch (dozen)
            {
                case 10: return " десять";
                case 11: return " одиннадцать";
                case 12: return " двенадцать";
                case 13: return " тринадцать";
                case 14: return " четырнадцать";
                case 15: return " пятнадцать";
                case 16: return " шестнадцать";
                case 17: return " семнадцать";
                case 18: return " восемнадцать";
                case 19: return " девятнадцать";
                default: return "";
            }
        }

        internal static string Hundreds(int hundred)//Сопоставление сотен
        {
            hundred = hundred * 100;
            switch (hundred)
            {
                case 100: return " сто";
                case 200: return " двести";
                case 300: return " триста";
                case 400: return " четыреста";
                case 500: return " пятьсот";
                case 600: return " шестьсот";
                case 700: return " семьсот";
                case 800: return " восемьсот";
                case 900: return " девятьсот";
                default: return "";
            }
        }

        internal static string BigDigits(int digit, int multiplier)//Вставка тысяч, миллионов, миллиардов
        {
            string[,] bigdigits = new string[4, 3]
            {
                { "", "", "" },
                { " тысяча", " тысячи", " тысяч" },
                { " миллион", " миллиона", " миллионов" },
                { " миллиард", " миллиарда", " миллиардов" }
            };

            switch (digit)
            {
                case 1: return bigdigits[multiplier, 0];
                case 2: return bigdigits[multiplier, 1];
                case 3: return bigdigits[multiplier, 1];
                case 4: return bigdigits[multiplier, 1];
                case 5: return bigdigits[multiplier, 2];
                case 6: return bigdigits[multiplier, 2];
                case 7: return bigdigits[multiplier, 2];
                case 8: return bigdigits[multiplier, 2];
                case 9: return bigdigits[multiplier, 2];
                default: return "";
            }
        }

        public static string Compilation(long number)
        {
            if (number == 0)
                return "ноль";

            var digits = Splitting(number);//преобразуем число в одномерный массив по разрядам
            var array = ConvertArray(digits, 3);  //преобразуем одномерный массив в зубчатый с длиной строки 3
                                                  //12345678 ->   123 - единицы, десятки, сотни
                                                  //              456 - единицы, десятки, сотни тысяч
                                                  //              78  - единицы, десятки, сотни миллионов
                                                  // и т.д.
            string result_string = "";
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int g = 1;
                if (i == 1)
                    g = 2;

                string units = Units(array[i][0], g);
                string dozens;
                string hundreds;
                try
                {
                    if (array[i][1] == 1)
                    {
                        dozens = ExceptionsDozen(10 * array[i][1] + array[i][0]);
                        units = "";
                    }
                    else
                        dozens = Dozens(array[i][1]);
                }
                catch (IndexOutOfRangeException)
                {
                    dozens = "";
                }

                try
                {
                    hundreds = Hundreds(array[i][2]);
                }
                catch (IndexOutOfRangeException)
                {
                    hundreds = "";
                }

                result_string = result_string + hundreds + dozens + units;

                if (units == "")
                    result_string += BigDigits(9, i);
                else
                    result_string += BigDigits(array[i][0], i);

            }

            return result_string;
        }
    }
}
