// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

/*
* Regionysi budu užívat v jakém rozsahu chci protože pomáhají orientaci
*/



[assembly:
SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1124:Do not use regions", Justification = "<Pending>",
Scope = "type", Target = "~T:AllCharsSE")]
/*
Toto se mi bude občas dít, např:
dict.Add("Ulice",
#if ASYNC
await
#endif
R(f[++i])); // 07


*/
[assembly:
SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:Parameter should not span multiple lines",
Justification = "<Pending>", Scope = "member",
Target =
"~M:research.Program.ParseSrealityListingsFromFolder(System.Int32,System.Int32)~System.Threading.Tasks.Task")]
/*
* static string SanitizeFlats(string r)
* když je private default, je přece zbytečné ho deklarovat
*/
[assembly:
SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1400:Access modifier should be declared",
Justification = "<Pending>", Scope = "member",
Target = "~M:research.Program.SanitizeFlats(System.String)~System.String")]
/*
* Ano, vše má být zdokumentováno. Dočasně to budu ignorovat, vezme hodně času.
*/
[assembly:
SuppressMessage("StyleCop.CSharp.NamingRules", "SA1307:Accessible fields should begin with upper-case letter",
Justification = "<Pending>", Scope = "member", Target = "~F:Types.tUint")]

/*
Nahradí mi to new byte[] { 82, 73, 70, 70 }
za "RIFF"u8.ToArray())
*/
[assembly:
SuppressMessage("Style", "IDE0230:Use UTF-8 string literal", Justification = "<Pending>", Scope = "member",
Target = "~M:SunamoMimeHelper.Init")]
/*
* V seznamech přidává na konec čárku. zbytečné.
*/
[assembly:
SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1413:Use trailing comma in multi-line initializers",
Justification = "<Pending>", Scope = "member", Target = "~F:AllCharsSE.lowerChars")]
