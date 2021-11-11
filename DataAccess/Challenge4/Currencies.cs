using DataAccess.Challenge4.Models;
using DataAccess.Utilities;
using Nubimetrics.MethodParameters;
using System.Data;
using static Nubimetrics.Common.Enums.OperationResults;

namespace DataAccess.Challenge4
{
    public class Currencies
    {
        public SaveBulkCurrenciesOut SaveBulkCurrencies (SaveBulkCurrenciesIn input)
        {
            SaveBulkCurrenciesOut output = new SaveBulkCurrenciesOut() { OperationResult = OperationResult.Success };

            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("CurrencyId");
                table.Columns.Add("Symbol");
                table.Columns.Add("Description");
                table.Columns.Add("DecimalPlace");
                table.Columns.Add("CurrencyBase");
                table.Columns.Add("CurrencyQuote");
                table.Columns.Add("Ratio");
                table.Columns.Add("Rate");
                table.Columns.Add("InvRate");
                table.Columns.Add("CreationDate");
                table.Columns.Add("ValidUntil");
                
                foreach(var currency in input.Currencies)
                {
                    DataRow row = table.NewRow();
                    row["CurrencyId"] = currency.Id;
                    row["Symbol"] = currency.Symbol;
                    row["Description"] = currency.Description;
                    row["DecimalPlace"] = currency.Decimal_places;
                    row["CurrencyBase"] = currency?.Todolar?.Currency_base ?? null;
                    row["CurrencyQuote"] = currency?.Todolar?.Currency_quote ?? null;
                    row["Ratio"] = currency?.Todolar?.Ratio ?? null;
                    row["Rate"] = currency?.Todolar?.Rate ?? null;
                    row["InvRate"] = currency?.Todolar?.Inv_rate ?? null;
                    row["CreationDate"] = currency?.Todolar?.Creation_date ?? null;
                    row["ValidUntil"] = currency?.Todolar?.Valid_until ?? null;

                    table.Rows.Add(row);
                }

                DataContextHelper.ExecuteStoredProcedureWithTableValuedParameters("SaveCurrencies", "CurrenciesTvp", table, "@CurrenciesTvp");
            }
            catch
            {
                output.OperationResult = OperationResult.Error_Generic;
            }

            return output;
        }



        public SaveCurrencyConversionFileCsvOut SaveCurrencyConversionFileCsv(SaveCurrencyConversionFileCsvIn input)
        {
            SaveCurrencyConversionFileCsvOut output = new SaveCurrencyConversionFileCsvOut();

            using (var dataContext = DataContextHelper.GetDataContext<Challenge4DataContext>())
            {
                output.OperationResult = dataContext.SaveCurrenciesConversionFile(input.File) > 0 ? OperationResult.Success : OperationResult.Error_Generic; ;
            }

            return output;
        }
    }
}
