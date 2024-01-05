namespace SunamoShared.Constants;

public class RandomStatuses
{
    public void SetStatusOfType(TypeOfMessage type)
    {
        ThisApp.SetStatus(type, type.ToString());
    }

    public void SetAllTypes()
    {
        foreach (var item in EnumHelper.GetValues<TypeOfMessage>())
        {
            SetStatusOfType(item);
        }
    }
}
