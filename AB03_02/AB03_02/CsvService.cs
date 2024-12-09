using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class CsvService
{
    // CSV dosyasını oku ve Contact listesine dönüştür
    public List<Contact> ReadCsv(string filePath)
    {
        var contacts = new List<Contact>();

        // CsvConfiguration kullanarak konfigürasyonu oluşturuyoruz
        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,  // Başlık satırının olduğunu belirtiyoruz
            Delimiter = ",", // CSV'nin virgülle ayrıldığını belirtiyoruz
        };

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, csvConfig))
        {
            // CSV başlıklarını doğru şekilde eşlemek için ClassMap kullanıyoruz
            csv.Context.RegisterClassMap<ContactMap>();

            // Doğrudan Contact nesnelerine dönüştürüyoruz
            contacts = csv.GetRecords<Contact>().ToList(); // GetRecords<Contact>() ile CSV'yi doğrudan Contact nesnelerine dönüştürüyoruz
        }

        return contacts;
    }

    // Contact listesini CSV dosyasına yaz
    public void WriteCsv(string filePath, List<Contact> contacts)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            // Verileri CSV dosyasına yazıyoruz
            foreach (var contact in contacts)
            {
                csv.WriteField(contact.Name);
                csv.WriteField(contact.Address);
                csv.WriteField(contact.PhoneNumber);
                csv.WriteField(contact.Email);
                csv.NextRecord();
            }
        }
    }
}
