using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;

namespace AB03_02
{
    public partial class MainWindow : Window
    {
        private CsvService csvService = new CsvService(); // CSV işlemleri için servisi oluştur
        private List<Contact> contacts; // CSV verileri burada tutulacak

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>(); // Constructor içinde başlatma
        }

        // Open CSV düğmesi tıklandığında dosya açılır
        private void OpenCsvButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                // CSV dosyasını oku
                contacts = csvService.ReadCsv(openFileDialog.FileName);
                dataGrid.ItemsSource = contacts;

                // CSV başlıklarını ComboBox'a ekleyelim
                var headers = new List<string> { "Name", "Address", "PhoneNumber", "Email" }; // CSV dosyasındaki başlıklar
                columnComboBox.ItemsSource = headers;
            }
        }

        // Select Butonu Tıklama Olayı
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            // DataGrid'deki seçilen satırı alıyoruz
            var selectedContact = dataGrid.SelectedItem as Contact;

            // Eğer bir satır seçildiyse, seçilen satırdaki veriyi gösterebiliriz
            if (selectedContact != null)
            {
                // Seçilen satırdaki bilgileri MessageBox ile gösteriyoruz
                MessageBox.Show($"Selected Contact: {selectedContact.Name}, {selectedContact.Address}");
            }
            else
            {
                // Eğer hiç bir satır seçilmemişse, kullanıcıyı uyarıyoruz
                MessageBox.Show("No contact selected.");
            }
        }


        // Save CSV düğmesi tıklandığında dosya kaydedilir
        private void SaveCsvButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Veriyi eşlemeye göre kaydet
                csvService.WriteCsv(saveFileDialog.FileName, contacts);
            }
        }
    }
}
