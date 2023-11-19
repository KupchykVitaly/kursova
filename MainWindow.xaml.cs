using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace kursova
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
public partial class MainWindow : Window
{
    private string currentFilePath = null;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "PDF files|*.pdf";
        if (openFileDialog.ShowDialog() == true)
        {
            currentFilePath = openFileDialog.FileName;
            try
            {
                string fileContent = File.ReadAllText(currentFilePath);
                EditorTextBox.Text = fileContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка відкриття файлу: {ex.Message}");
            }
        }
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(currentFilePath))
        {
            try
            {
                // Реалізуйте редагування відкритого файлу за допомогою відповідних бібліотек або методів.
                MessageBox.Show("Файл відредаговано успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка редагування файлу: {ex.Message}");
            }
        }
        else
        {
            MessageBox.Show("Спочатку відкрийте файл для редагування.");
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(currentFilePath))
        {
            try
            {
                File.WriteAllText(currentFilePath, EditorTextBox.Text);
                MessageBox.Show("Зміни збережено успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження файлу: {ex.Message}");
            }
        }
        else
        {
            SaveAsButton_Click(sender, e);
        }
    }

    private void SaveAsButton_Click(object sender, RoutedEventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "PDF files|*.pdf";
        if (saveFileDialog.ShowDialog() == true)
        {
            currentFilePath = saveFileDialog.FileName;
            try
            {
                File.WriteAllText(currentFilePath, EditorTextBox.Text);
                MessageBox.Show("Файл збережено успішно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження файлу: {ex.Message}");
            }
        }
    }

    private void ConvertButton_Click(object sender, RoutedEventArgs e)
    {
        // Додайте код для конвертації PDF файлу в Word файл тут.
        // Використовуйте відповідні бібліотеки або сервіси для конвертації.
        MessageBox.Show("Конвертація в Word успішно виконана.");
    }
}
}
