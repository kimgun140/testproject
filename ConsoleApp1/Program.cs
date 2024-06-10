using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Xml;
namespace ConsoleApp1
{

    internal class Program
    {

        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {




            string url = "http://apis.data.go.kr/B090041/openapi/service/SpcdeInfoService/getAnniversaryInfo?solYear=2015&solMonth=09&_type=json&ServiceKey=tx9B2E92BNv2OKolf8pJbUI1bOsM%2BPNFm%2FHpUVp0KGrnoJKg00dtP23qGaOVQKlF4pQc7Ti%2BH4k5fdRMlY0qIQ%3D%3D"; // URL
            //url += "?ServiceKey=" + "서비스키"; // Service Key
            //url += "&pageNo=1";
            //url += "&numOfRows=10";
            //url += "&solYear=2019";
            //url += "&solMonth=02";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            Console.WriteLine(results);


        }
    }
}

////지하철
////using System;
////using System.Net;
////using System.Net.Http;
////using System.IO;

////namespace ConsoleApp1
////{
////    class Program
////    {
////        static HttpClient client = new HttpClient();
////        static void Main(string[] args)
////        {
////            string url = "http://swopenapi.seoul.go.kr/api/subway/sample/xml/realtimeStationArrival/ALL/1/5/"; // URL
////            url += "?ServiceKey=" + "59664a73456b696d37346d6370664a"; // Service Key
////            url += "TYPE";
////            url += "SERVICE";
////            url += "START_INDEX";
////            url += "END_INDEX";
////            url += "subwayNm";

////            var request = (HttpWebRequest)WebRequest.Create(url);
////            request.Method = "GET";

////            string results = string.Empty;
////            HttpWebResponse response;
////            using (response = request.GetResponse() as HttpWebResponse)
////            {
////                StreamReader reader = new StreamReader(response.GetResponseStream());
////                results = reader.ReadToEnd();
////            }

////            Console.WriteLine(results);
////        }
////    }
////}


//// 천문특일정보 C# 샘플 코드

//using System;
//using System.Net;
//using System.Net.Http;
//using System.IO;
//using System.Xml;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static HttpClient client = new HttpClient();
//        static void Main(string[] args)
//        {
//            //병원
//            string url = "https://apis.data.go.kr/B551182/hospInfoServicev2/getHospBasisList"; // URL
//            url += "?ServiceKey=" + "w32y6sOLnxjnhZxScFSyEkNjXLtNsT4T25bmFBHgUuGO4DebThTIvWwBB+9XZBSSTnki+G0CWKRbYaPVuAHbgg=="; // Service Key
//            url += "&emdongNm=지동";
//            url += "&sidoCd=310000";
//            //url += "&solYear=2019";
//            //url += "&solMonth=02";

//            var request = (HttpWebRequest)WebRequest.Create(url);
//            request.Method = "GET";

//            string results = string.Empty;
//            HttpWebResponse response;
//            using (response = request.GetResponse() as HttpWebResponse)
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream());
//                results = reader.ReadToEnd();
//            }
//            //// Load the XML data into an XmlDocument
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(results);

//            //// Parse the XML data
//            XmlNodeList itemList = doc.GetElementsByTagName("item");

//            foreach (XmlNode item in itemList)
//            {
//                Console.WriteLine(item.OuterXml);
//                //string dateName = item["clCdNm"].InnerText;
//                ////string locdate = item["locdate"].InnerText;
//                //Console.WriteLine($"Date Name: {dateName}");
//            }
//        }
//    }
//}

//using System;
//using System.Net;
//using System.IO;
//using System.Xml;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //휴일
//            string url = "http://apis.data.go.kr/B090041/openapi/service/SpcdeInfoService/getAnniversaryInfo"; // URL
//            url += "?ServiceKey=" + "w32y6sOLnxjnhZxScFSyEkNjXLtNsT4T25bmFBHgUuGO4DebThTIvWwBB%2B9XZBSSTnki%2BG0CWKRbYaPVuAHbgg%3D%3D"; // Service Key
//            //url += "&pageNo=";
//            //url += "&numOfRows=10";
//            url += "&solYear=2019";

//            //url += "&solMonth=02";

//            var request = (HttpWebRequest)WebRequest.Create(url);
//            request.Method = "GET";

//            string results = string.Empty;
//            HttpWebResponse response;
//            using (response = request.GetResponse() as HttpWebResponse)
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream());
//                results = reader.ReadToEnd();
//            }

//            //// Load the XML data into an XmlDocument
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(results);

//            //// Parse the XML data
//            XmlNodeList itemList = doc.GetElementsByTagName("item");

//            foreach (XmlNode item in itemList)
//            {
//                string dateName = item["dateName"].InnerText;
//                string locdate = item["locdate"].InnerText;
//                Console.WriteLine($"Date Name: {dateName}, Date: {locdate}");
//            }
//        }
//    }
//}
