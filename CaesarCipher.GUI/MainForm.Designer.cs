namespace CaesarCipher.GUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // ── Объявление элементов управления ──────────────────────────────────
            this.tabControl        = new System.Windows.Forms.TabControl();
            this.tabEncrypt        = new System.Windows.Forms.TabPage();
            this.tabDecrypt        = new System.Windows.Forms.TabPage();

            // Вкладка «Шифрование»
            this.lblInputEnc       = new System.Windows.Forms.Label();
            this.txtInputEnc       = new System.Windows.Forms.RichTextBox();
            this.lblShiftEnc       = new System.Windows.Forms.Label();
            this.nudShiftEnc       = new System.Windows.Forms.NumericUpDown();
            this.btnEncrypt        = new System.Windows.Forms.Button();
            this.lblOutputEnc      = new System.Windows.Forms.Label();
            this.txtOutputEnc      = new System.Windows.Forms.RichTextBox();
            this.btnCopyEnc        = new System.Windows.Forms.Button();
            this.btnClearEnc       = new System.Windows.Forms.Button();

            // Вкладка «Дешифрование»
            this.lblInputDec       = new System.Windows.Forms.Label();
            this.txtInputDec       = new System.Windows.Forms.RichTextBox();
            this.lblShiftDec       = new System.Windows.Forms.Label();
            this.nudShiftDec       = new System.Windows.Forms.NumericUpDown();
            this.btnDecrypt        = new System.Windows.Forms.Button();
            this.lblOutputDec      = new System.Windows.Forms.Label();
            this.txtOutputDec      = new System.Windows.Forms.RichTextBox();
            this.btnCopyDec        = new System.Windows.Forms.Button();
            this.btnClearDec       = new System.Windows.Forms.Button();

            this.statusStrip       = new System.Windows.Forms.StatusStrip();
            this.statusLabel       = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip           = new System.Windows.Forms.ToolTip(components);

            // ── Настройка NumericUpDown ───────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.nudShiftEnc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShiftDec)).BeginInit();

            this.SuspendLayout();

            // ── Форма ────────────────────────────────────────────────────────────
            this.Text            = "Шифр Цезаря";
            this.Size            = new System.Drawing.Size(700, 560);
            this.MinimumSize     = new System.Drawing.Size(600, 500);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font            = new System.Drawing.Font("Segoe UI", 9.5f);

            // ── TabControl ───────────────────────────────────────────────────────
            this.tabControl.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.TabIndex = 0;
            this.tabControl.Controls.Add(this.tabEncrypt);
            this.tabControl.Controls.Add(this.tabDecrypt);

            // ── Вкладка «Шифрование» ─────────────────────────────────────────────
            this.tabEncrypt.Text    = "  🔒  Шифрование  ";
            this.tabEncrypt.Padding = new System.Windows.Forms.Padding(10);
            BuildEncryptTab();

            // ── Вкладка «Дешифрование» ───────────────────────────────────────────
            this.tabDecrypt.Text    = "  🔓  Дешифрование  ";
            this.tabDecrypt.Padding = new System.Windows.Forms.Padding(10);
            BuildDecryptTab();

            // ── StatusStrip ──────────────────────────────────────────────────────
            this.statusLabel.Text = "Готово";
            this.statusStrip.Items.Add(this.statusLabel);
            this.statusStrip.SizingGrip = false;

            // ── Добавление на форму ──────────────────────────────────────────────
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);

            ((System.ComponentModel.ISupportInitialize)(this.nudShiftEnc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudShiftDec)).EndInit();
            this.ResumeLayout(false);
        }

        // ─── Построение вкладки «Шифрование» ─────────────────────────────────────

        private void BuildEncryptTab()
        {
            int pad = 14;

            // Метка + поле ввода
            this.lblInputEnc.Text     = "Исходный текст:";
            this.lblInputEnc.Location = new System.Drawing.Point(pad, pad);
            this.lblInputEnc.AutoSize = true;

            this.txtInputEnc.Location   = new System.Drawing.Point(pad, pad + 22);
            this.txtInputEnc.Size       = new System.Drawing.Size(640, 140);
            this.txtInputEnc.Anchor     = AnchorBoth;
            this.txtInputEnc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.toolTip.SetToolTip(this.txtInputEnc, "Введите текст для шифрования (русский или английский)");

            // Сдвиг
            this.lblShiftEnc.Text     = "Сдвиг:";
            this.lblShiftEnc.Location = new System.Drawing.Point(pad, pad + 178);
            this.lblShiftEnc.AutoSize = true;

            this.nudShiftEnc.Location  = new System.Drawing.Point(pad + 60, pad + 174);
            this.nudShiftEnc.Size      = new System.Drawing.Size(80, 26);
            this.nudShiftEnc.Minimum   = -10000;
            this.nudShiftEnc.Maximum   = 10000;
            this.nudShiftEnc.Value     = 3;
            this.toolTip.SetToolTip(this.nudShiftEnc, "Введите число позиций для сдвига (может быть отрицательным)");

            // Кнопка шифрования
            this.btnEncrypt.Text     = "Зашифровать →";
            this.btnEncrypt.Location = new System.Drawing.Point(pad + 160, pad + 170);
            this.btnEncrypt.Size     = new System.Drawing.Size(150, 34);
            this.btnEncrypt.Click   += BtnEncrypt_Click;
            this.toolTip.SetToolTip(this.btnEncrypt, "Зашифровать текст с выбранным сдвигом");

            // Кнопка очистки
            this.btnClearEnc.Text     = "Очистить";
            this.btnClearEnc.Location = new System.Drawing.Point(pad + 320, pad + 170);
            this.btnClearEnc.Size     = new System.Drawing.Size(100, 34);
            this.btnClearEnc.Click   += (s, e) => { txtInputEnc.Clear(); txtOutputEnc.Clear(); SetStatus("Очищено"); };

            // Метка + поле вывода
            this.lblOutputEnc.Text     = "Зашифрованный текст:";
            this.lblOutputEnc.Location = new System.Drawing.Point(pad, pad + 222);
            this.lblOutputEnc.AutoSize = true;

            this.txtOutputEnc.Location   = new System.Drawing.Point(pad, pad + 244);
            this.txtOutputEnc.Size       = new System.Drawing.Size(640, 140);
            this.txtOutputEnc.Anchor     = AnchorBoth;
            this.txtOutputEnc.ReadOnly   = true;
            this.txtOutputEnc.BackColor  = System.Drawing.Color.FromArgb(245, 250, 245);
            this.txtOutputEnc.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.toolTip.SetToolTip(this.txtOutputEnc, "Результат шифрования (только для чтения)");

            // Кнопка копирования
            this.btnCopyEnc.Text     = "Копировать";
            this.btnCopyEnc.Location = new System.Drawing.Point(pad, pad + 398);
            this.btnCopyEnc.Size     = new System.Drawing.Size(110, 30);
            this.btnCopyEnc.Click   += (s, e) => CopyToClipboard(txtOutputEnc.Text);
            this.toolTip.SetToolTip(this.btnCopyEnc, "Скопировать зашифрованный текст в буфер обмена");

            this.tabEncrypt.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblInputEnc, txtInputEnc, lblShiftEnc, nudShiftEnc,
                btnEncrypt, btnClearEnc, lblOutputEnc, txtOutputEnc, btnCopyEnc
            });
        }

        // ─── Построение вкладки «Дешифрование» ───────────────────────────────────

        private void BuildDecryptTab()
        {
            int pad = 14;

            this.lblInputDec.Text     = "Зашифрованный текст:";
            this.lblInputDec.Location = new System.Drawing.Point(pad, pad);
            this.lblInputDec.AutoSize = true;

            this.txtInputDec.Location   = new System.Drawing.Point(pad, pad + 22);
            this.txtInputDec.Size       = new System.Drawing.Size(640, 140);
            this.txtInputDec.Anchor     = AnchorBoth;
            this.txtInputDec.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.toolTip.SetToolTip(this.txtInputDec, "Введите зашифрованный текст для расшифровки");

            this.lblShiftDec.Text     = "Сдвиг:";
            this.lblShiftDec.Location = new System.Drawing.Point(pad, pad + 178);
            this.lblShiftDec.AutoSize = true;

            this.nudShiftDec.Location  = new System.Drawing.Point(pad + 60, pad + 174);
            this.nudShiftDec.Size      = new System.Drawing.Size(80, 26);
            this.nudShiftDec.Minimum   = -10000;
            this.nudShiftDec.Maximum   = 10000;
            this.nudShiftDec.Value     = 3;
            this.toolTip.SetToolTip(this.nudShiftDec, "Укажите тот же сдвиг, что использовался при шифровании");

            this.btnDecrypt.Text     = "Расшифровать →";
            this.btnDecrypt.Location = new System.Drawing.Point(pad + 160, pad + 170);
            this.btnDecrypt.Size     = new System.Drawing.Size(150, 34);
            this.btnDecrypt.Click   += BtnDecrypt_Click;
            this.toolTip.SetToolTip(this.btnDecrypt, "Расшифровать текст с выбранным сдвигом");

            this.btnClearDec.Text     = "Очистить";
            this.btnClearDec.Location = new System.Drawing.Point(pad + 320, pad + 170);
            this.btnClearDec.Size     = new System.Drawing.Size(100, 34);
            this.btnClearDec.Click   += (s, e) => { txtInputDec.Clear(); txtOutputDec.Clear(); SetStatus("Очищено"); };

            this.lblOutputDec.Text     = "Расшифрованный текст:";
            this.lblOutputDec.Location = new System.Drawing.Point(pad, pad + 222);
            this.lblOutputDec.AutoSize = true;

            this.txtOutputDec.Location   = new System.Drawing.Point(pad, pad + 244);
            this.txtOutputDec.Size       = new System.Drawing.Size(640, 140);
            this.txtOutputDec.Anchor     = AnchorBoth;
            this.txtOutputDec.ReadOnly   = true;
            this.txtOutputDec.BackColor  = System.Drawing.Color.FromArgb(245, 248, 255);
            this.txtOutputDec.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.toolTip.SetToolTip(this.txtOutputDec, "Результат дешифрования (только для чтения)");

            this.btnCopyDec.Text     = "Копировать";
            this.btnCopyDec.Location = new System.Drawing.Point(pad, pad + 398);
            this.btnCopyDec.Size     = new System.Drawing.Size(110, 30);
            this.btnCopyDec.Click   += (s, e) => CopyToClipboard(txtOutputDec.Text);
            this.toolTip.SetToolTip(this.btnCopyDec, "Скопировать расшифрованный текст в буфер обмена");

            this.tabDecrypt.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblInputDec, txtInputDec, lblShiftDec, nudShiftDec,
                btnDecrypt, btnClearDec, lblOutputDec, txtOutputDec, btnCopyDec
            });
        }

        // ─── Константа привязки ───────────────────────────────────────────────────
        private static readonly System.Windows.Forms.AnchorStyles AnchorBoth =
            System.Windows.Forms.AnchorStyles.Top |
            System.Windows.Forms.AnchorStyles.Left |
            System.Windows.Forms.AnchorStyles.Right;

        // ─── Поля ─────────────────────────────────────────────────────────────────
        private System.Windows.Forms.TabControl   tabControl;
        private System.Windows.Forms.TabPage      tabEncrypt;
        private System.Windows.Forms.TabPage      tabDecrypt;

        private System.Windows.Forms.Label        lblInputEnc;
        private System.Windows.Forms.RichTextBox  txtInputEnc;
        private System.Windows.Forms.Label        lblShiftEnc;
        private System.Windows.Forms.NumericUpDown nudShiftEnc;
        private System.Windows.Forms.Button       btnEncrypt;
        private System.Windows.Forms.Label        lblOutputEnc;
        private System.Windows.Forms.RichTextBox  txtOutputEnc;
        private System.Windows.Forms.Button       btnCopyEnc;
        private System.Windows.Forms.Button       btnClearEnc;

        private System.Windows.Forms.Label        lblInputDec;
        private System.Windows.Forms.RichTextBox  txtInputDec;
        private System.Windows.Forms.Label        lblShiftDec;
        private System.Windows.Forms.NumericUpDown nudShiftDec;
        private System.Windows.Forms.Button       btnDecrypt;
        private System.Windows.Forms.Label        lblOutputDec;
        private System.Windows.Forms.RichTextBox  txtOutputDec;
        private System.Windows.Forms.Button       btnCopyDec;
        private System.Windows.Forms.Button       btnClearDec;

        private System.Windows.Forms.StatusStrip           statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel  statusLabel;
        private System.Windows.Forms.ToolTip               toolTip;

        #endregion
    }
}
