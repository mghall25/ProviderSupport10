namespace ProviderSupport.Migrations
{
    using ProviderSupport.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProviderSupport.DAL.ProviderSupportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // runs every time update-database command is issued -- adds if not present, updates if present
        // NOTE: *** MUST FIX - ASSUMING UNIQUE LAST NAMES see: https://blogs.msdn.microsoft.com/rickandy/2013/02/12/seeding-and-debugging-entity-framework-ef-dbs/
        protected override void Seed(ProviderSupport.DAL.ProviderSupportContext context)
        {
            var serviceTypeEmpls = new List<ServiceTypeEmpl>
            {
                new ServiceTypeEmpl { ServiceTypeEmplID = 1, DisplayOrder=1, Desc = "Discovery", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=false },
                new ServiceTypeEmpl { ServiceTypeEmplID = 2, DisplayOrder=2, Desc = "Job Coaching - Initial", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=true, VrService=false },
                new ServiceTypeEmpl { ServiceTypeEmplID = 3, DisplayOrder=3, Desc = "Job Coaching - Ongoing", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=true, VrService=false },
                new ServiceTypeEmpl { ServiceTypeEmplID = 4, DisplayOrder=4, Desc = "Job Coaching - Maintenance", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=true, VrService=false },
                new ServiceTypeEmpl { ServiceTypeEmplID = 5, DisplayOrder=5, Desc = "Referral", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 6, DisplayOrder=6, Desc = "Portfolio", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 7, DisplayOrder=7, Desc = "Strategic Report", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 8, DisplayOrder=9, Desc = "Development", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 9, DisplayOrder=10, Desc = "Placement", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 10, DisplayOrder=11, Desc = "Coaching Plan", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 11, DisplayOrder=11, Desc = "VR Coaching (pd per hr)", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=true, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 12, DisplayOrder=13, Desc = "Retention", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 13, DisplayOrder=14, Desc = "Direct Placement (@ day 30)", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 14, DisplayOrder=15, Desc = "Direct Placement Retention (@ day 90)", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true },
                new ServiceTypeEmpl { ServiceTypeEmplID = 15, DisplayOrder=8, Desc = "Strategic Review", DescLong ="OR955269 Attendant Care, Home or Community", MultiDateEntry=false, VrService=true }
                };
            serviceTypeEmpls.ForEach(s => context.ServiceTypeEmpls.AddOrUpdate(p => p.ServiceTypeEmplID, s));
            context.SaveChanges();

            var serviceTypes = new List<ServiceType>
            {
                new ServiceType { ServiceTypeID = 1, Desc = "Hours", DescLong ="OR955269 Attendant Care, Home or Community" },
                new ServiceType { ServiceTypeID = 2, Desc = "Relief Care", DescLong ="OR955079 Relief Care, Daily" },
                new ServiceType { ServiceTypeID = 3, Desc = "Transportation", DescLong ="OR950049 Service-Related Transportation" },
                new ServiceType { ServiceTypeID = 4, Desc = "Employment", DescLong ="Employment" },
                new ServiceType { ServiceTypeID = 5, Desc = "DSA", DescLong ="OR955429 Day Support Activity, non-work" },
                new ServiceType { ServiceTypeID = 6, Desc = "Administrative", DescLong ="Administrative" },
                new ServiceType { ServiceTypeID = 7, Desc = "Provider Training (in-home care)", DescLong ="Provider Training (in-home care)" },
                new ServiceType { ServiceTypeID = 8, Desc = "Provider Training (employment)", DescLong ="Provider Training (employment)" },
                new ServiceType { ServiceTypeID = 9, Desc = "Employee Development Training", DescLong ="Employee Development Training" },
                new ServiceType { ServiceTypeID = 10, Desc = "Sick Leave", DescLong ="Sick Leave" },
                new ServiceType { ServiceTypeID = 11, Desc = "Between-Client Mileage (or Other Unreimbursed)", DescLong ="Between-Client Mileage or Other Unreimbursed Mileage" },
                new ServiceType { ServiceTypeID = 12, Desc = "Expenses (Reimbursable)", DescLong ="Expenses (Reimbursable)" }
                };
            serviceTypes.ForEach(s => context.ServiceTypes.AddOrUpdate(p => p.ServiceTypeID, s));
            context.SaveChanges();

            var billToOrgs = new List<BillToOrg>
            {
                new BillToOrg { Name = "Billing Org 1", Type = 1, PhoneNum = "123.456.7890", Email = "dsf@msb.com",Address1="123 Main St.", Address2="Apt 123", Address3="Portland, OR 45678" },
                new BillToOrg { Name = "Billing Org 2", Type = 2, PhoneNum = "123.456.7890", Email = "dsf@msb.com",Address1="123 Main St.", Address2="Apt 123", Address3="Portland, OR 45678" },
                new BillToOrg { Name = "Billing Org 3", Type = 3, PhoneNum = "123.456.7890", Email = "dsf@msb.com",Address1="123 Main St.", Address2="Apt 123", Address3="Portland, OR 45678" }
            };
            billToOrgs.ForEach(s => context.BillToOrgs.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var counsPas = new List<CounsPa>
            {
                new CounsPa { Name = "Barbara Comfort", PhoneNum = "350.000.1239", Email ="dft@gfd.com", BillToOrgID = billToOrgs.Single( i => i.Name == "Billing Org 1").BillToOrgID },
                new CounsPa { Name = "Henry Marks", PhoneNum = "350.000.1239", Email ="dft@gfd.com", BillToOrgID = billToOrgs.Single( i => i.Name == "Billing Org 3").BillToOrgID },
                new CounsPa { Name = "Stephanie Hanks", PhoneNum = "350.000.1239", Email ="dft@gfd.com", BillToOrgID = billToOrgs.Single( i => i.Name == "Billing Org 2").BillToOrgID }
            };
            counsPas.ForEach(s => context.CounsPas.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

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
            providers.ForEach(s => context.Providers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var clients = new List<Client>
            {
            new Client{PrimeNo="EW1234563",FirstName="Fred",LastName="Alexander",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=counsPas.Single(s=>s.Name == "Barbara Comfort").CounsPaID},
            new Client{PrimeNo="SA4567891",FirstName="Fanny",LastName="Banks",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=counsPas.Single(s=>s.Name == "Henry Marks").CounsPaID},
            new Client{PrimeNo="YH45678944",FirstName="Myrtle",LastName="Curry",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=counsPas.Single(s=>s.Name == "Barbara Comfort").CounsPaID},
            new Client{PrimeNo="TR45645644",FirstName="Bud",LastName="Drake",PhoneNum="503.332.4569",Email="testemail@msn.com",BirthDate=DateTime.Parse("2005-09-01"),EmergencyName="Ava Frederickson",EmergencyEmail="ava@test.com",EmergencyPhone="456.789.1231",CounsPaID=counsPas.Single(s=>s.Name == "Henry Marks").CounsPaID}
            };
            clients.ForEach(s => context.Clients.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var transactions = new List<Transaction>
            {
            new Transaction{ProviderID=1,ClientID=4,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=2,ClientID=5,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=2,ClientID=6,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=4,ClientID=7,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=3,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=5,ClientID=4,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=6,ClientID=5,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=7,ClientID=6,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"},
            new Transaction{ProviderID=3,ClientID=7,DateWorked=DateTime.Parse("4/30/2018"),ServiceTypeID=1,ServiceTypeEmplID=1,TimeIn=new DateTime(2001,01,01,8,00,0),TimeOut=new DateTime(2001,01,01,17,00,0),ServiceDesc="Played Baseball.",ProgressNote="Test",TravelPurpose="Test",ExpenseVendor="Test",ExpensePurpose="Test"}
            };
            

            foreach (Transaction e in transactions)
            {
                var transactionInDataBase = context.Transactions.Where(
                    s =>
                         s.Provider.ProviderID == e.ProviderID &&
                         s.Client.ClientID == e.Client.ClientID).SingleOrDefault();
                if (transactionInDataBase == null)
                {
                    context.Transactions.Add(e);
                }
            }
            context.SaveChanges();           

        }
    }
}