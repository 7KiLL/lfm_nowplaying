using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastFM_Now_Playing
{

    class NowPlaying
    {
        LFMXml lfm = new LFMXml();
        public string Generate(string username, string divider, bool reverse, bool np, string nowp, string lastp, bool fill)
        {
            string Song = lfm.GetSong(username);
            string Artist = lfm.GetArtist(username);
            bool npStatus = lfm.GetNowPlaying(username);
            string Divider = divider;
            string npPrefix = nowp;
            string lpPrefix = lastp;
            string NPString = "";
            if(!np) { 
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
