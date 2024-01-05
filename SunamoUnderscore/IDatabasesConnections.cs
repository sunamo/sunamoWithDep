namespace SunamoUnderscore;

public interface IDatabasesConnections
{
    Databases defaultConnection { get; }

    void ForceSetCs(Databases dNew);
    void LoadDefaultConnection(RadioButtonsSql rbs);
    string NotifyAboutSunamoCzLocalInDebug(Databases d);
#if ASYNC
    Task
#else
void
#endif
    Reload();
    void SetConnToMSDatabaseLayer(Databases dNew, RadioButtonsSql rbs);
    void SetConnToMSDatabaseLayerSql5(Databases dNew);
    void TemporalySwitchConnToMSDatabaseLayer(Databases dNew, RadioButtonsSql rbs);
    void TemporalySwitchConnToMSDatabaseLayer(RadioButtonsSql rbs);
}
