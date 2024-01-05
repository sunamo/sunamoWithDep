namespace SunamoValues.Values;

//using System;
//using System.Collections.Generic;
//using System.Diagnostics;


///// <summary>
///// Je to všechno v jedné třídě, aby se mi změny udělané zde projevili ve všech třídách.
///// </summary>
//public static partial class AllChars
//{


//    private static Type type = typeof(AllChars);

//    // my extension
//    public static readonly List<char> generalChars = null;


//    // IsWhiteSpace
//    // , 55296 mi taky vrátila metoda IsWhiteSpace vrátila, ale při znovu vytvoření pomocí tohoto kódu to vyhazovalo výjimku
//    /// <summary>
//    /// 160 is space, is used for example in Uctenkovka
//    /// </summary>
//    public static readonly List<int> whiteSpacesCodes = new List<int>(new int[] { 9, 10, 11, 12, 13, 32, 133, 160, 5760, 6158, 8192, 8193, 8194, 8195, 8196, 8197, 8198, 8199, 8200, 8201, 8202, 8232, 8233, 8239, 8287, 12288 });
//    public static List<char> whiteSpacesChars = null;


//    static AllChars()
//    {
//        ConvertWhiteSpaceCodesToChars();
//        notNumber = (char)whiteSpacesCodes[0];
//        generalChars = new List<char>(new char[] { notNumber });

//        specialCharsAll = new List<char>(specialChars.Count + specialChars2.Count + specialCharsWhite.Count);
//        specialCharsAll.AddRange(specialChars);
//        specialCharsAll.AddRange(specialChars2);
//        specialCharsAll.AddRange(specialCharsWhite);
//    }

//    public static Predicate<char> ReturnRightPredicate(char genericChar)
//    {
//        Predicate<char> predicate = null;
//        if (genericChar == AllChars.notNumber)
//        {
//            predicate = char.IsNumber;
//        }
//        else
//        {
//            ThrowEx.NotImplementedCase(generalChars);
//        }

//        return predicate;
//    }

//    public static void ConvertWhiteSpaceCodesToChars()
//    {
//        whiteSpacesChars = new List<char>();
//        foreach (int item in whiteSpacesCodes)
//        {
//            string s = "";
//            s = char.ConvertFromUtf32(item);
//            whiteSpacesChars.Add(Convert.ToChar(s));
//        }
//    }


//}
