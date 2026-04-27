using System;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class ProductForm : Form
    {
        // Специальное свойство, куда мы положим готовый товар, чтобы потом забрать его в главной форме
        public Product CreatedProduct { get; private set; }

        public ProductForm()
        {
            InitializeComponent();
        }

        // Этот метод срабатывает при нажатии на кнопку ОК
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Перевірка на дурня: не даємо зберегти пусті поля
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Введите название товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxUnit.Text))
            {
                MessageBox.Show("Введите единицу измерения (например, шт, кг)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Если проверки пройдены, собираем данные с формы в новый объект Product
            CreatedProduct = new Product
            {
                Name = textBoxName.Text.Trim(),
                Unit = textBoxUnit.Text.Trim(),
                Price = numPrice.Value,
                Quantity = 0, // Изначально товара на складе 0, он появится только после приходной накладной
                LastDeliveryDate = DateTime.MinValue
            };

            // Говорим системе, что всё прошло успешно, и закрываем окно
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
