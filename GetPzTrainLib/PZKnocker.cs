using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetPzTrainLib
{
    public class PZKnocker
    {
        public const string Address = "http://www.pz.gov.ua/rezerv/aj_g60.php";

        public static JToken SendRequest(string addr, Params p)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(addr);
            req.Method = "POST";
            req.Accept = "application/json, text/javascript, */*";
            
            req.Host = "www.pz.gov.ua";
            req.Referer = "http://www.pz.gov.ua/rezerv/?lid=1&mid=31";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0";
            req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

            string parameters = String.Format("kstotpr={0}&kstprib={1}&sdate={2}", p.From, p.To, p.Date.ToString("dd-MM-yyyy"));
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return JObject.Parse(sr.ReadToEnd().Trim());
        }
    }
}
