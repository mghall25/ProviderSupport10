using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProviderSupport.Models;

namespace ProviderSupport.DAL
{
    public class ProviderSupportInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProviderSupportContext>
    {   // recreates data when needed - TESTING ONLY
        protected override void Seed(ProviderSupportContext context)
        {
            var providers = new List<Provider>
            {
            new Provider{FirstName="Carson",LastName="Alexander",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Meredith",LastName="Alonso",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-02-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Arturo",LastName="Anand",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-04-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Gytis",LastName="Barzdukas",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-05-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Yan",LastName="Li",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-06-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Peggy",LastName="Justice",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-03-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Laura",LastName="Norman",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")},
            new Provider{FirstName="Nino",LastName="Olivetto",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-12-01"),PayRate=10.00,CprExpDate=DateTime.Parse("2018-01-01")}
            };

            providers.ForEach(s => context.Providers.Add(s));
            context.SaveChanges();

            var clients = new List<Client>
            {
            new Client{PrimeNo="EW1234563",FirstName="Fred",LastName="Alexander",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=2},
            new Client{PrimeNo="SA4567891",FirstName="Fanny",LastName="Banks",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=2},
            new Client{PrimeNo="YH45678944",FirstName="Myrtle",LastName="Curry",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=2},
            new Client{PrimeNo="TR45645644",FirstName="Bud",LastName="Drake",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=2}
            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
            new Transaction{TimeStamp=new DateTime(2018,04,01,6,30,0),ProviderID=1,ClientID=3,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,02,6,30,0),ProviderID=2,ClientID=3,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,03,6,30,0),ProviderID=2,ClientID=2,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,04,6,30,0),ProviderID=4,ClientID=1,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=3,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,05,6,30,0),ProviderID=5,ClientID=3,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,06,6,30,0),ProviderID=6,ClientID=2,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,07,6,30,0),ProviderID=7,ClientID=2,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"},
            new Transaction{TimeStamp=new DateTime(2018,04,08,6,30,0),ProviderID=3,ClientID=1,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test"}
            };
            transactions.ForEach(s => context.Transactions.Add(s));
            context.SaveChanges();
        }
    }
}