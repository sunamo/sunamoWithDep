namespace SunamoFubuCsProjFile._NotMine.Templating.Runtime;

public interface ITemplateLogger
{
    void Starting(int numberOfSteps);
    void TraceStep(ITemplateStep step);
    void Trace(string contents, params string[] parameters);
    void StartProject(int numberOfAlterations);
    void EndProject();
    void TraceAlteration(string alteration);
    void Finish();
    void WriteSuccess(string message);
    void WriteWarning(string message);
}
