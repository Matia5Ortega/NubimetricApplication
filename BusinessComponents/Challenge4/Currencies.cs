using Nubimetrics.Common.Utilities;
using Nubimetrics.Entities;
using Nubimetrics.MethodParameters;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using static Nubimetrics.Common.Enums.OperationResults;

namespace BusinessComponents.Challenge4
{
    public class Currencies
    {
        public SaveCurrenciesOut SaveCurrencies ( SaveCurrenciesIn input)
        {
            SaveCurrenciesOut output = new SaveCurrenciesOut() { OperationResult = OperationResult.Error_Generic };

            var currencies = CachingClassFactory.GetOrCreate<Nubimetrics.WSAdapter.Challenge4.CurrenciesConector>().GetCurrencies(input);

            if (currencies?.Currencies != null && currencies.Currencies.Any())
            {
                var saveBulkCurrencies = CachingClassFactory.GetOrCreate<DataAccess.Challenge4.Currencies>().SaveBulkCurrencies(new SaveBulkCurrenciesIn() { Currencies = currencies.Currencies });

                if (saveBulkCurrencies?.OperationResult == OperationResult.Success)
                {
                    List<CurrencyConversion> currencyConversionsList = currencies.Currencies.Select(x => x.Todolar)?.ToList();

                    CreateFileCsvOut createFileCsv = CreateFileCsv(new CreateFileCsvIn() { CurrencyConversions = currencyConversionsList });

                    if(createFileCsv.OperationResult == OperationResult.Success)
                    {
                        var saveCurrencyConversionFile = CachingClassFactory.GetOrCreate<DataAccess.Challenge4.Currencies>().SaveCurrencyConversionFileCsv(new SaveCurrencyConversionFileCsvIn()
                        {
                            File = createFileCsv.File
                        });

                        output.OperationResult = saveCurrencyConversionFile.OperationResult;
                    }
                }
            }

            return output;
        }

        #region Helper
        /// <summary>
        /// Create and return a csv file from currency ratio
        /// </summary>
        /// <param name="input"><see cref="CreateFileCsvIn"/></param>

        public CreateFileCsvOut CreateFileCsv(CreateFileCsvIn input)
        {
            CreateFileCsvOut output = new CreateFileCsvOut() { OperationResult = OperationResult.Error_Generic };

            StringBuilder file = new StringBuilder();

            foreach(var currency in input.CurrencyConversions)
            {
                if(currency.Ratio != null)
                {
                    file.AppendFormat(CultureInfo.InvariantCulture, "\"{0}\"", currency.Ratio.ToString());
                    file.Append(',');
                }
            }

            if(file.Length > 0)
            {
                output.File = file.ToString();
                output.OperationResult = OperationResult.Success;
            }

            return output;
        }
        #endregion
    }
}
