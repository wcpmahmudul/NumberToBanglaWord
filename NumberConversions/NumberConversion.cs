using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToBanglaWords.NumberConversions
{
    public class NumberConversion
    {
        readonly static string[] hund = {"", "এক", "দুই", "তিন", "চার", "পাঁচ", "ছয়", "সাত", "আট", "নয়", "দশ",
            "এগার", "বার", "তের", "চৌদ্দ", "পনের", "ষোল", "সতের", "আঠার", "ঊনিশ", "বিশ",
            "একুশ", "বাইশ", "তেইশ", "চব্বিশ", "পঁচিশ", "ছাব্বিশ", "সাতাশ", "আঠাশ", "ঊনত্রিশ", "ত্রিশ",
            "একত্রিশ", "বত্রিশ", "তেত্রিশ", "চৌত্রিশ", "পয়ত্রিশ", "ছত্রিশ", "সাতত্রিশ", "আটত্রিশ", "ঊনচল্লিশ", "চল্লিশ",
            "একচল্লিশ", "বেয়াল্লিশ", "তেতাল্লিশ", "চোয়াল্লিশ", "পঁয়তাল্লিশ", "ছেচল্লিশ", "সাতচল্লিশ", "আটচল্লিশ", "ঊনপঞ্চাশ", "পঞ্চাশ",
            "একান্ন", "বাহান্ন", "তেপান্ন", "চোয়ান্ন", "পঁঞ্চান্ন", "ছাপ্পান্ন", "সাতান্ন", "আটান্ন", "ঊনষাট", "ষাট",
            "একষট্টি", "বাষট্টি", "তেষট্টি", "চৌষট্টি", "পঁয়ষট্টি", "ছেষট্টি", "সাতষট্টি", "আটষট্টি", "ঊনসত্তর", "সত্তর",
            "একাত্তর", "বাহাত্তর", "তেহাত্তর", "চোয়াত্তর", "পঁচাত্তর", "ছিয়াত্তর", "সাতাত্তর", "আটাত্তর", "ঊনআশি", "আশি",
            "একাশি", "বিরাশি", "তিরাশি", "চোরাশি", "পঁচাশি", "ছিয়াশি", "সাতাশি", "আটাশি", "ঊননব্বই", "নব্বই",
            "একানব্বই", "বিরানব্বই", "তিরানব্বই", "চুরানব্বই", "পঁচানব্বই", "ছিয়ানব্বই", "সাতানব্বই", "আটানব্বই", "নিরানব্বই", "একশ" };

        public static string ToBanglaWord(string number)
        {
            try
            {
                if (!IsNumeric(number))
                    return "বৈধ নাম্বার নয়";

                return Number2Bangla(Convert.ToDecimal(number));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static string Number2Bangla(decimal number)
        {

            if (number < 0 || number > 999999999)
                return "নাম্বারটি অতিরিক্ত বড়";

            decimal Kt = Math.Floor(number / 10000000); /* Koti */
            number -= Kt * 10000000;
            decimal Gn = Math.Floor(number / 100000);  /* lakh  */
            number -= Gn * 100000;
            decimal kn = Math.Floor(number / 1000);     /* Thousands (kilo) */
            number -= kn * 1000;
            decimal Hn = Math.Floor(number / 100);      /* Hundreds (hecto) */
            number -= Hn * 100;
            decimal Dn = Math.Floor(number / 10);       /* Tens (deca) */
            decimal n = number % 10;               /* Ones */
            string res = "";
            if (Kt > 0)
            {
                res = Number2Bangla(Kt) + " কোটি ";
            }
            if (Gn > 0)
            {
                res = res + Number2Bangla(Gn) + " লাখ";
            }
            if (kn > 0)
            {
                res = res + (res == "" ? "" : " ") + Number2Bangla(kn) + " হাজার";
            }
            if (Hn > 0)
            {
                res = res + (res == "" ? "" : " ") + Number2Bangla(Hn) + " শত";
            }


            if (Dn > 0 || n > 0)
            {
                if (res != "")
                {
                    res = res + " ";
                }
                res = res + hund[(int)Dn * 10 + (int)n];
            }
            if (res == "")
            {
                res = "শূন্য";
            }
            return res;

        }
        static bool IsNumeric(string number)
        {
            int n;
            return int.TryParse(number, out n);
        }
    }
}
