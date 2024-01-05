namespace SunamoShared.Indexing;
//using sunamo.Enums;
//using sunamo.Essential;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//namespace desktop
//{
//    public class FileNameWithDateTime
//    {
//static Type type = typeof(FileNameWithDateTime);
//        public DateTime dt = DateTime.MinValue;
//        public string name = "";
//        /// <summary>
//        /// Pokud bude vyplněná, nebude se používat čas, který i tak bude uložen v proměnné dt
//        /// </summary>
//        public int? serie = null;
//        public string fnwoe = "";
//        public int SerieValue
//        {
//            get
//            {
//                return serie.Value;
//            }
//        }
//        string displayText = null;
//        public FileNameWithDateTime(string displayText)
//        {
//            this.displayText = displayText;
//        }
//        public override string ToString()
//        {
//            return displayText;
//        }
//    }
//    public class DateTimeFileIndex
//    {
//        public event VoidString RaisedException;
//        string folder = null;
//        string ext = null;
//        //SunamoDictionary<string, DateTime> dict = new SunamoDictionary<string, DateTime>();
//        public List<FileNameWithDateTime> files = new List<FileNameWithDateTime>();
//        FileEntriesDuplicitiesStrategy ds = FileEntriesDuplicitiesStrategy.Time;
//        static Langs l
//        {
//            get
//            {
//                return ThisApp.l;
//            }
//        }
//        public DateTimeFileIndex(AppFolders af, string ext, FileEntriesDuplicitiesStrategy ds, bool addPostfix)
//        {
//            this.ds = ds;
//            this.folder = AppData.ci.GetFolder(af);
//            this.ext = ext;
//            string mask = "????_??_??_";
//            if (ds == FileEntriesDuplicitiesStrategy.Serie)
//            {
//                mask += "S_?*_";
//            }
//            else if (ds == FileEntriesDuplicitiesStrategy.Time)
//            {
//                mask += "??_??_";
//            }
//            else
//            {
//                ThrowEx.Custom("Nepodporovaná strategie ukládání.");
//            }
//            mask += AllStrings.asterisk;
//            #region MyRegion
//            List<string> f = FS.GetFiles(folder, AllStrings.asterisk + ext, SearchOption.TopDirectoryOnly);
//            foreach (var item in f)
//            {
//                string fnwoe = Path.GetFileNameWithoutExtension(item);
//                if (SH.MatchWildcard(fnwoe, mask))
//                {
//                    DateTime? date = DateTime.MinValue;
//                    string postfix = "";
//                    int? serie = null;
//                    if (ds == FileEntriesDuplicitiesStrategy.Serie)
//                    {
//                        date = DTHelper.FileNameToDateWithSeriePostfix(fnwoe, out serie, out postfix);
//                    }
//                    else if (ds == FileEntriesDuplicitiesStrategy.Time)
//                    {
//                        date = DTHelper.FileNameToDateTimePostfix(fnwoe, true, out postfix);
//                    }
//                    else
//                    {
//                    }
//                    if (date != null)
//                    {
//                        string displayText = "";
//                        displayText = GetDisplayText(date.Value, serie, addPostfix ? postfix : "");
//                        files.Add(CreateObjectFileNameWithDateTime(displayText, date.Value, serie, postfix, fnwoe));
//                    }
//                }
//            }
//            #endregion
//            if (ds == FileEntriesDuplicitiesStrategy.Serie)
//            {
//                files.Sort(new CompareFileNameWithDateTimeBySerie().Desc);
//            }
//            files.Sort(new CompareFileNameWithDateTimeByDateTime().Desc);
//        }
//        private static string GetDisplayText(DateTime date, int? serie, string postfix)
//        {
//            if (postfix != "")
//            {
//                postfix = AllStrings.space + postfix;
//            }
//            string displayText;
//            if (serie == null)
//            {
//                displayText = DTHelper.DateTimeToString(date, l, DateTime.MinValue) + postfix;
//            }
//            else
//            {
//                int ser = serie.Value;
//                string addSer = "";
//                if (ser != 0)
//                {
//                    addSer = " (" + ser + AllStrings.rb;
//                }
//                displayText = DTHelper.DateToString(date, l) + addSer + postfix;
//            }
//            return displayText;
//        }
//        private FileNameWithDateTime CreateObjectFileNameWithDateTime(string displayText, DateTime date, int? serie, string postfix, string fnwoe)
//        {
//            FileNameWithDateTime add = new FileNameWithDateTime(displayText);
//            add.dt = date;
//            add.serie = serie;
//            add.name = postfix;
//            add.fnwoe = fnwoe;
//            return add;
//        }
//        public void DeleteFile(FileNameWithDateTime o)
//        {
//            try
//            {
//                string t = GetFullPath(o);
//                File.Delete(t);
//                files.Remove(o);
//            }
//            catch (Exception ex)
//            {
//                RaisedException("Soubor se nepodařilo smazat, ale dokud program neresetujete se již nebude zobrazovat.");
//            }
//        }
//        public string GetFullPath(FileNameWithDateTime o)
//        {
//            return Path.Combine(folder, o.fnwoe + ext);
//        }
//        /// <summary>
//        /// Zapíše soubor FileEntriesDuplicitiesStrategy se strategií specifikovanou v konstruktoru
//        /// Nepřidává do kolekce files, vrací objekt
//        /// </summary>
//        /// <param name="dt"></param>
//        /// <param name="name"></param>
//        public FileNameWithDateTime SaveFileWithDate(string name, string content)
//        {
//            DateTime dt = DateTime.Now;
//            DateTime today = DateTime.Today;
//            string fnwoe = "";
//            int? max = null;
//            if (ds == FileEntriesDuplicitiesStrategy.Time)
//            {
//                fnwoe = ConvertDateTimeToFileNamePostfix.ToConvention(name, dt, true);
//            }
//            else if (ds == FileEntriesDuplicitiesStrategy.Serie)
//            {
//                IList<int?> ml = files.Where(u => u.dt == today).Select(s => s.serie);
//                if (ml.Count() != 0)
//                {
//                    max = ml.Max() + 1;
//                }
//                if (!max.HasValue)
//                {
//                    max = 1;
//                }
//                fnwoe = DTHelper.DateTimeToFileName(dt, false) + "_S_" + max.Value + AllStrings.lowbar + name;
//            }
//            else
//            {
//                // Zbytečné, kontroluje se již v konstruktoru
//            }
//            string path = Path.Combine(folder, fnwoe + ext);
//            TF.SaveFile(content, path);
//            return CreateObjectFileNameWithDateTime(GetDisplayText(dt, max, name), dt, max, name, fnwoe);
//        }
//    }
//    public class CompareFileNameWithDateTimeBySerie : ISunamoComparer<FileNameWithDateTime>
//    {
//        public int Desc(FileNameWithDateTime x, FileNameWithDateTime y)
//        {
//            return x.SerieValue.CompareTo(y.SerieValue) * -1;
//        }
//        public int Asc(FileNameWithDateTime x, FileNameWithDateTime y)
//        {
//            return x.SerieValue.CompareTo(y.SerieValue);
//        }
//    }
//    public class CompareFileNameWithDateTimeByDateTime : ISunamoComparer<FileNameWithDateTime>
//    {
//        public int Desc(FileNameWithDateTime x, FileNameWithDateTime y)
//        {
//            return x.dt.CompareTo(y.dt) * -1;
//        }
//        public int Asc(FileNameWithDateTime x, FileNameWithDateTime y)
//        {
//            return x.dt.CompareTo(y.dt);
//        }
//    }
//}
