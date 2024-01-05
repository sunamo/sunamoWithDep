namespace SunamoShared.Helpers.Runtime;
//using System.Web.Helpers;

public class DynamicHelper
{
    public static List<dynamic> ListFromDynamicObject(dynamic o)
    {
        /*
Zakomentoval jsem proto�e mi pou��val System.Web:         
System.Web => ASP.NET; Microsoft.AspNetCore => ASP.NET Core. DON'T mix them up.


         */
        throw new Exception();

        if (o is IList)
        {
            List<dynamic> d2 = new List<dynamic>();
            var en3 = (IList)o;
            //var t2 = en3.GetType();

            foreach (IList item in en3)
            {
                foreach (var item2 in item)
                {
                    d2.Add(item2);
                }
            }

            //var en4 = (IList)en3[0];

            return d2;

        }

        List<dynamic> d = new List<dynamic>();
        var t = (Type)o.GetType();
        //var vf = RH.GetValueOfField ("_values");
        //var vfv = vf.GetValue(o);

        //var vfv = RH.GetValueOfField("_values", t, o, false);


        return null;



        //var djo = (DynamicJsonObject)o;

        ////var vfv = o["_values"];
        //var vfv2 = djo.GetDynamicMemberNames(); // ["_values"];

        ////var en2 = (IList)vfv;
        //foreach (var item in vfv2)
        //{
        //    d.Add(o[item]);
        //}

        //return d;
    }
}
