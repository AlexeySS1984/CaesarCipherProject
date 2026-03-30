using System;

namespace CaesarCipher.Core
{
    /// <summary>
    /// Предоставляет методы шифрования и дешифрования текста с использованием шифра Цезаря.
    /// Поддерживает русский и английский алфавиты, сохраняет регистр и неалфавитные символы.
    /// </summary>
    public class CaesarCipherService
    {
        // ─── Константы алфавитов ────────────────────────────────────────────────────

        private const string EnglishLower = "abcdefghijklmnopqrstuvwxyz";
        private const string EnglishUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string RussianLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string RussianUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

        // ─── Публичные методы ───────────────────────────────────────────────────────

        /// <summary>
        /// Шифрует текст методом Цезаря с указанным сдвигом.
        /// </summary>
        /// <param name="text">Исходный текст для шифрования.</param>
        /// <param name="shift">Величина сдвига (может быть отрицательной).</param>
        /// <returns>Зашифрованный текст.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="text"/> равен null.</exception>
        public string EncryptCaesar(string text, int shift)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text), "Текст не может быть null.");

            return ProcessText(text, shift);
        }

        /// <summary>
        /// Дешифрует текст, зашифрованный методом Цезаря с указанным сдвигом.
        /// </summary>
        /// <param name="cipher">Зашифрованный текст.</param>
        /// <param name="shift">Величина сдвига, применённая при шифровании.</param>
        /// <returns>Расшифрованный текст.</returns>
        /// <exception cref="ArgumentNullException">Выбрасывается, если <paramref name="cipher"/> равен null.</exception>
        public string DecryptCaesar(string cipher, int shift)
        {
            if (cipher == null)
                throw new ArgumentNullException(nameof(cipher), "Шифртекст не может быть null.");

            // Дешифрование — это шифрование с обратным сдвигом
            return ProcessText(cipher, -shift);
        }

        // ─── Приватные вспомогательные методы ──────────────────────────────────────

        /// <summary>
        /// Обрабатывает каждый символ строки, применяя сдвиг Цезаря.
        /// </summary>
        /// <param name="text">Входная строка.</param>
        /// <param name="shift">Величина сдвига.</param>
        /// <returns>Обработанная строка.</returns>
        private static string ProcessText(string text, int shift)
        {
            var result = new System.Text.StringBuilder(text.Length);

            foreach (char ch in text)
            {
                result.Append(ShiftChar(ch, shift));
            }

            return result.ToString();
        }

        /// <summary>
        /// Сдвигает один символ на заданное количество позиций в соответствующем алфавите.
        /// Неалфавитные символы возвращаются без изменений.
        /// </summary>
        /// <param name="ch">Исходный символ.</param>
        /// <param name="shift">Величина сдвига.</param>
        /// <returns>Сдвинутый символ.</returns>
        private static char ShiftChar(char ch, int shift)
        {
            // Определяем, в каком алфавите находится символ
            string alphabet = GetAlphabet(ch);

            if (alphabet == null)
                return ch; // Неалфавитный символ — возвращаем как есть

            int index = alphabet.IndexOf(ch);
            int length = alphabet.Length;

            // Нормализуем сдвиг, чтобы он всегда был положительным
            int normalizedShift = ((shift % length) + length) % length;
            int newIndex = (index + normalizedShift) % length;

            return alphabet[newIndex];
        }

        /// <summary>
        /// Определяет алфавит (строку символов), которому принадлежит символ.
        /// </summary>
        /// <param name="ch">Символ для проверки.</param>
        /// <returns>Строка алфавита или null, если символ не является буквой.</returns>
        private static string GetAlphabet(char ch)
        {
            if (EnglishLower.IndexOf(ch) >= 0) return EnglishLower;
            if (EnglishUpper.IndexOf(ch) >= 0) return EnglishUpper;
            if (RussianLower.IndexOf(ch) >= 0) return RussianLower;
            if (RussianUpper.IndexOf(ch) >= 0) return RussianUpper;
            return null;
        }
    }
}
