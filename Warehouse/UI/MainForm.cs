using System;
using System.Windows.Forms;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse
{
    public partial class MainForm : Form
    {
        // Створюємо наш склад
        private Warehouse.Services.Warehouse myWarehouse = new Warehouse.Services.Warehouse();

        public MainForm()
        {
            InitializeComponent();
            myWarehouse.LoadData(); // Зчитуємо дані з файлу
            UpdateGrid();           // Показуємо їх у таблиці
        }

        // Метод оновлення таблиці
        private void UpdateGrid()
        {
            // Робимо свіжу копію списку (ToArray), щоб DataGridView не сходив з розуму 
            // при спробі зчитати дані, які в цей момент змінюються на складі
            var safeData = myWarehouse.Inventory.ToArray();

            dataGridView1.DataSource = safeData;

            UpdateStatistics(); // ОСЬ ЦЕЙ РЯДОК змусить програму перерахувати цифри і змінити текст!
        }

        // Кнопка додавання нового товару в каталог
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ProductForm form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (myWarehouse.Inventory.Any(p => p.Name.ToLower() == form.CreatedProduct.Name.ToLower()))
                {
                    MessageBox.Show("Товар з такою назвою вже існує на складі!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                myWarehouse.Inventory.Add(form.CreatedProduct);
                UpdateGrid();
            }
        }

        // НОВА КНОПКА: Оформлення накладної
        private void btnCreateWaybill_Click(object sender, EventArgs e)
        {
            // Перевірка: чи є взагалі товари в каталозі
            if (myWarehouse.Inventory.Count == 0)
            {
                MessageBox.Show("Спочатку додайте хоча б один товар у каталог!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Передаємо інвентар у конструктор форми накладної
            WaybillForm form = new WaybillForm(myWarehouse.Inventory);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Перевіряємо тип накладної і викликаємо потрібний метод зі складу
                    if (form.CreatedWaybill.IsIncoming)
                    {
                        myWarehouse.RegisterIncoming(form.CreatedWaybill);
                    }
                    else
                    {
                        myWarehouse.RegisterOutgoing(form.CreatedWaybill);
                    }

                    UpdateGrid(); // Оновлюємо таблицю, щоб побачити нові залишки

                    MessageBox.Show("Накладну успішно проведено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Тут ми ловимо throw new Exception("Недостатньо товару...")
                    MessageBox.Show(ex.Message, "Помилка проведення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи взагалі вибрано якийсь рядок у таблиці
            if (dataGridView1.CurrentRow != null)
            {
                // Дістаємо товар з виділеного рядка (там, де стоїть чорна стрілочка)
                Product selectedProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;

                // Виводимо вікно з підтвердженням (змінили кнопки на ОК/Отмена)
                DialogResult result = MessageBox.Show(
                    $"Ви дійсно хочете видалити товар '{selectedProduct.Name}' з каталогу?",
                    "Підтвердження видалення",
                    MessageBoxButtons.OKCancel, // <--- Змінили тут
                    MessageBoxIcon.Question);

                // Якщо користувач натиснув "ОК" або клавішу Enter
                if (result == DialogResult.OK) // <--- Змінили тут
                {
                    myWarehouse.Inventory.Remove(selectedProduct); // Видаляємо товар зі складу
                    UpdateGrid(); // Оновлюємо таблицю, щоб рядок зник з екрана
                }
            }
            else
            {
                // Якщо таблиця порожня або користувач клікнув кудись не туди
                MessageBox.Show("Будь ласка, оберіть товар для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myWarehouse.SaveData(); // Зберігаємо дані перед тим, як вікно зникне
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(myWarehouse.Waybills);
            historyForm.ShowDialog();
        }

        private void btnResetBase_Click(object sender, EventArgs e)
        {
            // Виводимо вікно-попередження із захистом від випадкового натискання Enter
            DialogResult result = MessageBox.Show(
                "Ви впевнені, що хочете ПОВНІСТЮ очистити склад і видалити всі накладні? Цю дію неможливо скасувати!",
                "Критична дія",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2 // Фокус за замовчуванням стоїть на кнопці "Отмена"
            );

            // Якщо користувач свідомо натиснув ОК
            if (result == DialogResult.OK)
            {
                // Очищаємо списки в оперативній пам'яті
                myWarehouse.Inventory.Clear();

                myWarehouse.Waybills.Clear();

                // Оновлюємо інтерфейс
                UpdateGrid(); // Таблиця стане порожньою
                UpdateStatistics(); // Лейбл внизу покаже нулі
                myWarehouse.SaveData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.ToLower();
            var filteredList = myWarehouse.Inventory.Where(p => p.Name.ToLower().Contains(query)).ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = filteredList;
        }

        private void btnEditProduct_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Product selectedProduct = (Product)dataGridView1.CurrentRow.DataBoundItem;
                ProductForm form = new ProductForm(selectedProduct);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateGrid();
                }
            }
            else
            {
                MessageBox.Show("Оберіть товар для редагування!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Product p && p.Quantity == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            myWarehouse.SaveData();
            MessageBox.Show("Збережено!");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Вказуємо шлях до нашої майбутньої папки (вона буде поруч з .exe)
            string backupFolder = Path.Combine(Application.StartupPath, "Backups");

            // 2. Якщо такої папки ще немає — створюємо її
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            SaveFileDialog sfd = new SaveFileDialog();
            // 3. Наказуємо вікну відкриватися рівно в цій папці
            sfd.InitialDirectory = backupFolder;
            sfd.Filter = "JSON files (*.json)|*.json";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                myWarehouse.SaveData(sfd.FileName);
                MessageBox.Show("Дані успішно збережено в окрему папку!");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myWarehouse.LoadData();
            UpdateGrid(); 
            MessageBox.Show("Завантажено!");
        }

        private void openAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string backupFolder = Path.Combine(Application.StartupPath, "Backups");
            if (!Directory.Exists(backupFolder))
            {
                Directory.CreateDirectory(backupFolder);
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = backupFolder;
            ofd.Filter = "JSON files (*.json)|*.json";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                myWarehouse.LoadData(ofd.FileName);
                UpdateGrid(); 
                MessageBox.Show("Дані успішно завантажено!");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Програма управління складом \n\n" +
                "Save — швидке збереження.\n" +
                "Save as — копія у Backups.\n" +
                "Open as — завантаження копії.",
                "Довідка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Залізобетонне перехоплення Delete для таблиці
            if (keyData == Keys.Delete && dataGridView1.SelectedRows.Count > 0)
            {
                btnDeleteProduct_Click(this, EventArgs.Empty);
                return true; // Кажемо системі "ми вже обробили цю клавішу, забудь про неї"
            }

            // Твою довідку на F1 теж краще перенести сюди, щоб працювала завжди
            if (keyData == Keys.F1)
            {
                MessageBox.Show(
                    "Головне вікно керування складом.\n\n" +
                    "• Пошук — введіть текст для швидкого фільтрування.\n" +
                    "• Таблиця — показує стан складу (червоним виділено товари, яких немає в наявності).\n" +
                    "• Оформити накладну — проведення приходу або витрати товару.\n" +
                    "• Історія операцій — журнал усіх складських рухів.\n\n" +
                    "Гарячі клавіші:\n" +
                    "F1 — ця довідка.\n" +
                    "Delete — швидке видалення виділеного товару з таблиці.",
                    "Довідка: Головне вікно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return true;
            }
            // --- КЕРУВАННЯ ТАБЛИЦЕЮ У ВСІ 4 СТОРОНИ ---

            bool isSearchFocused = (this.ActiveControl != null && this.ActiveControl.Name == "txtSearch");

            // Якщо натиснута будь-яка з чотирьох стрілок
            if (keyData == Keys.Up || keyData == Keys.Down || keyData == Keys.Left || keyData == Keys.Right)
            {
                // Якщо ми в полі пошуку і тиснемо Вліво/Вправо - віддаємо керування системі (щоб бігав курсор по тексту)
                if (isSearchFocused && (keyData == Keys.Left || keyData == Keys.Right))
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

                // Якщо в таблиці є дані і є хоча б одна активна клітинка - рухаємо її
                if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentCell != null)
                {
                    int currRow = dataGridView1.CurrentCell.RowIndex;
                    int currCol = dataGridView1.CurrentCell.ColumnIndex;

                    // Вираховуємо нові координати, не даючи вийти за межі таблиці
                    if (keyData == Keys.Up && currRow > 0) currRow--;
                    if (keyData == Keys.Down && currRow < dataGridView1.Rows.Count - 1) currRow++;
                    if (keyData == Keys.Left && currCol > 0) currCol--;
                    if (keyData == Keys.Right && currCol < dataGridView1.ColumnCount - 1) currCol++;

                    // Переміщуємо фокус на нову клітинку
                    dataGridView1.CurrentCell = dataGridView1.Rows[currRow].Cells[currCol];
                    return true; // Блокуємо стандартну поведінку стрілок
                }
            }

            // Усі інші клавіші віддаємо системі (Tab, Enter, літери тощо)
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdateStatistics()
        {
            // Рахуємо унікальні позиції (рядки)
            int totalItems = myWarehouse.Inventory.Count;

            // Рахуємо загальну кількість усіх фізичних одиниць товару та їхню вартість
            decimal totalValue = 0;
            int totalQuantity = 0;

            foreach (var item in myWarehouse.Inventory)
            {
                totalQuantity += item.Quantity;
                totalValue += (decimal)(item.Quantity * item.Price); // Рахуємо як Ціна * Кількість
            }

            // Виводимо стату в Label
            lblStatistics.Text = $"Всього найменувань: {totalItems} | Загальна кількість одиниць: {totalQuantity} | Вартість складу: {totalValue} грн";
        }

        // Ця змінна запам'ятовує, в який бік ми сортували минулого разу (зростання чи спадання)
        private bool sortAscending = true;

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Дістаємо ім'я властивості, до якої прив'язана колонка, по якій клікнули
            string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            // Сортуємо наш основний список залежно від колонки за допомогою магії LINQ
            switch (columnName)
            {
                case "Name":
                    myWarehouse.Inventory = sortAscending
                        ? myWarehouse.Inventory.OrderBy(x => x.Name).ToList()
                        : myWarehouse.Inventory.OrderByDescending(x => x.Name).ToList();
                    break;
                case "Price":
                    myWarehouse.Inventory = sortAscending
                        ? myWarehouse.Inventory.OrderBy(x => x.Price).ToList()
                        : myWarehouse.Inventory.OrderByDescending(x => x.Price).ToList();
                    break;
                case "Unit":
                    myWarehouse.Inventory = sortAscending
                        ? myWarehouse.Inventory.OrderBy(x => x.Unit).ToList()
                        : myWarehouse.Inventory.OrderByDescending(x => x.Unit).ToList();
                    break;
                case "Quantity":
                    myWarehouse.Inventory = sortAscending
                        ? myWarehouse.Inventory.OrderBy(x => x.Quantity).ToList()
                        : myWarehouse.Inventory.OrderByDescending(x => x.Quantity).ToList();
                    break;
                case "LastDeliveryDate":
                    myWarehouse.Inventory = sortAscending
                        ? myWarehouse.Inventory.OrderBy(x => x.LastDeliveryDate).ToList()
                        : myWarehouse.Inventory.OrderByDescending(x => x.LastDeliveryDate).ToList();
                    break;
            }

            // Інвертуємо напрямок для наступного кліку
            sortAscending = !sortAscending;

            // Оновлюємо таблицю, щоб показати відсортований список
            UpdateGrid();
        }
    }
}