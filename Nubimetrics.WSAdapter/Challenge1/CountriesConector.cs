using Nubimetrics.Common.Utilities;
using Nubimetrics.Entities;
using Nubimetrics.MethodParameters;
using Nubimetrics.WSAdapter.MethodParameters;
using Nubimetrics.WSAdapter.Utilities;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WSAdapter.Challenge1
{
    public class CountriesConector
    {
        public CountryOut GetCountryByCountryId(CountryIn input)
        {
            CountryOut output = new CountryOut() { OperationResult = OperationResult.Success };

            try
            {
                Country country = WSAdapterConectorHelper.GetServiceHelper<Country>(new GetServiceIn { Address = "https://api.mercadolibre.com/classified_locations/countries/" + input.CountryId });

                if (country != null)
                {
                    output.Country = country;
                    output.OperationResultMessage = Resources.SuccessMessage.Success;
                }
                else
                {
                    output.OperationResult = OperationResult.Error_NotFound;
                    output.OperationResultMessage = Resources.ErrorMessage.Error_NotFound;
                }
            }
            catch
            {
                output.OperationResult = OperationResult.Error_Generic;
                output.OperationResultMessage = Resources.ErrorMessage.Error_Generic;
            }

            return output;
        }
    }
}
