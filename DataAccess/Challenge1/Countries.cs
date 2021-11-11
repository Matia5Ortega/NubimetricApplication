using DataAccess.Challenge1.Models;
using DataAccess.Utilities;
using Nubimetrics.Common.Utilities;
using Nubimetrics.Entities;
using Nubimetrics.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nubimetrics.Common.Enums.OperationResults;

namespace DataAccess.Challenge1
{
    public class Countries
    {
        public CountryOut GetCountryByCountryId(CountryIn input)
        {
            CountryOut output = new CountryOut() { OperationResult = OperationResult.Error_Generic };

            using (var dataContext = DataContextHelper.GetDataContext<Challenge1DataContext>())
            {
                var country = dataContext.GetCountryByCountryId(input.CountryId)?.FirstOrDefault();

                if(country != null)
                {
                    output.Country = new Country()
                    {
                        Id = country.CountryId,
                        Currency_id = country.CurrencyId,
                        Locale = country.Locale,
                        Name = country.Name
                    };

                    output.OperationResult = OperationResult.Success;
                    output.OperationResultMessage = Resources.SuccessMessage.Success;
                }
                else
                {
                    output.OperationResult = OperationResult.Error_NotFound;
                    output.OperationResultMessage = Resources.ErrorMessage.Error_NotFound;
                }
            }

            return output;
        }
    }
}
