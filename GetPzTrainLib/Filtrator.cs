using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPzTrainLib
{
    public static class Filtrator
    {
        public static IEnumerable<JToken> HaveTrains(this JToken jo, Params p)
        {
            JToken jtrains = jo["trains"];
            if (jtrains == null) return null;

            IEnumerable<JToken> result = (from jt in jtrains
                                         where (int.Parse(jt.Value<string>("prib").Substring(0,2)) <= p.MaxArriveTime && jt.Value<int>("p") >= p.MinTicketsCount)
                                         select jt).ToList();
            return result;
        }
    }
}
