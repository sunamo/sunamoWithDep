namespace SunamoShared.Helpers;


public abstract class SqlHelper
{
    public string ListingWholeTable(string tableName, DataTable dt)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(Consts._3Asterisks + sess.i18n(XlfKeys.StartOfListingWholeTable) + " " + tableName + Consts._3Asterisks);
        if (dt.Rows.Count != 0)
        {
            sb.AppendLine(SF.PrepareToSerialization2(GetColumnsOfTable(tableName)));
            foreach (DataRow item in dt.Rows)
            {
                sb.AppendLine(SF.PrepareToSerialization2(item.ItemArray.ToList().ConvertAll(d => d.ToString())));
            }
        }

        sb.AppendLine(Consts._3Asterisks + sess.i18n(XlfKeys.EndOfListingWholeTable) + " " + tableName + Consts._3Asterisks);
        return sb.ToString();
    }

    protected abstract string[] GetColumnsOfTable(string p);
}
