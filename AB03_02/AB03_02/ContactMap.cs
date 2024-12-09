using CsvHelper.Configuration;

public class ContactMap : ClassMap<Contact>
{
    public ContactMap()
    {
        // CSV başlıklarını model özelliklerine eşliyoruz
        Map(m => m.Name).Name("Name");
        Map(m => m.Address).Name("Address");
        Map(m => m.PhoneNumber).Name("PhoneNumber");
        Map(m => m.Email).Name("Email");
    }
}
