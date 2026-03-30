using System;
using CaesarCipher.Core;

namespace CaesarCipher.ConsoleApp
{
    /// <summary>
    /// Точка входа в консольное приложение «Шифр Цезаря».
    /// Демонстрирует шифрование и дешифрование на примерах.
    /// </summary>
    internal class Program
    {
        private static readonly CaesarCipherService _cipher = new CaesarCipherService();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding  = System.Text.Encoding.UTF8;

            PrintHeader();

            bool running = true;
            while (running)
            {
                PrintMenu();
                string choice = Console.ReadLine()?.Trim() ?? string.Empty;

                switch (choice)
                {
                    case "1": RunEncrypt(); break;
                    case "2": RunDecrypt(); break;
                    case "3": RunDemo();    break;
                    case "0": running = false; break;
                    default:
                        ColorWrite("Неизвестная команда. Попробуйте снова.\n", ConsoleColor.Red);
                        break;
                }
            }

            ColorWrite("\nДо свидания!\n", ConsoleColor.Cyan);
        }

        // ─── Меню ───────────────────────────────────────────────────────────────────

        private static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║        ШИФР ЦЕЗАРЯ  v1.0            ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();
        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("  [1] Зашифровать текст");
            Console.WriteLine("  [2] Расшифровать текст");
            Console.WriteLine("  [3] Демо-примеры");
            Console.WriteLine("  [0] Выход");
            Console.Write("\nВаш выбор: ");
        }

        // ─── Режим шифрования ───────────────────────────────────────────────────────

        /// <summary>Запрашивает данные у пользователя и шифрует введённый текст.</summary>
        private static void RunEncrypt()
        {
            Console.Write("\nВведите текст для шифрования: ");
            string text = Console.ReadLine() ?? string.Empty;

            int shift = ReadShift();

            try
            {
                string encrypted = _cipher.EncryptCaesar(text, shift);
                ColorWrite($"\nЗашифрованный текст: {encrypted}\n", ConsoleColor.Green);
            }
            catch (Exception ex)
            {
                ColorWrite($"\nОшибка: {ex.Message}\n", ConsoleColor.Red);
            }
        }

        // ─── Режим дешифрования ─────────────────────────────────────────────────────

        /// <summary>Запрашивает данные у пользователя и расшифровывает введённый текст.</summary>
        private static void RunDecrypt()
        {
            Console.Write("\nВведите текст для расшифровки: ");
            string cipher = Console.ReadLine() ?? string.Empty;

            int shift = ReadShift();

            try
            {
                string decrypted = _cipher.DecryptCaesar(cipher, shift);
                ColorWrite($"\nРасшифрованный текст: {decrypted}\n", ConsoleColor.Yellow);
            }
            catch (Exception ex)
            {
                ColorWrite($"\nОшибка: {ex.Message}\n", ConsoleColor.Red);
            }
        }

        // ─── Демо ───────────────────────────────────────────────────────────────────

        /// <summary>Выводит заранее подготовленные примеры шифрования и дешифрования.</summary>
        private static void RunDemo()
        {
            Console.WriteLine();
            ColorWrite("=== ДЕМО-ПРИМЕРЫ ===\n", ConsoleColor.Cyan);

            Demo("Hello, World!", 3,  "Английский, сдвиг +3");
            Demo("АБВГД, мир!", 4,    "Русский, сдвиг +4");
            Demo("Caesar 123!", 13,   "ROT13 (только буквы)");
            Demo("Test",        0,    "Нулевой сдвиг");
            Demo("abc",         29,   "Сдвиг > длины алфавита");
            Demo("ЯяЁё",        1,    "Граничные буквы русского алфавита");
        }

        private static void Demo(string text, int shift, string label)
        {
            string enc = _cipher.EncryptCaesar(text, shift);
            string dec = _cipher.DecryptCaesar(enc, shift);

            ColorWrite($"[{label}]\n", ConsoleColor.DarkCyan);
            Console.WriteLine($"  Исходный:     {text}");
            Console.WriteLine($"  Зашифрован:   {enc}  (сдвиг {shift})");
            Console.WriteLine($"  Расшифрован:  {dec}");
            Console.WriteLine();
        }

        // ─── Вспомогательные ────────────────────────────────────────────────────────

        /// <summary>Читает и валидирует целочисленный сдвиг из стандартного ввода.</summary>
        private static int ReadShift()
        {
            int shift;
            while (true)
            {
                Console.Write("Введите сдвиг (целое число): ");
                if (int.TryParse(Console.ReadLine(), out shift))
                    return shift;
                ColorWrite("Ошибка: введите целое число.\n", ConsoleColor.Red);
            }
        }

        /// <summary>Выводит строку в заданном цвете и сбрасывает цвет консоли.</summary>
        private static void ColorWrite(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
