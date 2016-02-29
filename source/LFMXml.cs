using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.IO;


namespace LastFM_Now_Playing
{

    internal class LFMXml
    {
        public static Dictionary<string, string> _xml;
        public static string API_KEY
        {
            get { return "&api_key=59c75ce54be869532e03f89b19edd849"; }
        }

        public static Dictionary<string, string> Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }

        public void  GetXML(string username)
        {
            string xmlStr;
            Dictionary<string, string> Track = new Dictionary<string, string>();
            var myHttwebrequest =
                (HttpWebRequest)
                    HttpWebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=" +
                                          username + API_KEY + "&limit=1");
            var myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            var strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            xmlStr = strm.ReadToEnd();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNode root = xmlDoc.DocumentElement;
            Track.Add("Song", root.SelectSingleNode("//name").InnerText);
            Track.Add("Artist", root.SelectSingleNode("//artist").InnerText);
            if (root.SelectSingleNode("//track/@nowplaying") != null)       
                Track.Add("NowPlaying", root.SelectSingleNode("//track/@nowplaying").InnerText);
            else
                Track.Add("NowPlaying", "false");
            Xml = Track;
        }

    }
}

