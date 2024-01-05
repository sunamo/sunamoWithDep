namespace SunamoDelegates;

// must be in SE, not SS - many project would reference SS only due to delegates

public delegate void VoidBool(bool b);


public delegate void VoidBoolNullable(bool? b);

#if ASYNC
public delegate Task TaskBoolNullable(bool? b);
#else
public delegate void TaskBoolNullable(bool? b);
#endif

public delegate void VoidBoolNullableObject(bool? b, object o);

public delegate string StringString(string s);

public delegate void VoidString(string s);

public delegate void VoidInt(int s);

public delegate void VoidStringT<T>(string s, T t);

public delegate void UStringT<U, T>(string s, T t);

public delegate void VoidStringTU<T, U>(string s, T t, U u);

public delegate void VoidObjectBool(object o, bool b);

public delegate byte[] ByteArrayByteArrayByteArrayHandler(byte[] b1, byte[] b2);

public delegate DateTime DateTimeDoubleDateTimeHandler(double d, DateTime dt);

public delegate DateTime DateTimeIntDateTimeHandler(int nt, DateTime dt);

public delegate void EmptyHandler();

public delegate void StatusBroadcasterHandler(string del);

public delegate string StringByteArrayByteArrayHandler(byte[] b1, byte[] b2);

public delegate string StringStringHandler(string s);

public delegate string StringStringByteArrayHandler(string s, byte[] b);

#if ASYNC
public delegate Task TaskT<T>(T t);
#else
public delegate void TaskT<T>(T t);
#endif

public delegate void VoidT<T>(T t);

public delegate void VoidT3<T, U, Z>(T t, U u, Z z);

public delegate void VoidVoid();

#if ASYNC
public delegate Task TaskVoid();
#else
public delegate void TaskVoid();
#endif


public delegate void VoidListT<T>(List<T> c);

public delegate void VoidUri(Uri uri);

public delegate void VoidDouble(double c);

public delegate void VoidObject(object o);

//public delegate void VoidStringParamsObjects(string s, params string[] o);
//public delegate void Action<object, Object[]>(object s, params string[] o);

public delegate bool BoolString(string s);

public delegate byte[] SifrujSymetricky(byte[] plainTextBytes, string passPhrase, byte[] saltValueBytes,
byte[] initVectorBytes);

public delegate string StringVoid();

public delegate void VoidUIElement(VoidUIElement uie);

public delegate void VoidIntDouble(int nt, double d);


public delegate List<string> ListStringListString(List<string> list);
