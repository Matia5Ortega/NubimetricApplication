using Newtonsoft.Json;
using Nubimetrics.WSAdapter.MethodParameters;
using System.Collections.Generic;
using System.Net;

namespace Nubimetrics.WSAdapter.Utilities
{
    public static class WSAdapterConectorHelper
    {
        /// <summary>
        /// Download the request resources specified in the address and
        /// return a deserialized JSON to the specified class type
        /// </summary>
        /// <typeparam name="T"> T must be a class</typeparam>
        /// <param name="input"><see cref="GetServiceIn"/></param>
        public static T GetServiceHelper<T>(GetServiceIn input) where T : class
        {
            return JsonConvert.DeserializeObject<T>(new WebClient().DownloadString(input.Address));
        }

        /// <summary>
        /// Download the request resources specified in the address and
        /// return a list of a deserialized JSON to the specified class type
        /// </summary>
        /// <typeparam name="T"> T must be a class</typeparam>
        /// <param name="input"><see cref="GetServiceIn"/></param>
        public static List<T> GetServiceHelperByList<T>(GetServiceIn input) where T : class
        {
            return JsonConvert.DeserializeObject<List<T>>(new WebClient().DownloadString(input.Address));
        }
    }
}
