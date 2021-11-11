using Nubimetrics.Entities;
using Nubimetrics.MethodParameters;
using Nubimetrics.WSAdapter.MethodParameters;
using Nubimetrics.WSAdapter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WSAdapter.Challenge2
{
    public class ItemsConector
    {
        public SearchByItemOut SearchByItem(SearchByItemIn input)
        {
            SearchByItemOut output = new SearchByItemOut() { OperationResult = OperationResult.Success };

            try
            { 
                Item item = WSAdapterConectorHelper.GetServiceHelper<Item>(new GetServiceIn { Address = "https://api.mercadolibre.com/sites/MLA/search?q=" + input.ItemToSearch });

                if (item != null)
                {
                    output.Item = item;
                }
                else
                {
                    output.OperationResult = OperationResult.Error_NotFound;
                }
            }
            catch
            {
                output.OperationResult = OperationResult.Success;
            }

            return output;
        }
    }
}
