using GetPzTrainLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetPzTrainTest
{
    [TestClass]
    class Tests
    {
        [TestMethod]
        public void SendRequest()
        {
            Params p = new Params() { MaxArriveTime=12, MinTicketsCount=1, To=2200001, From=2210704, Date=DateTime.Parse("30.04.13") };
            JToken j = PZKnocker.SendRequest(PZKnocker.Address, p);
            Assert.IsNotNull(j);
        }

        public void FilterRequest()
        {
            Params p = new Params() { MaxArriveTime = 12, MinTicketsCount = 1, To = 2200001, From = 2210704, Date = DateTime.Parse("30.04.13") };
            JToken j = PZKnocker.SendRequest(PZKnocker.Address, p);
            var jj = Filtrator.HaveTrains(j, p);
            Assert.IsNotNull(jj);
        }
    }
}
