namespace SunamoShared.Crypting;

/// <summary>
/// represents Hex, Byte, Base64, or String data to encrypt/decrypt;
/// use the .Text property to set/get a string representation
/// use the .Hex property to set/get a string-based Hexadecimal representation
/// use the .Base64 to set/get a string-based Base64 representation
///
/// Is use in classes Assymmetric,Symmetric,Hash
/// </summary>
public class DataCrypt
{
    private byte[] _b;
    private int _MaxBytes = 0;
    private int _MinBytes = 0;

    private int _StepBytes = 0;

    /// <summary>
    /// Determines the default text encoding across ALL DataCrypt instances
    /// </summary>
    public static Encoding DefaultEncoding = Encoding.GetEncoding(sess.i18n(XlfKeys.Windows1252));
    /// <summary>
    /// Determines the default text encoding for this DataCrypt instance (get & set)
    /// </summary>
    public Encoding Encoding = DefaultEncoding;

    public DataCrypt()
    {
    }

    public DataCrypt(byte[] b)
    {
        _b = b;
    }

    /// <summary>
    /// Creates new encryption data with the specified string;
    /// will be converted to byte array using default encoding
    /// </summary>
    public DataCrypt(string s)
    {
        Text = s;
    }

    /// <summary>
    /// Creates new encryption data using the specified string and the
    /// specified encoding to convert the string to a byte array.
    /// If A1 is in other encoding than cp1250, use these ctor.
    /// </summary>
    public DataCrypt(string s, Encoding encoding)
    {
        Encoding = encoding;
        Text = s;
    }

    /// <summary>
    /// returns true if no data is present
    /// get whether is _b N nebo L0
    /// </summary>
    public bool IsEmpty
    {
        get
        {
            if (_b == null)
            {
                return true;
            }
            if (_b.Length == 0)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// allowed step interval, in bytes, for this data; if 0, no limit
    /// IUN, pouze se do ni jednou uklada
    /// </summary>
    public int StepBytes
    {
        get { return _StepBytes; }
        set { _StepBytes = value; }
    }

    /// <summary>
    /// allowed step interval, in bits, for this data; if 0, no limit
    /// IUN, pouze se do ni jednou uklada
    /// </summary>
    public int StepBits
    {
        get { return _StepBytes * 8; }
        set { _StepBytes = value / 8; }
    }

    /// <summary>
    /// minimum number of bytes allowed for this data; if 0, no limit
    /// Minimimalni pocet bajtu v tomto O - PP _b
    /// </summary>
    public int MinBytes
    {
        get { return _MinBytes; }
        set { _MinBytes = value; }
    }

    /// <summary>
    /// minimum number of bits allowed for this data; if 0, no limit
    /// Minimalni pocet bytu v teto PP.
    /// </summary>
    public int MinBits
    {
        get { return _MinBytes * 8; }
        set { _MinBytes = value / 8; }
    }

    /// <summary>
    /// maximum number of bytes allowed for this data; if 0, no limit
    /// Maximalni pocet bytu v teto PP.
    /// </summary>
    public int MaxBytes
    {
        get { return _MaxBytes; }
        set { _MaxBytes = value; }
    }

    /// <summary>
    /// maximum number of bits allowed for this data; if 0, no limit
    /// Maximalni pocet bitu v teto PP.
    /// </summary>
    public int MaxBits
    {
        get { return _MaxBytes * 8; }
        set { _MaxBytes = value / 8; }
    }

    /// <summary>
    /// Returns the byte representation of the data;
    /// This will be padded to MinBytes and trimmed to MaxBytes as necessary!
    /// Pokud Mam limit bytu a _b je nad limitem, ulozim do _b jen bajty do limitu.
    /// Pokud mam nopak v _b mene bajtu nez je v _MinBytes, zkopiruji bajty do pole byte[_MinBytes] a tam je doplnim.
    /// </summary>
    public byte[] Bytes
    {
        get
        {
            if (_MaxBytes > 0)
            {
                if (_b.Length > _MaxBytes)
                {
                    byte[] b = new byte[_MaxBytes];
                    Array.Copy(_b, b, b.Length);
                    _b = b;
                }
            }
            if (_MinBytes > 0)
            {
                if (_b.Length < _MinBytes)
                {
                    byte[] b = new byte[_MinBytes];
                    Array.Copy(_b, b, _b.Length);
                    _b = b;
                }
            }
            return _b;
        }
        set { _b = value; }
    }

    /// <summary>
    /// Sets or returns text representation of bytes using the default text encoding
    /// Pri S prevedu do bajtu PP _b
    /// Pri G ziskam retezec z pp _b - ziskam prvni cislo v _b a pokud bude 0 nebo vetsi, ziskam vse do tohoto indexu z _b. Pokud bude _b null, G SE
    /// </summary>
    public string Text
    {
        get
        {
            if (_b == null)
            {
                return "";
            }
            else
            {
                int i = Array.IndexOf(_b, Convert.ToByte(0));
                if (i >= 0)
                {
                    return Encoding.GetString(_b, 0, i);
                }
                else
                {
                    return Encoding.GetString(_b);
                }
            }
        }
        set { _b = Encoding.GetBytes(value); }
    }

    /// <summary>
    /// Sets or returns Hex string representation of this data
    /// Prevede z/na PP _b
    /// </summary>
    public string Hex
    {
        get { return Utils.ToHex(_b.ToList()); }
        set { _b = Utils.FromHex(value).ToArray(); }
    }

    /// <summary>
    /// Sets or returns Base64 string representation of this data
    /// Prevede z/na PP _b
    /// </summary>
    public string Base64
    {
        get { return Utils.ToBase64(_b.ToList()); }
        set { _b = Utils.FromBase64(value); }
    }

    /// <summary>
    /// Returns text representation of bytes using the default text encoding
    /// G PP Text
    /// </summary>
    public new string ToString()
    {
        return Text;
    }

    /// <summary>
    /// returns Base64 string representation of this data
    /// G PP Base64
    /// </summary>
    public string ToBase64()
    {
        return Base64;
    }

    /// <summary>
    /// returns Hex string representation of this data
    /// G PP Hex
    /// </summary>
    public string ToHex()
    {
        return Hex;
    }


    public static
#if ASYNC
async Task<DataCrypt>
#else
  DataCrypt
#endif
FromFile(string var)
    {
        DataCrypt d = new DataCrypt();
        d.Text =
#if ASYNC
await
#endif
TF.ReadAllText(var);
        return d;
    }
}
