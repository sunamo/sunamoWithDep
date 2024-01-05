using SunamoValues;
using SunamoValues.Values;

namespace SunamoCl;

// Musí být v NS, viz. C:\repos\_\Projects\sunamo\cmd\Helpers\CLConsoleSunExc.cs



public partial class CL
{
    private static volatile bool exit;

    private static readonly string charOfHeader = AllStringsSE.asterisk;

    public static bool perform = true;
    public static string s = null;
    public static StringBuilder sbToClear = new();
    public static StringBuilder sbToWrite = new();


    static CL()
    {
    }

    private static bool? _console_present;

    public static bool IsConsole2()
    {
        if (_console_present == null)
        {
            _console_present = true;
            try { int window_height = WindowHeight; }
            catch { _console_present = false; }
        }
        return _console_present.Value;
    }

    /// <summary>
    /// </summary>
    public static Func<string, string> i18n { get; set; }

    //public void PressEnterToContinue(CancellationToken cancellationToken)
    //{
    //    ConsoleKeyInfo cki = new ConsoleKeyInfo();
    //    do
    //    {
    //        // true hides the pressed character from the console
    //        cki = Console.ReadKey(true);

    //        // Wait for an ESC
    //    } while (cki.Key != ConsoleKey.Enter);

    //    // Cancel the token
    //    cancellationToken.Cancel();
    //}


    /// <summary>
    ///     Tohle můj problém nevyřešilo, po Entru se app vypne bez exc
    /// </summary>
    public static void PressEnterToContinue2()
    {
        using (var s = Console.OpenStandardInput())
        using (var sr = new StreamReader(s))
        {
            Task readLineTask = sr.ReadLineAsync();
            Debug.WriteLine("hi");
            Console.WriteLine("hello");

            readLineTask.Wait(); // When not in Main method, you can use await.
                                 // Waiting must happen in the curly brackets of the using directive.
        }

        Console.WriteLine("Bye Bye");
    }

    public static void PressEnterToContinue3()
    {
        Task.Factory.StartNew(() =>
        {
            while (Console.ReadKey().Key != ConsoleKey.Q) ;
            exit = true;
        });

        while (!exit)
        {
            // Do stuff
        }
    }

    /// <summary>
    ///     Return printed text
    /// </summary>
    /// <param name="text"></param>
    public static string StartRunTime(string text)
    {
        var textLength = text.Length;
        var stars = "";
        stars = new string(charOfHeader[0], textLength);
        StringBuilder sb = new();
        sb.AppendLine(stars);
        sb.AppendLine(text);
        sb.AppendLine(stars);
        var result = sb.ToString();
        Information(result);
        return result;
    }

    /// <summary>
    ///     Print and wait
    /// </summary>
    public static void EndRunTime(bool attempToRepairError = false)
    {
        if (attempToRepairError) Information(Messages.RepairErrors);

        Information(Messages.AppWillBeTerminated);
        Console.ReadLine();
    }

    /// <summary>
    ///     Return full path of selected file
    ///     or null when operation will be stopped
    /// </summary>
    /// <param name="folder"></param>
    public static string SelectFile(string folder)
    {
        var soubory = Directory.GetFiles(folder).ToList();
        var output = "";
        var selectedFile = SelectFromVariants(soubory, "file which you want to open");
        if (selectedFile == -1) return null;

        output = soubory[selectedFile];
        return output;
    }

    public static void WriteLineFormat(string text, params object[] p)
    {
        Console.WriteLine();
        Console.WriteLine(text, p);
    }


    public static void PressEnterAfterInsertDataToClipboard(string what)
    {
        //if (CmdApp.loadFromClipboard)
        //{
        AppealEnter("Insert " + what + " to clipboard");
        //}
    }

    public static void Clear()
    {
        Console.Clear();
    }


    public static void CmdTable(IEnumerable<List<string>> last)
    {
        StringBuilder formattingString = new();

        var f = last.First();
        for (var i = 0; i < f.Count; i++) formattingString.Append("{" + i + ",5}|");
        formattingString.Append("|");

        var fs = formattingString.ToString();

        foreach (var item in last) Console.WriteLine(fs, item.ToArray());
    }

    public static void WriteList(IEnumerable<string> l, string header)
    {
        WriteLine(header);
        WriteList(l);
    }

    public static void WriteList(IEnumerable<string> l)
    {
        foreach (var item in l) Console.WriteLine(item);
    }

    public static void Pair(string v, string formatTo)
    {
        Console.WriteLine(v + ": " + formatTo);
    }

    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue ...");
        Console.ReadLine();
    }


    /// <summary>
    ///     Ask user whether want to continue
    /// </summary>
    /// <param name="text"></param>
    public static DialogResult DoYouWantToContinue(string text)
    {
        text = i18n(XlfKeys.DoYouWantToContinue) + "?";
        Warning(text);
        var z = UserMustTypeYesNo(text).GetValueOrDefault();
        if (z) return DialogResult.Yes;

        return DialogResult.No;
    }


    /// <summary>
    ///     Print
    /// </summary>
    /// <param name="appeal"></param>
    public static void AppealEnter(string appeal)
    {
        Appeal(appeal + ". " + i18n(XlfKeys.ThenPressEnter) + ".");
        Console.ReadLine();
    }

    /// <summary>
    ///     Let user select action and run with A2 arg
    ///     EventHandler je zde správný protože EventHandler nikdy nemá Task
    /// </summary>
    /// <param name="akce"></param>
    public static
#if ASYNC
    async Task
#else
        void
#endif
        PerformAction(Dictionary<string, EventHandler> actions, object sender)
    {
        var listOfActions = NamesOfActions(actions);
        var selected = SelectFromVariants(listOfActions, i18n(XlfKeys.SelectActionToProceed) + ":");
        var ind = listOfActions[selected];
        var eh = actions[ind];

        if (sender == null) sender = selected;


        eh.Invoke(sender, EventArgs.Empty);
    }

    public static void WriteLineWithColor(ConsoleColor c, string v)
    {
        ForegroundColor = c;
        WriteLine(v);
        ResetColor();
    }

    /// <summary>
    ///     Return names of actions passed from keys
    /// </summary>
    /// <param name="actions"></param>
    private static List<string> NamesOfActions(Dictionary<string, EventHandler> actions)
    {
        List<string> ss = new();
        foreach (var var in actions) ss.Add(var.Key);

        return ss;
    }


    /// <summary>
    ///     Return int.MinValue when user force stop operation
    /// </summary>
    /// <param name="what"></param>
    public static int UserMustTypeNumber(string what, int max, int min)
    {
        string entered = null;
        var isNumber = false;
        entered = UserMustType(what, false);
        if (entered == null) return int.MinValue;

        isNumber = int.TryParse(entered, out var parsed);
        while (!isNumber)
        {
            entered = UserMustType(what, false);
            isNumber = int.TryParse(entered, out parsed);
            if (parsed <= max && parsed >= min) break;
        }

        return parsed;
    }

    /// <summary>
    ///     Return int.MinValue when user force stop operation
    /// </summary>
    /// <param name="vyzva"></param>
    public static int UserMustTypeNumber(int max)
    {
        const string whatUserMustEnter = "your choice as number";
        var entered = UserMustType(whatUserMustEnter, true);
        if (entered == null) return int.MinValue;

        if (int.TryParse(entered, out var parsed))
            if (parsed <= max)
                return parsed;

        return UserMustTypeNumber(whatUserMustEnter, max);
    }


    // Ty co jsou dal musí být ve cmd ale ještě to ověřit, TypedConsoleLogger by šlo zaměnit za metody Appeal atd.


    /// <summary>
    ///     Just print and wait
    /// </summary>
    public static void NoData()
    {
        AppealEnter(Messages.NoData);
        //ConsoleTemplateLogger.Instance.NoData();
    }


    /// <summary>
    ///     Pokud uz. zada Y,GT.
    ///     When N, return false.
    ///     When -1, return null
    /// </summary>
    /// <param name="text"></param>
    public static bool? UserMustTypeYesNo(string text)
    {
        var entered = UserMustType(text + " (Yes/No) ", false);
        // was pressed esc etc.
        if (entered == null) return false;

        if (entered == "-1") return null;

        var znak = entered[0];
        if (char.ToLower(entered[0]) == 'y' || znak == '1') return true;

        return false;
    }

    public static
#if ASYNC
    async Task<string>
#else
        string
#endif
        PerformActionAsync(Dictionary<string, object> actions)
    {
        var listOfActions = actions.Keys.ToList();
        return
#if ASYNC
    await
#endif
            PerformActionAsync(actions, listOfActions);
    }

    /// <summary>
    ///     A2 without ending :
    ///     Return index of selected action
    ///     Or int.MinValue when user force stop operation
    /// </summary>
    /// <param name="hodnoty"></param>
    /// <param name="what"></param>
    public static int SelectFromVariants(List<string> variants, string what)
    {
        Console.WriteLine();
        for (var i = 0; i < variants.Count; i++)
            Console.WriteLine(AllStringsSE.lsqb + i + AllStringsSE.rsqb + "  " + variants[i]);

        return UserMustTypeNumber(what, variants.Count - 1);
    }

    /// <summary>
    ///     Return int.MinValue when user force stop operation
    ///     A1 without ending :
    /// </summary>
    /// <param name="what"></param>
    /// <param name="max"></param>
    public static int UserMustTypeNumber(string what, int max)
    {
        var entered = UserMustType(what, false, false,
            Enumerable.Range(0, max + 1).OfType<string>().ToList().ToArray());
        if (what == null) return int.MinValue;

        if (int.TryParse(entered, out var parsed))
            if (parsed <= max)
                return parsed;

        return UserMustTypeNumber(what, max);
    }

    public static string UserMustTypeMultiLine(string v, params string[] anotherPossibleAftermOne)
    {
        string line = null;
        Information(AskForEnter(v, true));
        StringBuilder sb = new();
        //string lastAdd = null;
        while ((line = Console.ReadLine()) != null)
        {
            if (line == "-1") break;

            sb.AppendLine(line);
            if (anotherPossibleAftermOne.Contains(line)) break;
            //lastAdd = line;
        }

        //sb.AppendLine(line);
        var s2 = sb.ToString().Trim();
        return s2;
    }

    public static void AskForEnterWrite(string what, bool v)
    {
        WriteLine(AskForEnter(what, v));
    }

    public static string AskForEnter(string whatOrTextWithoutEndingDot, bool append)
    {
        if (append) whatOrTextWithoutEndingDot = i18n(XlfKeys.Enter) + " " + whatOrTextWithoutEndingDot + "";

        whatOrTextWithoutEndingDot += ". " + i18n(XlfKeys.ForExitEnter) + " -1.";
        return whatOrTextWithoutEndingDot;
    }

    /// <summary>
    ///     Is A1 is negative => chars to remove
    /// </summary>
    /// <param name="leftCursorAdd"></param>
    public static void ClearBehindLeftCursor(int leftCursorAdd)
    {
        var currentLineCursor = Console.CursorTop;
        var leftCursor = Console.CursorLeft + leftCursorAdd + 1;
        Console.SetCursorPosition(leftCursor, Console.CursorTop);
        Console.Write(new string(AllCharsSE.space, Console.WindowWidth + leftCursorAdd));
        Console.SetCursorPosition(leftCursor, currentLineCursor);
    }

    private static
#if ASYNC
    async Task<string>
#else
        string
#endif
        PerformActionAsync(Dictionary<string, object> actions, List<string> listOfActions)
    {
        var selected = SelectFromVariants(listOfActions, "Select action to proceed:");
        if (selected != -1)
        {
            var ind = listOfActions[selected];
            var eh = actions[ind];

#if ASYNC
            await
#endif
                    AsyncHelperSE.InvokeTaskVoidOrVoidVoid(eh);
            return ind;
        }

        return null;
    }

    /// <summary>
    ///     Musí se typovat Dictionary
    ///     <string, object>
    ///         object, ne TaskVoid ani VoidVoid
    /// </summary>
    /// <param name="actions"></param>
    /// <param name="listOfActions"></param>
    /// <returns></returns>
    private static
#if ASYNC
    async Task<string>
#else
        string
#endif
        PerformAction(Dictionary<string, object> actions, List<string> listOfActions)
    {
        var selected = SelectFromVariants(listOfActions, "Select action to proceed:");
        if (selected != -1)
        {
            var ind = listOfActions[selected];
            var eh = actions[ind];

#if ASYNC
            await
#endif
                    AsyncHelperSE.InvokeTaskVoidOrVoidVoid(eh);
            return ind;
        }

        return null;
    }

    public static void ClearCurrentConsoleLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        var currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    #region UserMustTypePrefix

    /// <summary>
    ///     if fail, return empty string.
    ///     Cant load multi line
    ///     Use Load
    /// </summary>
    /// <param name="what"></param>
    public static string UserMustType(string what, string prefix = "")
    {
        return UserMustType(what, true, false, prefix);
    }

    public static string UserCanType(string whatOrTextWithoutEndingDot, params string[] acceptableTyping)
    {
        return UserMustType(whatOrTextWithoutEndingDot, true, true, acceptableTyping);
    }

    public static string UserCanType(string whatOrTextWithoutEndingDot, bool append, params string[] acceptableTyping)
    {
        return UserMustType(whatOrTextWithoutEndingDot, append, false, acceptableTyping);
    }

    private static string UserMustType(string whatOrTextWithoutEndingDot, bool append, params string[] acceptableTyping)
    {
        return UserMustType(whatOrTextWithoutEndingDot, append, false, acceptableTyping);
    }

    private static string UserMustType(string whatOrTextWithoutEndingDot, bool append, bool canBeEmpty,
        params string[] acceptableTyping)
    {
        return UserMustTypePrefix(whatOrTextWithoutEndingDot, append, canBeEmpty, "", acceptableTyping);
    }

    /// <summary>
    ///     Potřebuji to tu protože ze schránky i načítám
    /// </summary>
    public static IClipboardHelper ClipboardHelper;

    /// <summary>
    ///     if fail, return empty string.
    ///     In A1 not end with :
    ///     Return null when user force stop
    ///     A2 are acceptable chars. Can be null/empty for anything
    /// </summary>
    /// <param name="whatOrTextWithoutEndingDot"></param>
    /// <param name="append"></param>
    private static string UserMustTypePrefix(string whatOrTextWithoutEndingDot, bool append, bool canBeEmpty,
        string prefix = "", params string[] acceptableTyping)
    {
        var z = "";
        whatOrTextWithoutEndingDot = prefix + AskForEnter(whatOrTextWithoutEndingDot, append);

        Console.WriteLine();
        Console.WriteLine(whatOrTextWithoutEndingDot);
        StringBuilder sb = new();
        var zadBefore = 0;
        var zad = 0;
        while (true)
        {
            zadBefore = zad;
            zad = Console.ReadKey().KeyChar;
            if (zad == 8)
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    // not delete visually, only move cursor about two back
                    //Console.Write(AllChars.bs2);
                    ClearBehindLeftCursor(-1);
                }
            }
            else if (zad == 27)
            {
                z = null;
                break;
            }
            else if (zad == 13)
            {
                if (acceptableTyping != null && acceptableTyping.Length != 0)
                    if (acceptableTyping.Contains(sb.ToString()))
                    {
                        z = sb.ToString();
                        break;
                    }

                var ulozit = sb.ToString();
                if (ulozit != "" || canBeEmpty)
                {
                    /// Cant call trim or replace \b (any whitespace character), due to situation when insert "/// " for insert xml comments
                    //ulozit = ulozit.Replace("\b", "");
                    z = ulozit;
                    break;
                }

                sb = new StringBuilder();
            }
            else
            {
                sb.Append((char)zad);
            }
        }

        if (z == string.Empty)
        {
            z = ClipboardHelper.GetText();
            Information(i18n(XlfKeys.AppLoadedFromClipboard) + " : " + z);
        }

        if (zadBefore != 32) z = z.Trim();

        z = SHSE.ConvertTypedWhitespaceToString(z.Trim(AllCharsSE.st));

        if (!string.IsNullOrWhiteSpace(z))
            if (zadBefore != 32)
                z = z.Trim();

        return z;
    }

    #endregion

    #region For easy copy from cl project

    public static bool inClpb;
    public static char src;

    public static void WriteLine(string a)
    {
        IsWritingDuringClbp();
        Console.WriteLine(a);
    }

    public static void WriteLine(int a)
    {
        IsWritingDuringClbp();
        Console.WriteLine(a.ToString());
    }

    public static void Write(string v)
    {
        IsWritingDuringClbp();
        Console.Write(v);
    }

    public static void Write(char v)
    {
        IsWritingDuringClbp();
        Console.Write(v);
    }

    public static void WriteLine()
    {
        IsWritingDuringClbp();
        Console.WriteLine();
    }

    /// <summary>
    ///     Must be O to express I'm counting with lover performance.
    /// </summary>
    /// <param name="correlationId"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void WriteLineO(object correlationId)
    {
        IsWritingDuringClbp();
        Console.WriteLine(correlationId.ToString());
    }

    public static void Write(string format, string left, object right)
    {
        IsWritingDuringClbp();
        Console.Write(format, left, right);
    }

    public static void Log(string a, params object[] o)
    {
        IsWritingDuringClbp();
        Console.WriteLine(a, o);
    }

    public static void WriteLine(string a, params object[] o)
    {
        IsWritingDuringClbp();
        Console.WriteLine(a, o);
    }

    /// <summary>
    ///     Good to be in CLConsole even if dont just call Console
    /// </summary>
    /// <param name="ex"></param>
    public static void WriteLine(Exception ex)
    {
        IsWritingDuringClbp();
        //Console.WriteLine(Exceptions.TextOfExceptions(ex));
        Console.WriteLine(ex.Message);
    }


    private static void IsWritingDuringClbp()
    {
        if (inClpb && src != ClSources.a) Debugger.Break();
    }

    public static int CursorTop => Console.CursorTop;
    public static int WindowWidth => Console.WindowWidth;
    public static int CursorLeft => Console.CursorLeft;

    public static TextWriter Error2 => Console.Error;
    public static TextWriter Out => Console.Out;

    public static ConsoleColor ForegroundColor
    {
        get => Console.ForegroundColor;
        set => Console.ForegroundColor = value;
    }

    public static int BufferWidth => Console.BufferWidth;


    public static int WindowHeight => Console.WindowHeight;

    #endregion

    #region For easy copy from cl project

    //public static bool inClpb { get => cl.Console.inClpb; set => cl.Console.inClpb = value; }
    //public static char src { get => cl.Console.src; set => cl.Console.src = value; }


    private static ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public static string ReadLine()
    {
        return Console.ReadLine();
    }

    private static void SetCursorPosition(int leftCursor, int cursorTop)
    {
        Console.SetCursorPosition(leftCursor, cursorTop);
    }

    public static void ResetColor()
    {
        Console.ResetColor();
    }

    #endregion
}

