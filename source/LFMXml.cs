using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace LastFM_Now_Playing
{
    class LFMXml
    {
        public string RecentTracks(string username, bool np)
        {
            string pretext = "Last played: ";
            string xmlStr;
            string nowplaying = "";
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=" + username +"&api_key=5b801a66d1a34e73b6e563afc27ef06b&limit=1");
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            xmlStr = strm.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//name");
            XmlNode node1 = root.SelectSingleNode("//artist");
            XmlNode node2 = root.SelectSingleNode("//track/@nowplaying");
            if (node2 != null)
                if (node2.InnerText == "true")
                    pretext = "Now playing: ";
            if(np)
                nowplaying = pretext + node1.InnerText + " - " + node.InnerText;
            if(!np)
                nowplaying = node1.InnerText + " - " + node.InnerText;
            return nowplaying;
        }

        public string GetSong(string username)
        {
            string xmlStr;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=" + username + "&api_key=5b801a66d1a34e73b6e563afc27ef06b&limit=1");
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            xmlStr = strm.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//name");
            return node.InnerText;
        }

        public string GetArtist(string username)
        {
            string xmlStr;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=" + username + "&api_key=5b801a66d1a34e73b6e563afc27ef06b&limit=1");
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            xmlStr = strm.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//artist");
            return node.InnerText;
        }

        public bool GetNowPlaying(string username)
        {
            string xmlStr;
            HttpWebRequest myHttwebrequest = (HttpWebRequest)HttpWebRequest.Create("http://ws.audioscrobbler.com/2.0/?method=user.getRecentTracks&user=" + username + "&api_key=5b801a66d1a34e73b6e563afc27ef06b&limit=1");
            HttpWebResponse myHttpWebresponse = (HttpWebResponse)myHttwebrequest.GetResponse();
            StreamReader strm = new StreamReader(myHttpWebresponse.GetResponseStream());
            xmlStr = strm.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNode node = root.SelectSingleNode("//track/@nowplaying");
            if (node != null) {
                if (node.InnerText == "true")
                    return true;
                    }
                    if (node == null)
                        return false;         

                    return Convert.ToBoolean(node.InnerText);
        }




    }
}
