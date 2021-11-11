using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;

using static Nubimetrics.Common.Enums.OperationResults;

namespace BusinessComponents.Challenge1
{
    public class Countries
    {
        public CountryOut GetCountryByCountryId(CountryIn input)
        {
            CountryOut output = new CountryOut() { OperationResult = OperationResult.Error_Generic };

            if(!string.IsNullOrEmpty(input?.CountryId))
            {
                switch (input.CountryId)
                {
                    case "BR":
                    case "CO":
                        output.OperationResult = OperationResult.Error_Unauthorized;
                        output.OperationResultMessage = Resources.ErrorMessage.Error_Unauthorized;
                        break;
                    case "AR":
                    {
                        output = CachingClassFactory.GetOrCreate<Nubimetrics.WSAdapter.Challenge1.CountriesConector>().GetCountryByCountryId(input);
                        break;
                    }
                    default:
                    {
                        output = CachingClassFactory.GetOrCreate<DataAccess.Challenge1.Countries>().GetCountryByCountryId(input);
                        break;
                    }
                }
            }

            return output;
        }
    }
}
