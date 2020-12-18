using System;
using UnityEngine;
using Random = System.Random;

public static class Utility
{
        private static Random _r = new Random();
        internal static int RandInt(int max)
        {
                return _r.Next(max);
        }

        internal static string UnifyPersianLetters(this string target)
        {
                var t = "";
                for (var i = 0; i < target.Length; i++)
                {
                        if (target[i] == 'ی' || target[i] == 'ﻯ' || target[i] == 'ﻱ' || target[i] == 'ي' || target[i] == 'ی')
                                t += "ی";
                        else
                                t += target[i];
                }

                return t;
        }
}