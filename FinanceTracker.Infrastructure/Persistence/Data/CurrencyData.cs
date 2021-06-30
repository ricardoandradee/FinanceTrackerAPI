using FinanceTracker.Domain.Entities;
using System;
using System.Collections.Generic;

namespace FinanceTracker.Infrastructure.Persistence.Data
{
    public static class CurrencyData
    {
        public static List<Currency> GetCurrencyList()
        {
            var currencies = new List<Currency>()
            {
                new Currency()
                {
                    Code = "AED"
                },
                new Currency()
                {
                    Code = "AFN"
                },
                new Currency()
                {
                    Code = "ALL"
                },
                new Currency()
                {
                    Code = "AMD"
                },
                new Currency()
                {
                    Code = "ANG"
                },
                new Currency()
                {
                    Code = "AOA"
                },
                new Currency()
                {
                    Code = "ARS"
                },
                new Currency()
                {
                    Code = "AUD"
                },
                new Currency()
                {
                    Code = "AWG"
                },
                new Currency()
                {
                    Code = "AZN"
                },
                new Currency()
                {
                    Code = "BAM"
                },
                new Currency()
                {
                    Code = "BBD"
                },
                new Currency()
                {
                    Code = "BDT"
                },
                new Currency()
                {
                    Code = "BGN"
                },
                new Currency()
                {
                    Code = "BHD"
                },
                new Currency()
                {
                    Code = "BIF"
                },
                new Currency()
                {
                    Code = "BMD"
                },
                new Currency()
                {
                    Code = "BND"
                },
                new Currency()
                {
                    Code = "BOB"
                },
                new Currency()
                {
                    Code = "BRL"
                },
                new Currency()
                {
                    Code = "BSD"
                },
                new Currency()
                {
                    Code = "BTC"
                },
                new Currency()
                {
                    Code = "BTN"
                },
                new Currency()
                {
                    Code = "BWP"
                },
                new Currency()
                {
                    Code = "BYN"
                },
                new Currency()
                {
                    Code = "BYR"
                },
                new Currency()
                {
                    Code = "BZD"
                },
                new Currency()
                {
                    Code = "CAD"
                },
                new Currency()
                {
                    Code = "CDF"
                },
                new Currency()
                {
                    Code = "CHF"
                },
                new Currency()
                {
                    Code = "CLF"
                },
                new Currency()
                {
                    Code = "CLP"
                },
                new Currency()
                {
                    Code = "CNY"
                },
                new Currency()
                {
                    Code = "COP"
                },
                new Currency()
                {
                    Code = "CRC"
                },
                new Currency()
                {
                    Code = "CUC"
                },
                new Currency()
                {
                    Code = "CUP"
                },
                new Currency()
                {
                    Code = "CVE"
                },
                new Currency()
                {
                    Code = "CZK"
                },
                new Currency()
                {
                    Code = "DJF"
                },
                new Currency()
                {
                    Code = "DKK"
                },
                new Currency()
                {
                    Code = "DOP"
                },
                new Currency()
                {
                    Code = "DZD"
                },
                new Currency()
                {
                    Code = "EGP"
                },
                new Currency()
                {
                    Code = "ERN"
                },
                new Currency()
                {
                    Code = "ETB"
                },
                new Currency()
                {
                    Code = "EUR"
                },
                new Currency()
                {
                    Code = "FJD"
                },
                new Currency()
                {
                    Code = "FKP"
                },
                new Currency()
                {
                    Code = "GBP"
                },
                new Currency()
                {
                    Code = "GEL"
                },
                new Currency()
                {
                    Code = "GGP"
                },
                new Currency()
                {
                    Code = "GHS"
                },
                new Currency()
                {
                    Code = "GIP"
                },
                new Currency()
                {
                    Code = "GMD"
                },
                new Currency()
                {
                    Code = "GNF"
                },
                new Currency()
                {
                    Code = "GTQ"
                },
                new Currency()
                {
                    Code = "GYD"
                },
                new Currency()
                {
                    Code = "HKD"
                },
                new Currency()
                {
                    Code = "HNL"
                },
                new Currency()
                {
                    Code = "HRK"
                },
                new Currency()
                {
                    Code = "HTG"
                },
                new Currency()
                {
                    Code = "HUF"
                },
                new Currency()
                {
                    Code = "IDR"
                },
                new Currency()
                {
                    Code = "ILS"
                },
                new Currency()
                {
                    Code = "IMP"
                },
                new Currency()
                {
                    Code = "INR"
                },
                new Currency()
                {
                    Code = "IQD"
                },
                new Currency()
                {
                    Code = "IRR"
                },
                new Currency()
                {
                    Code = "ISK"
                },
                new Currency()
                {
                    Code = "JEP"
                },
                new Currency()
                {
                    Code = "JMD"
                },
                new Currency()
                {
                    Code = "JOD"
                },
                new Currency()
                {
                    Code = "JPY"
                },
                new Currency()
                {
                    Code = "KES"
                },
                new Currency()
                {
                    Code = "KGS"
                },
                new Currency()
                {
                    Code = "KHR"
                },
                new Currency()
                {
                    Code = "KMF"
                },
                new Currency()
                {
                    Code = "KPW"
                },
                new Currency()
                {
                    Code = "KRW"
                },
                new Currency()
                {
                    Code = "KWD"
                },
                new Currency()
                {
                    Code = "KYD"
                },
                new Currency()
                {
                    Code = "KZT"
                },
                new Currency()
                {
                    Code = "LAK"
                },
                new Currency()
                {
                    Code = "LBP"
                },
                new Currency()
                {
                    Code = "LKR"
                },
                new Currency()
                {
                    Code = "LRD"
                },
                new Currency()
                {
                    Code = "LSL"
                },
                new Currency()
                {
                    Code = "LTL"
                },
                new Currency()
                {
                    Code = "LVL"
                },
                new Currency()
                {
                    Code = "LYD"
                },
                new Currency()
                {
                    Code = "MAD"
                },
                new Currency()
                {
                    Code = "MDL"
                },
                new Currency()
                {
                    Code = "MGA"
                },
                new Currency()
                {
                    Code = "MKD"
                },
                new Currency()
                {
                    Code = "MMK"
                },
                new Currency()
                {
                    Code = "MNT"
                },
                new Currency()
                {
                    Code = "MOP"
                },
                new Currency()
                {
                    Code = "MRO"
                },
                new Currency()
                {
                    Code = "MUR"
                },
                new Currency()
                {
                    Code = "MVR"
                },
                new Currency()
                {
                    Code = "MWK"
                },
                new Currency()
                {
                    Code = "MXN"
                },
                new Currency()
                {
                    Code = "MYR"
                },
                new Currency()
                {
                    Code = "MZN"
                },
                new Currency()
                {
                    Code = "NAD"
                },
                new Currency()
                {
                    Code = "NGN"
                },
                new Currency()
                {
                    Code = "NIO"
                },
                new Currency()
                {
                    Code = "NOK"
                },
                new Currency()
                {
                    Code = "NPR"
                },
                new Currency()
                {
                    Code = "NZD"
                },
                new Currency()
                {
                    Code = "OMR"
                },
                new Currency()
                {
                    Code = "PAB"
                },
                new Currency()
                {
                    Code = "PEN"
                },
                new Currency()
                {
                    Code = "PGK"
                },
                new Currency()
                {
                    Code = "PHP"
                },
                new Currency()
                {
                    Code = "PKR"
                },
                new Currency()
                {
                    Code = "PLN"
                },
                new Currency()
                {
                    Code = "PYG"
                },
                new Currency()
                {
                    Code = "QAR"
                },
                new Currency()
                {
                    Code = "RON"
                },
                new Currency()
                {
                    Code = "RSD"
                },
                new Currency()
                {
                    Code = "RUB"
                },
                new Currency()
                {
                    Code = "RWF"
                },
                new Currency()
                {
                    Code = "SAR"
                },
                new Currency()
                {
                    Code = "SBD"
                },
                new Currency()
                {
                    Code = "SCR"
                },
                new Currency()
                {
                    Code = "SDG"
                },
                new Currency()
                {
                    Code = "SEK"
                },
                new Currency()
                {
                    Code = "SGD"
                },
                new Currency()
                {
                    Code = "SHP"
                },
                new Currency()
                {
                    Code = "SLL"
                },
                new Currency()
                {
                    Code = "SOS"
                },
                new Currency()
                {
                    Code = "SRD"
                },
                new Currency()
                {
                    Code = "STD"
                },
                new Currency()
                {
                    Code = "SVC"
                },
                new Currency()
                {
                    Code = "SYP"
                },
                new Currency()
                {
                    Code = "SZL"
                },
                new Currency()
                {
                    Code = "THB"
                },
                new Currency()
                {
                    Code = "TJS"
                },
                new Currency()
                {
                    Code = "TMT"
                },
                new Currency()
                {
                    Code = "TND"
                },
                new Currency()
                {
                    Code = "TOP"
                },
                new Currency()
                {
                    Code = "TRY"
                },
                new Currency()
                {
                    Code = "TTD"
                },
                new Currency()
                {
                    Code = "TWD"
                },
                new Currency()
                {
                    Code = "TZS"
                },
                new Currency()
                {
                    Code = "UAH"
                },
                new Currency()
                {
                    Code = "UGX"
                },
                new Currency()
                {
                    Code = "USD"
                },
                new Currency()
                {
                    Code = "UYU"
                },
                new Currency()
                {
                    Code = "UZS"
                },
                new Currency()
                {
                    Code = "VEF"
                },
                new Currency()
                {
                    Code = "VND"
                },
                new Currency()
                {
                    Code = "VUV"
                },
                new Currency()
                {
                    Code = "WST"
                },
                new Currency()
                {
                    Code = "XAF"
                },
                new Currency()
                {
                    Code = "XAG"
                },
                new Currency()
                {
                    Code = "XAU"
                },
                new Currency()
                {
                    Code = "XCD"
                },
                new Currency()
                {
                    Code = "XDR"
                },
                new Currency()
                {
                    Code = "XOF"
                },
                new Currency()
                {
                    Code = "XPF"
                },
                new Currency()
                {
                    Code = "YER"
                },
                new Currency()
                {
                    Code = "ZAR"
                },
                new Currency()
                {
                    Code = "ZMK"
                },
                new Currency()
                {
                    Code = "ZMW"
                },
                new Currency()
                {
                    Code = "ZWL"
                }
            };
            return currencies;
        }
    }
}
