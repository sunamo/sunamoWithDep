namespace SunamoCsv.Tests
{
    /*
     
Google's export format:
první řádek s daty má vyparsováno 21 položek ale mnoho z nich je ,
V hlavičce je 56 buňek
v excelu je hlavička addresse [35] ale v c# [21]
když to otevřu jako textový soubor mám zde také 34 čárek, tz. že knihovna parsuje dobře ale ten Google Export je nějaký divný

Outlook's export format:
v records je fields někdy 13, někdy 45
headers je 88

bude lepší použít vcf, u jakéhokoliv csv nejsou definovnány žádné standardy: https://stackoverflow.com/a/25767703/9327173
     */

    public class GoogleContactsExportManipulationWithoutMockTests
    {
        //[Fact]
        public
#if ASYNC
    async void
#else
    void
#endif
 ParseGoogleFormatGoogleContactsTest()
        {
            var f = @"D:\_Test\sunamo\SunamoCsv\contacts.csv";

            GoogleContactExportRow c = new GoogleContactExportRow();
            var g = c.GetType().GetProperties().Select(d => d.Name);

            var c2 =
#if ASYNC
    await
#endif
 TF.ReadAllText(f);

            CsvFile csv = new CsvFile();
            //CsvReader csvReader = new CsvReader();
            csv.Populate(true, c2);

            var gCount = g.Count();

            List<List<string>> ls = new List<List<string>>(gCount);
            int i = 0;
            foreach (var item in g)
            {
                var ls2 = LinearHelper.GetStringListFromTo(0, gCount - 1);
                var li = CA.ToList<int>(ls2);

                var entries = csv.Strings(0);
                ls.Add(entries);
            }

            int d2 = 0;
        }

        //[Fact]
        public
#if ASYNC
    async void
#else
    void
#endif
 ParseOutlookFormatGoogleContactsTest()
        {
            var f = @"D:\_Test\sunamo\SunamoCsv\contacts_Outlook.csv";

            GoogleContactExportRow c = new GoogleContactExportRow();
            var g = c.GetType().GetProperties().Select(d2 => d2.Name);

            var c2 =
#if ASYNC
    await
#endif
 TF.ReadAllText(f);

            CsvFile csv = new CsvFile();
            //CsvReader csvReader = new CsvReader();
            csv.Populate(true, c2);

            var gCount = g.Count();

            List<List<string>> ls = new List<List<string>>(gCount);
            int i = 0;
            foreach (var item in g)
            {
                var ls2 = LinearHelper.GetStringListFromTo(0, gCount - 1);
                var li = CA.ToList<int>(ls2);

                var entries = csv.Strings(0);
                ls.Add(entries);
            }

            int d = 0;
        }
    }
}
