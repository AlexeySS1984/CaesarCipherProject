using System;
using System.Windows.Forms;
using CaesarCipher.Core;

namespace CaesarCipher.GUI
{
    /// <summary>
    /// Главная форма приложения «Шифр Цезаря».
    /// Содержит две вкладки: шифрование и дешифрование.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>Сервис шифрования/дешифрования (единственный экземпляр).</summary>
        private readonly CaesarCipherService _cipher = new CaesarCipherService();

        /// <summary>Инициализирует форму и компоненты.</summary>
        public MainForm()
        {
            InitializeComponent();
        }

        // ─── Обработчики кнопок ───────────────────────────────────────────────────

        /// <summary>
        /// Обрабатывает нажатие кнопки «Зашифровать».
        /// Валидирует ввод, вызывает <see cref="CaesarCipherService.EncryptCaesar"/> и отображает результат.
        /// </summary>
        private void BtnEncrypt_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(txtInputEnc.Text, "шифрования"))
                return;

            try
            {
                int shift = (int)nudShiftEnc.Value;
                string result = _cipher.EncryptCaesar(txtInputEnc.Text, shift);
                txtOutputEnc.Text = result;
                SetStatus($"Зашифровано успешно. Сдвиг: {shift}");
            }
            catch (ArgumentNullException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError($"Неожиданная ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки «Расшифровать».
        /// Валидирует ввод, вызывает <see cref="CaesarCipherService.DecryptCaesar"/> и отображает результат.
        /// </summary>
        private void BtnDecrypt_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(txtInputDec.Text, "дешифрования"))
                return;

            try
            {
                int shift = (int)nudShiftDec.Value;
                string result = _cipher.DecryptCaesar(txtInputDec.Text, shift);
                txtOutputDec.Text = result;
                SetStatus($"Расшифровано успешно. Сдвиг: {shift}");
            }
            catch (ArgumentNullException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError($"Неожиданная ошибка: {ex.Message}");
            }
        }

        // ─── Вспомогательные методы ───────────────────────────────────────────────

        /// <summary>
        /// Проверяет, что текст не является пустым или состоящим только из пробелов.
        /// </summary>
        /// <param name="text">Проверяемый текст.</param>
        /// <param name="operation">Название операции для сообщения об ошибке.</param>
        /// <returns>True, если текст прошёл валидацию; иначе false.</returns>
        private bool ValidateInput(string text, string operation)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                ShowError($"Поле ввода для {operation} не может быть пустым.");
                return false;
            }
            return true;
        }

        /// <summary>Отображает всплывающее окно с сообщением об ошибке.</summary>
        /// <param name="message">Текст сообщения.</param>
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SetStatus("Ошибка: " + message);
        }

        /// <summary>Обновляет текст в строке состояния.</summary>
        /// <param name="message">Сообщение для отображения.</param>
        private void SetStatus(string message)
        {
            statusLabel.Text = message;
        }

        /// <summary>
        /// Копирует текст в буфер обмена и уведомляет пользователя.
        /// </summary>
        /// <param name="text">Текст для копирования.</param>
        private void CopyToClipboard(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SetStatus("Нечего копировать — поле результата пусто.");
                return;
            }
            Clipboard.SetText(text);
            SetStatus("Скопировано в буфер обмена.");
        }
    }
}
