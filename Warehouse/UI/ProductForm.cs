using System;
using System.Windows.Forms;
using Warehouse.Models;
using Warehouse.Services;

namespace Warehouse
{
    public partial class ProductForm : Form
    {
        // Властивість для збереження новоствореного товару
        public Product CreatedProduct { get; private set; }
        // Посилання на існуючий товар, якщо форма відкрита для редагування
        private Product _productToEdit;

        // Викликається при СТВОРЕННІ НОВОГО товару (кнопка "Додати")
        public ProductForm()
        {
            InitializeComponent();
            this.Text = "Додати товар";
        }

        // Викликається при РЕДАГУВАННІ існуючого товару
        public ProductForm(Product product)
        {
            // Ініціалізує та створює всі візуальні компоненти (таблиці, кнопки), налаштовані в дизайнері
            InitializeComponent();
            this.Text = "Редагувати товар";
            _productToEdit = product;

            // Заповнюємо текстові поля даними товару, який передали для редагування
            textBoxName.Text = product.Name;
            textBoxUnit.Text = product.Unit;
            numPrice.Value = product.Price;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // БЛОК ВАЛІДАЦІЇ: Перевіряємо, чи користувач не залишив поля порожніми
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введіть назву товару!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Перериваємо виконання, якщо дані некоректні
            }

            if (string.IsNullOrWhiteSpace(textBoxUnit.Text))
            {
                MessageBox.Show("Введіть одиницю виміру (наприклад, шт., кг)!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Захист від введення від'ємної або нульової ціни
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Ціна товару має бути більшою за нуль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Якщо ми в режимі редагування — просто оновлюємо існуючий об'єкт
            if (_productToEdit != null)
            {
                // .Trim() видаляє зайві пробіли на початку та в кінці тексту, якщо юзер випадково їх поставив
                _productToEdit.Name = textBoxName.Text.Trim();
                _productToEdit.Name = textBoxName.Text.Trim();
                _productToEdit.Unit = textBoxUnit.Text.Trim();
                _productToEdit.Price = numPrice.Value;
            }
            // Якщо ми в режимі створення - створюємо новий екземпляр класу Product
            else
            {
                CreatedProduct = new Product
                {
                    Name = textBoxName.Text.Trim(),
                    Unit = textBoxUnit.Text.Trim(),
                    Price = numPrice.Value,
                    Quantity = 0, // Новий товар завжди має нульовий залишок до першої накладної
                    LastDeliveryDate = DateTime.MinValue
                };
            }

            // Сигнал для головної форми, що все пройшло успішно, і вікно можна закривати
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ProductForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Якщо натиснута клавіша F1
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show(
                    "Вікно заповнення даних про товар.\n\n" +
                    "• Назва — введіть повне найменування товару.\n" +
                    "• Одиниця вимірювання — наприклад: шт., кг, м, л.\n" +
                    "• Ціна — вкажіть вартість за одиницю (допускаються лише числа та кома для копійок).\n\n" +
                    "Гарячі клавіші:\n" +
                    "Enter — підтвердити та зберегти (ОК).\n" +
                    "Esc — скасувати та закрити вікно (Відміна).",
                    "Довідка: Дані товару",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}