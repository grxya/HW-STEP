using BookCenter.Models;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookCenter.Services.Classes
{
    class InputCheckService
    {
        private static Regex YearRegex = new("(0[1-9]|1[0-2])/([0-9][0-9])");
        private static Regex cvvRegex = new("([0-9][0-9][0-9])");
        private static Regex CardNumRegex = new("\\d{16}");

        public static bool CheckAll(CardModel card)
        {
            return IsCardNumValid(card.CardNum) && IsCVVvalid(card.CVV) && IsYearValid(card.Year);
        }

        private static bool IsCardNumValid(string CardNum)
        {
            if(CardNum == null) return false;

            return CardNumRegex.IsMatch(CardNum);
        }

        private static bool IsCVVvalid(string CVV)
        {
            if(CVV == null) return false;
            return cvvRegex.IsMatch(CVV);
        }

        private static bool IsYearValid(string Year) 
        { 
            if(Year == null) return false;

            if(YearRegex.IsMatch(Year)) 
            { 
                if(Year.Substring(3) == (DateTime.Now.Year%100).ToString())
                {
                    if (Convert.ToInt32(Year.Substring(0, 2)) > DateTime.Now.Month)
                    {
                        return true;
                    }
                }
                else if (Convert.ToInt32(Year.Substring(3)) > (DateTime.Now.Year % 100))
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
