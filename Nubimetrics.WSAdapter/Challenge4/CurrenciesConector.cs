using Nubimetrics.Entities;
using Nubimetrics.MethodParameters;
using Nubimetrics.WSAdapter.MethodParameters;
using Nubimetrics.WSAdapter.Utilities;
using System;
using System.Collections.Generic;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WSAdapter.Challenge4
{
    public class CurrenciesConector
    {
        public SaveCurrenciesOut GetCurrencies(SaveCurrenciesIn input)
        {
            SaveCurrenciesOut output = new SaveCurrenciesOut() { OperationResult = OperationResult.Success };

            try
            {
                List<Currencies> currencies = WSAdapterConectorHelper.GetServiceHelperByList<Currencies>(new GetServiceIn { Address = "https://api.mercadolibre.com/currencies" });

                if (currencies != null)
                {
                    foreach(var currency in currencies)
                    {
                        currency.Todolar = GetCurrencyConversionByCurrencyId(currency.Id);
                    }

                    output.Currencies = currencies;
                }
                else
                {
                    output.OperationResult = OperationResult.Error_NotFound;
                }
            }
            catch
            {
                output.OperationResult = OperationResult.Error_Generic;
            }

            return output;
        }

        #region Helper

        /// <summary>
        /// Returns the conversion of the specified currencies
        /// </summary>
        /// <param name="currencyIdFrom"></param>
        /// <param name="currencyIdTo">Default USD</param>

        public CurrencyConversion GetCurrencyConversionByCurrencyId(string currencyIdFrom, string currencyIdTo = "USD")
        {
            CurrencyConversion result;

            try
            {
                result = WSAdapterConectorHelper.GetServiceHelper<CurrencyConversion>(new GetServiceIn() { Address = "https://api.mercadolibre.com/currency_conversions/search?from=" + currencyIdFrom + "&to=" + currencyIdTo });
            }
            catch
            {
                result = new CurrencyConversion();
            }

            return result;
        }

        #endregion
    }
}
