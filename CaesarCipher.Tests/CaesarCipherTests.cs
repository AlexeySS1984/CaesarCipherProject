using System;
using NUnit.Framework;
using CaesarCipher.Core;

namespace CaesarCipher.Tests
{
    /// <summary>
    /// Автоматизированные тесты для <see cref="CaesarCipherService"/>.
    /// Покрывают функциональные требования к шифрованию и дешифрованию.
    /// </summary>
    [TestFixture]
    public class CaesarCipherTests
    {
        private CaesarCipherService _cipher = null!;

        [SetUp]
        public void SetUp()
        {
            _cipher = new CaesarCipherService();
        }

        // ═══════════════════════════════════════════════════════════════════════════
        //  ТС-001 … ТС-010  ПОЗИТИВНЫЕ ТЕСТЫ — АНГЛИЙСКИЙ АЛФАВИТ
        // ═══════════════════════════════════════════════════════════════════════════

        /// <summary>ТС-001: Шифрование строчных английских букв со сдвигом 3.</summary>
        [Test]
        public void Encrypt_EnglishLowercase_Shift3_ReturnsCorrectCipher()
        {
            Assert.That(_cipher.EncryptCaesar("abc", 3), Is.EqualTo("def"));
        }

        /// <summary>ТС-002: Шифрование заглавных английских букв со сдвигом 3.</summary>
        [Test]
        public void Encrypt_EnglishUppercase_Shift3_ReturnsCorrectCipher()
        {
            Assert.That(_cipher.EncryptCaesar("XYZ", 3), Is.EqualTo("ABC"));
        }

        /// <summary>ТС-003: Дешифрование строчных английских букв со сдвигом 3.</summary>
        [Test]
        public void Decrypt_EnglishLowercase_Shift3_ReturnsOriginal()
        {
            Assert.That(_cipher.DecryptCaesar("def", 3), Is.EqualTo("abc"));
        }

        /// <summary>ТС-004: Шифрование классического примера «Hello World».</summary>
        [Test]
        public void Encrypt_HelloWorld_Shift13_ReturnsROT13()
        {
            Assert.That(_cipher.EncryptCaesar("Hello, World!", 13), Is.EqualTo("Uryyb, Jbeyq!"));
        }

        /// <summary>ТС-005: Обратимость: шифрование → дешифрование возвращает оригинал (английский).</summary>
        [Test]
        public void EncryptDecrypt_English_Shift7_IsReversible()
        {
            const string original = "The quick brown fox";
            string encrypted = _cipher.EncryptCaesar(original, 7);
            string decrypted = _cipher.DecryptCaesar(encrypted, 7);
            Assert.That(decrypted, Is.EqualTo(original));
        }

        /// <summary>ТС-006: Сохранение неалфавитных символов (пробелы, знаки препинания, цифры).</summary>
        [Test]
        public void Encrypt_NonAlphaChars_ArePreserved()
        {
            Assert.That(_cipher.EncryptCaesar("Hello, 123!", 3), Is.EqualTo("Khoor, 123!"));
        }

        /// <summary>ТС-007: Сохранение регистра при шифровании.</summary>
        [Test]
        public void Encrypt_PreservesCase()
        {
            string result = _cipher.EncryptCaesar("aAbB", 1);
            Assert.That(result, Is.EqualTo("bBcC"));
        }

        /// <summary>ТС-008: Шифрование с отрицательным сдвигом.</summary>
        [Test]
        public void Encrypt_NegativeShift_WorksCorrectly()
        {
            Assert.That(_cipher.EncryptCaesar("def", -3), Is.EqualTo("abc"));
        }

        /// <summary>ТС-009: Сдвиг, превышающий длину алфавита (>26).</summary>
        [Test]
        public void Encrypt_ShiftGreaterThanAlphabetLength_WrapsAround()
        {
            // 29 % 26 = 3, результат эквивалентен сдвигу 3
            Assert.That(_cipher.EncryptCaesar("abc", 29), Is.EqualTo("def"));
        }

        /// <summary>ТС-010: Сдвиг, равный нулю — текст не изменяется.</summary>
        [Test]
        public void Encrypt_ZeroShift_ReturnsOriginalText()
        {
            const string text = "Hello, World!";
            Assert.That(_cipher.EncryptCaesar(text, 0), Is.EqualTo(text));
        }

        // ═══════════════════════════════════════════════════════════════════════════
        //  ТС-011 … ТС-020  ПОЗИТИВНЫЕ ТЕСТЫ — РУССКИЙ АЛФАВИТ
        // ═══════════════════════════════════════════════════════════════════════════

        /// <summary>ТС-011: Шифрование строчных русских букв со сдвигом 3.</summary>
        [Test]
        public void Encrypt_RussianLowercase_Shift3_ReturnsCorrectCipher()
        {
            // а→г, б→д, в→е
            Assert.That(_cipher.EncryptCaesar("абв", 3), Is.EqualTo("где"));
        }

        /// <summary>ТС-012: Шифрование заглавных русских букв со сдвигом 3.</summary>
        [Test]
        public void Encrypt_RussianUppercase_Shift3_ReturnsCorrectCipher()
        {
            Assert.That(_cipher.EncryptCaesar("АБВ", 3), Is.EqualTo("ГДЕ"));
        }

        /// <summary>ТС-013: Дешифрование русского текста со сдвигом 4.</summary>
        [Test]
        public void Decrypt_Russian_Shift4_ReturnsOriginal()
        {
            string original = "Привет";
            string encrypted = _cipher.EncryptCaesar(original, 4);
            Assert.That(_cipher.DecryptCaesar(encrypted, 4), Is.EqualTo(original));
        }

        /// <summary>ТС-014: Обратимость для русского текста с большим сдвигом.</summary>
        [Test]
        public void EncryptDecrypt_Russian_Shift20_IsReversible()
        {
            const string original = "Шифр Цезаря работает";
            string encrypted = _cipher.EncryptCaesar(original, 20);
            string decrypted = _cipher.DecryptCaesar(encrypted, 20);
            Assert.That(decrypted, Is.EqualTo(original));
        }

        /// <summary>ТС-015: Буква «Ё» — граничный случай русского алфавита.</summary>
        [Test]
        public void Encrypt_RussianLetterYo_HandledCorrectly()
        {
            // Ё занимает 6-ю позицию в алфавите (индекс 6), сдвиг 1 → Ж
            Assert.That(_cipher.EncryptCaesar("Ё", 1), Is.EqualTo("Ж"));
        }

        /// <summary>ТС-016: Последняя буква «Я» — переход в начало алфавита.</summary>
        [Test]
        public void Encrypt_LastRussianLetter_WrapsToStart()
        {
            // я → а при сдвиге 1
            Assert.That(_cipher.EncryptCaesar("я", 1), Is.EqualTo("а"));
        }

        /// <summary>ТС-017: Первая буква «А» при отрицательном сдвиге — переход в конец алфавита.</summary>
        [Test]
        public void Encrypt_FirstRussianLetter_NegativeShift_WrapsToEnd()
        {
            // а → я при сдвиге -1
            Assert.That(_cipher.EncryptCaesar("а", -1), Is.EqualTo("я"));
        }

        /// <summary>ТС-018: Смешанный текст: русский + английский + цифры + знаки.</summary>
        [Test]
        public void Encrypt_MixedText_AllComponentsHandledCorrectly()
        {
            // Русские и английские буквы шифруются, остальное сохраняется
            string result = _cipher.EncryptCaesar("Аа Aa 1!", 3);
            Assert.That(result, Is.EqualTo("Гг Dd 1!"));
        }

        /// <summary>ТС-019: Сдвиг кратен длине русского алфавита (33) — текст не меняется.</summary>
        [Test]
        public void Encrypt_ShiftMultipleOfRussianAlphabetLength_ReturnsOriginal()
        {
            const string text = "Привет";
            Assert.That(_cipher.EncryptCaesar(text, 33), Is.EqualTo(text));
        }

        /// <summary>ТС-020: Сдвиг кратен длине английского алфавита (26) — текст не меняется.</summary>
        [Test]
        public void Encrypt_ShiftMultipleOfEnglishAlphabetLength_ReturnsOriginal()
        {
            const string text = "Hello";
            Assert.That(_cipher.EncryptCaesar(text, 26), Is.EqualTo(text));
        }

        // ═══════════════════════════════════════════════════════════════════════════
        //  ТС-021 … ТС-026  ГРАНИЧНЫЕ И СПЕЦИАЛЬНЫЕ СЛУЧАИ
        // ═══════════════════════════════════════════════════════════════════════════

        /// <summary>ТС-021: Пустая строка — возвращается пустая строка без исключения.</summary>
        [Test]
        public void Encrypt_EmptyString_ReturnsEmptyString()
        {
            Assert.That(_cipher.EncryptCaesar(string.Empty, 5), Is.EqualTo(string.Empty));
        }

        /// <summary>ТС-022: Строка только из пробелов — возвращается без изменений.</summary>
        [Test]
        public void Encrypt_WhitespaceOnly_ReturnsUnchanged()
        {
            Assert.That(_cipher.EncryptCaesar("   ", 5), Is.EqualTo("   "));
        }

        /// <summary>ТС-023: Строка только из цифр — возвращается без изменений.</summary>
        [Test]
        public void Encrypt_DigitsOnly_ReturnsUnchanged()
        {
            Assert.That(_cipher.EncryptCaesar("1234567890", 10), Is.EqualTo("1234567890"));
        }

        /// <summary>ТС-024: Строка только из спецсимволов — возвращается без изменений.</summary>
        [Test]
        public void Encrypt_SpecialCharsOnly_ReturnsUnchanged()
        {
            Assert.That(_cipher.EncryptCaesar("!@#$%^&*()", 7), Is.EqualTo("!@#$%^&*()"));
        }

        /// <summary>ТС-025: Очень большой положительный сдвиг (int.MaxValue / 2).</summary>
        [Test]
        public void Encrypt_VeryLargeShift_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => _cipher.EncryptCaesar("abc", 1_000_000));
        }

        /// <summary>ТС-026: Очень большой отрицательный сдвиг.</summary>
        [Test]
        public void Encrypt_VeryLargeNegativeShift_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => _cipher.EncryptCaesar("abc", -1_000_000));
        }

        // ═══════════════════════════════════════════════════════════════════════════
        //  ТС-027 … ТС-030  НЕГАТИВНЫЕ ТЕСТЫ — ИСКЛЮЧЕНИЯ
        // ═══════════════════════════════════════════════════════════════════════════

        /// <summary>ТС-027: EncryptCaesar(null, ...) выбрасывает ArgumentNullException.</summary>
        [Test]
        public void Encrypt_NullText_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _cipher.EncryptCaesar(null!, 3));
        }

        /// <summary>ТС-028: DecryptCaesar(null, ...) выбрасывает ArgumentNullException.</summary>
        [Test]
        public void Decrypt_NullCipher_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _cipher.DecryptCaesar(null!, 3));
        }

        /// <summary>ТС-029: Сдвиг int.MinValue не вызывает переполнения.</summary>
        [Test]
        public void Encrypt_IntMinShift_DoesNotOverflow()
        {
            // Главное — не выбросить StackOverflowException или OverflowException
            Assert.DoesNotThrow(() => _cipher.EncryptCaesar("abc", int.MinValue + 1));
        }

        /// <summary>ТС-030: Обратимость при нулевом сдвиге — дешифрование возвращает тот же текст.</summary>
        [Test]
        public void EncryptDecrypt_ZeroShift_IsIdentity()
        {
            const string text = "Любой текст / Any text 123";
            string enc = _cipher.EncryptCaesar(text, 0);
            string dec = _cipher.DecryptCaesar(enc, 0);
            Assert.That(dec, Is.EqualTo(text));
        }
    }
}
