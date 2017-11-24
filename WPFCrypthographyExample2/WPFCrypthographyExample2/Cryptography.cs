using System;
using System.Linq;

namespace WPFCrypthographyExample2
{
    class Cryptograghy
    {
        private static char[] letters = {
            'а', 'б', 'в', 'г', 'д', 'е', 'ё',
            'ж', 'з', 'и', 'й', 'к', 'л', 'м',
            'н', 'о', 'п', 'р','с', 'т', 'у', 'ф',
            'х', 'ц', 'ч', 'ш', 'щ', 'ъ',
            'ы', 'ь', 'э', 'ю', 'я'};

        public static string Encode(string word, string key)
        {
            string resultWord = "";
            char[] wordCharArray = word.ToCharArray();
            int startIndex = 0;

            if (!IsWordCorrect(word) || !IsWordCorrect(key))
                return "Некорректное значение";

            for (int i = 0; i < wordCharArray.Length; i++)
            {
                startIndex = IndexOf(wordCharArray[i]);
                char encodedChar = GetEncodedChar(startIndex, IndexOf(key[i]));
                wordCharArray[i] = encodedChar;
            }

            resultWord = new string(wordCharArray);

            return resultWord;
        }

        public static string Decode(string word, string key)
        {
            string resultWord = "";
            char[] wordCharArray = word.ToCharArray();
            int startIndex = 0;

            if (!IsWordCorrect(word) || !IsWordCorrect(key))
                return "Некорректное значение";

            for (int i = 0; i < wordCharArray.Length; i++)
            {
                startIndex = IndexOf(wordCharArray[i]);
                char decodedChar = GetDecodedChar(startIndex, IndexOf(key[i]));
                wordCharArray[i] = decodedChar;
            }

            resultWord = new string(wordCharArray);

            return resultWord;
        }

        private static bool IsWordCorrect(string word)
        {
            char[] wordCharArray = word.ToCharArray();

            for (int i = 0; i < wordCharArray.Length; i++)
                if (!letters.Contains<char>(wordCharArray[i]))
                    return false;

            return true;
        }

        private static int IndexOf(char ch)
        {
            for (int i = 0; i < letters.Length; i++)
                if (ch == letters[i])
                    return i;

            return -1;
        }

        private static char GetEncodedChar(int startIndex, int key)
        {
            char ch = ' ';

            int charIndex = (startIndex + key) % letters.Length;
            ch = letters[charIndex];

            return ch;
        }

        private static char GetDecodedChar(int startIndex, int key)
        {
            char ch = ' ';

            int charIndex = Math.Abs(startIndex - key + letters.Length) % letters.Length;
            ch = letters[charIndex];

            return ch;
        }
    }
}
