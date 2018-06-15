using System;
using System.Collections.Generic;
using System.Text;

namespace Encrypting
{
    public enum E_Language
    {
        English,
        Russian
    }

    class Alphabet
    {
        static readonly char[] RusAlph = {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
        'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т',
        'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
        'э', 'ю', 'я' };

        static readonly char[] EngAlph = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
        'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
        'u', 'v', 'w', 'x', 'y', 'z' };

        public static char GetCharFromNum(int inNum, E_Language inLanguage)
        {
            if (inNum >= 0)
                switch (inLanguage)
                {
                    case E_Language.English:
                        if (inNum < EngAlph.Length)
                            return EngAlph[inNum];

                        break;
                    case E_Language.Russian:
                        if (inNum < RusAlph.Length)
                            return RusAlph[inNum];
                        break;
                }

            return '\0';
        }

        public static int GetNumFromChar(char inChar, E_Language inLanguage)
        {
            switch (inLanguage)
            {
                case E_Language.English:
                    for (int i = 0; i < EngAlph.Length; ++i)
                        if (EngAlph[i] == inChar)
                            return i;

                    break;
                case E_Language.Russian:
                    for (int i = 0; i < RusAlph.Length; ++i)
                        if (RusAlph[i] == inChar)
                            return i;
                    break;
            }

            return -1;
        }

    }
}
