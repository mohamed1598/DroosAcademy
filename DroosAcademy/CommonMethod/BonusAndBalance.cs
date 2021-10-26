using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroosAcademy.CommonMethod
{
    public class BonusAndBalance
    {
        static public int convertMoneyToBonus(int money)
        {
            
            return Convert.ToInt32(Math.Floor(money / 20.0));
        }
        static public int convertBonusToMoney(int bonus)
        {

            return bonus;
        }
    }
}
