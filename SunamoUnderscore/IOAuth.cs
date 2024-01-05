namespace SunamoUnderscore;

/// <summary>
///     Common for Cm + Gp
/// </summary>
public interface IOAuth
{
    string ApiUri { get; }
    string ClientSecret { get; }

    /// <summary>
    ///     In gp clientID
    /// </summary>
    string MerchantId { get; }
}

public interface IGoPayOAuth : IOAuth
{
    long GoID { get; }
}

/// <summary>
///     mus� b�t v SE
///     mohl bych to d�t do Scz.import kter� referencuje SunamoComgate
///     ale t�m bych nemohl u��vat GoPay stejnou cestou
/// </summary>
public interface IComgateOAuth : IOAuth
{
    /// <summary>
    ///     cm specific
    /// </summary>
    string Email { get; }
}
