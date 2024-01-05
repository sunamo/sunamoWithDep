using SunamoThisApp;
using SunamoTypeOfMessage;

namespace SunamoLogger.Logger.TypedLoggerBaseNS;



public class TypedSunamoLogger : TypedLoggerBase
{
    public static TypedSunamoLogger Instance = new TypedSunamoLogger();

    private TypedSunamoLogger() : base(WriteLineWorker)
    {
    }

    public static void WriteLineWorker(TypeOfMessage tz, string text, params string[] args)
    {
        ThisApp.SetStatus(tz, text, args);
    }


}
