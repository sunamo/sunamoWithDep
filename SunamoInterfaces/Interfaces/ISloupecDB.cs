namespace SunamoInterfaces.Interfaces;

public interface ISloupecDB<MSSloupecDB, SqlDbType2>
{
    MSSloupecDB CreateInstance(SqlDbType2 typ, string nazev, Signed signed, bool canBeNull, bool mustBeUnique, string referencesTable, string referencesColumn, bool primaryKey);
}
