namespace SunamoInterfaces.Interfaces;

public interface IValidateControl
{
    bool Validate(object tb, object control, ref ValidateData d);
    bool Validate(object tbFolder, ref ValidateData d);
    bool Validated { get; set; }
    /// <returns></returns>
    object GetContent();
}
