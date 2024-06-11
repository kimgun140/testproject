
//using System;
//using System.Net;
//using System.Net.Http;
//using System.IO;
//using System.Xml;
//using Newtonsoft.Json.Linq;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static HttpClient client = new HttpClient();
//        static void Main(string[] args)
//        {
//            //서울시 지하철 실시간 도착정보(일괄) (xml로 파싱한거) https://www.data.go.kr/data/15125683/openapi.do
//            string url = "http://swopenAPI.seoul.go.kr/api/subway/645a445a4575687637335151626c53/xml/realtimePosition/0/5/1호선"; // URL
//            //url += "0/";
//            //url += "5/";
//            //url += "1호선";
//            var request = (HttpWebRequest)WebRequest.Create(url);
//            request.Method = "GET";

//            string results = string.Empty;
//            HttpWebResponse response;
//            using (response = request.GetResponse() as HttpWebResponse)
//            {
//                StreamReader reader = new StreamReader(response.GetResponseStream());
//                results = reader.ReadToEnd();
//            }

//            //Console.WriteLine(results);
//            //// Load the XML data into an XmlDocument
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(results);

//            //// Parse the XML data
//            XmlNodeList itemList = doc.GetElementsByTagName("row");

//            foreach (XmlNode item in itemList)
//            {
//                string subwayNm = item["statnNm"]?.InnerText;
//                if (!string.IsNullOrEmpty(subwayNm))
//                {
//                    Console.WriteLine($"Subway Name: {subwayNm}");
//                }
//                else
//                {
//                    Console.WriteLine("Subway Name not found in the item.");
//                }
//            }

//        }
//    }
//}


//using System;
//using System.Net.Http;
//using Newtonsoft.Json.Linq;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace ConsoleApp1
//{
//    class Program
//    {
//        static readonly HttpClient client = new HttpClient();

//        static async Task Main(string[] args)
//        {
//            //서울시 지하철 실시간 도착정보(일괄) (json으로 파싱한거)https://www.data.go.kr/data/15125683/openapi.do
//            string url = "http://swopenAPI.seoul.go.kr/api/subway/645a445a4575687637335151626c53/json/realtimePosition/";
//            url += "0/";
//            url += "5/";
//            url += "1호선";
//            // API에 HTTP GET 요청을 보내고 응답을 받음
//            HttpResponseMessage response = await client.GetAsync(url);

//            // 응답이 성공적인지 확인
//            if (response.IsSuccessStatusCode)
//            {
//                // JSON 형식의 응답 데이터를 문자열로 읽어옴
//                string jsonString = await response.Content.ReadAsStringAsync();

//                // 문자열로 읽어온 JSON 데이터를 JObject로 파싱
//                JObject jObject = JObject.Parse(jsonString);

//                Console.WriteLine(jObject["realtimePositionList"]); //다뽑기

//                // 파싱된 데이터에서 recptnDt 필드 값만 추출하여 출력 
//                //JArray realtimePositionList = (JArray)jObject["realtimePositionList"];

//                //foreach (JObject item in realtimePositionList)
//                //{
//                //    Console.WriteLine(item["recptnDt"]);
//                //}
//            }
//            else
//            {
//                // 응답이 실패한 경우 오류 메시지 출력
//                Console.WriteLine("Failed to retrieve subway position data.");
//            }
//        }
//    }
//}

using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        //class aaaaa
        //{
        //    public string realtimeposition { get; set; }
        //    public result result { get; set; }
        //    public Row row { get; set; }
        //}
        //class result
        //{
        //    public string code { get; set; }
        //    public string developermessage { get; set; }
        //    public string link { get; set; }

        //    public string message { get; set; }
        //    public int total { get; set; }
        //}
        //class Row
        //{
        //   public int rownum { get; set; }
        //    public int selectedcount { get; set; }
        //    public int totalcount { get; set; }
        //    public int subwayid { get; set; }
        //    public string subwaynm { get; set; }
        //    public string statnid { get; set; }

        //}



        public class Realtimeposition
        {
            public Result result { get; set; }
            public List<Row> row { get; set; }
        }

        public class Result
        {
            public string code { get; set; }
            public string developermessage { get; set; }
            public string link { get; set; }
            public string message { get; set; }
            public int status { get; set; }
            public int total { get; set; }
        }

        public class Row
        {
            public int rownum { get; set; } // 몇번째 줄인지
            public int selectedcount { get; set; } //몇개 출력할건지
            public int totalcount { get; set; } // 현재 운행중인 열차 수 
            public int subwayId { get; set; }// 지하철 호선 id 
            public string subwaynm { get; set; } // 지하철호선명
            public int statnid { get; set; }// 지하철역 id 
            public string statnnm { get; set; } // 지하철역명
            public int trainno { get; set; } // 열차번호
            public int lastrecptndt { get; set; } // 최종수신날짜 
            public string recptnDt { get; set; } // 최종수신 시간
            public int updnline { get; set; }// 상하행선구분
            public int statntid { get; set; }// 종착지하철역id
            public string statntnm { get; set; } // 종착 지하철역명
            public int trainsttus { get; set; }//   열차 상태 구분  0진입 1도착 2출발 3전역출발
            public int directat { get; set; }// 급행여부
            public int lstcarat { get; set; }// 막차여부 
        }





        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            //서울시 지하철 실시간 열차 위치정보 (json으로 파싱한거) https://www.data.go.kr/data/15058569/openapi.do
            string url = "http://swopenapi.seoul.go.kr/api/subway/65724277537568763738636a587a61/json/realtimePosition/";
            url += "0/";
            url += "100/";
            url += "1호선";
            // API에 HTTP GET 요청을 보내고 응답을 받음
            HttpResponseMessage response = await client.GetAsync(url);

            // 응답이 성공적인지 확인
            if (response.IsSuccessStatusCode)
            {
                // JSON 형식의 응답 데이터를 문자열로 읽어옴
                string jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(response.GetType());
                // 문자열로 읽어온 JSON 데이터를 JObject로 파싱
                JObject jObject = JObject.Parse(jsonString);
                Console.WriteLine(jObject.GetType());
                //Console.WriteLine(jObject["realtimePositionList"]); //다뽑기

                // 파싱된 데이터에서 recptnDt 필드 값만 추출하여 출력
                JArray realtimePositionList = (JArray)jObject["realtimePositionList"];
                Realtimeposition realtimeposition = new Realtimeposition();
                realtimeposition.row = new List<Row>();
                Row rowasdf = new Row();
                //realtimeposition = JsonSerializer.Deserialize<Realtimeposition>(jsonString);
                foreach (JObject item in realtimePositionList)
                {
                    //row.rownum  = (int)item["rownum"];
                    //row.selectedcount = (int)item["selectedcount"];
                    //rowasdf.recptndt = (string)item["recptnDt"];
                    //rowasdf.subwayid = (int)item["subwayId"];
                    //rowasdf.subwaynm = (string)item["subwayNm"];
                    //rowasdf.
                    //realtimeposition.row.Add(rowasdf);




                    //Console.WriteLine(item["recptnDt"]);
                    //Row row = new Row();
                    //Console.WriteLine(item["lstcarAt"].Type);
                    //row.recptndt = (string)item["lstcarAt"];
                    //Console.WriteLine(row.recptndt);
                }
                Console.WriteLine(realtimeposition.row[0].recptnDt);
                Console.WriteLine(realtimeposition.row[0].subwayId);
                //Console.WriteLine(realtimeposition.row[0].subwaynm);

                //Console.WriteLine(realtimeposition.row[2].recptndt);

            }
            else
            {
                // 응답이 실패한 경우 오류 메시지 출력
                Console.WriteLine("Failed to retrieve subway position data.");
            }
        }
    }
}

//(서울특별시_버스 위치정보조회 서비스)
//https://www.data.go.kr/data/15000332/openapi.do

//(서울특별시_버스 도착정보조회 서비스)
//https://www.data.go.kr/data/15000314/openapi.do


//역직렬화를 거쳐야함.
//JsonConvert.DeserializeObject() <- 사용되는 메소드








