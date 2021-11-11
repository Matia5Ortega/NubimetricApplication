using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;
using Nubimetrics.WSAdapter.Challenge2;

namespace BusinessComponents.Challenge2
{
    public class Items
    {
        public SearchByItemOut SearchByItem (SearchByItemIn input)
        {
            return CachingClassFactory.GetOrCreate<ItemsConector>().SearchByItem(input);
        }
    }
}
