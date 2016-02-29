using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastFM_Now_Playing
{

    class NowPlaying : LFMXml
    {
        //"Controll" class. Operating with variables to make your own string
        
        /// <summary>
        /// Returns "Now playing" string
        /// </summary>
        /// <param name="username">Last FM username. Using to get XML and parse it.</param>
        /// <param name="divider">Character which divide Song and Artist</param>
        /// <param name="reverse">Change standart formant ARTIST-SONG to SONG-ARTIST</param>
        /// <param name="np">Tells to method add or not add prefix</param>
        /// <param name="nowp">Prefix when "nowplaying" attribute = true(currently playing)</param>
        /// <param name="lastp">Prefix when "nowplaying" attribute = false(currently not playing)</param>
        /// <param name="fill">When "nowplaying"=false, You can use prefix as ready string</param>
        /// <returns></returns>
        public string Generate(string username)
        {
            GetXML(username);
            var Song = _xml["Song"];
            var Artist = _xml["Artist"];
            var npStatus = Convert.ToBoolean(_xml["NowPlaying"]);
            var Divider = Properties.Settings.Default.divider;
            var npPrefix = Properties.Settings.Default.nowplayingtext;
            var lpPrefix = Properties.Settings.Default.lastplayedtext;
            var reverse = Properties.Settings.Default.reverse;
            var fill = Properties.Settings.Default.fill;
            var NPString = "";
            var np = Properties.Settings.Default.np;
            if (!np) { 
                if (reverse)
                        NPString = Song + Divider + Artist;         
                if (!reverse)  
                    NPString = Artist + Divider + Song;                
            }

            if(np)
            {
                if (reverse)
                {
                    if(npStatus)
                        NPString = npPrefix + Song + Divider + Artist;
                    if(!npStatus&&!fill)
                        NPString = lpPrefix + Song + Divider + Artist;
                    if (!npStatus && fill)
                        NPString = lpPrefix;
                }
                if (!reverse)
                {
                    if (npStatus)
                        NPString = npPrefix + Artist + Divider + Song;
                    if(!npStatus)
                        NPString = lpPrefix + Artist + Divider + Song;
                    if (!npStatus && fill)
                        NPString = lpPrefix;
                }
            }
            return NPString;
        }
    }
}
