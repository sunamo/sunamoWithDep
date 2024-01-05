namespace SunamoValues.Values;

//using System;
//using System.Collections.Generic;
//using System.Text;


//    public partial class AllChars
//    {
////    #region Old
////    public const char dot = '.';
////    public const char dash = '-';
////    public const char qm = '"';
////    public const char emDash = '—';
////    public const char bs = '\\';
////    public static char space160 = (char)160;
////    public const char lb = '(';

////    #region  from AllChars.cs
////    // my extension
////    public static readonly List<int> specialKeyCodes = new List<int>(new int[] { 33, 64, 35, 36, 37, 94, 38, 42, 63, 95, 126 });

////    public static readonly List<char> specialCharsWhite = new List<char>(new char[] { space });
////    public static readonly List<char> specialCharsNotEnigma = new List<char>(new char[] { nbsp, space160, copy });
////    /// <summary>
////    /// Used in enigma
////    /// </summary>
////    public static readonly List<char> specialCharsAll = null;

////    /*
////equal->equals

////     *
////     * Ascii - 128 chars - 7B
////     * ASCII + code page (e.g. ISO 8859-1) - 256 chars - 8B
////     *
////     * Unicode 11.0:
////     * * Basic Multilingual Plane - 65536 letters - table 16*16, in every cell 256 letters, all others (SMP, SIP, TIP) are part of this
////     * Supplementary Multilingual Plane (SMP) - Doplňková multilinguální rovina - 14000 chars -
////     * Supplementary Ideographic Plane (SIP) - 53424 chars -
////     * Tertiary Ideographic Plane (TIP) - 16672 chars
////     * Supplementary Special-purpose Plane (SSP) - 368 chars
////     * 15 PUA-A 65536
////     * 16 PUA-B 65536
////     *
////     * =  overall 264256 letters
////     *
////     * Surrogates - replacement, by two surrogates is coded one letter above BMP (surrogate pair). Is in UTF16. Benefit is less space (some letters have two bytes, others 4B). In UTF32 is every char 4bytes.
////     * char.IsSurrogatePair(low, right) - pair is formed by low and high
////     * *
////     */

////    // IsControl
////    //public const List<int> controlKeyCodes =
////    // IsDigit - IsNumber + superset atd.
////    public static readonly List<int> numericKeyCodes = new List<int>(new int[] { 49, 50, 51, 52, 53, 54, 55, 56, 57, 48 });
////    public static readonly List<char> numericChars = new List<char>(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });

////    // IsHighSurrogate -

////    // IsLower
////    public static readonly List<int> lowerKeyCodes = new List<int>(new int[] { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 });
////    public static readonly List<char> lowerChars = new List<char>(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' });

////    // IsLowSurrogate

////    // IsNumber - 0..9
////    // IsPunctuation
////    // IsSeparator
////    // IsSurrogate
////    // IsSurrogatePair
////    // IsSymbol

////    // IsUpper
////    public static readonly List<int> upperKeyCodes = new List<int>(new int[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 });
////    public static readonly List<char> upperChars = new List<char>(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' });
////    #endregion
//    #endregion

//}
