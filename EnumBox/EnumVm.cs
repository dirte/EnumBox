using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumBox
{
    class EnumVm
    {
        public EnumVm(PaymentFrequency paymentFrequency)
        {
            PaymentFrequency = paymentFrequency;
        }

        public static List<EnumVm> CreateList()
        {
            return Enum.GetValues(typeof(PaymentFrequency))
                       .Cast<PaymentFrequency>()
                       .Select(x => new EnumVm(x)).ToList();
        }

        public PaymentFrequency PaymentFrequency { get; private set; }

        public string FriendlyName
        {
            get
            {
                return PaymentFrequency.GetEnumDescription();
            }
        }
    }

    static class EnumDescriptionUtilities
    {
        public static string GetEnumDescription(this Enum enumObj)
        {
            if (enumObj != null)
            {
                FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

                object[] attribArray = fieldInfo.GetCustomAttributes(false);

                if (attribArray.Length == 0)
                {
                    return enumObj.ToString();
                }
                else
                {
                    DescriptionAttribute attrib = attribArray[0] as DescriptionAttribute;
                    return attrib.Description;
                }
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Payment Frequency
    /// </summary>
    public enum PaymentFrequency
    {
        [Description("None")]
        None = 0,
        [Description("Annually")]
        Annually = 1,
        [Description("Semi-Annually")]
        SemiAnnually = 2,
        [Description("Every 4th Month")]
        EveryFourthMonth = 3,
        [Description("Quarterly")]
        Quarterly = 4,
        [Description("Bi-Monthly")]
        BiMonthly = 6,
        [Description("Monthly")]
        Monthly = 12,
        [Description("Every 4th Week")]
        EveryFourthWeek = 13,
        [Description("Semi-Monthly")]
        SemiMonthly = 24,
        [Description("Bi-Weekly")]
        BiWeekly = 26,
        [Description("Weekly")]
        Weekly = 52
    }
}
