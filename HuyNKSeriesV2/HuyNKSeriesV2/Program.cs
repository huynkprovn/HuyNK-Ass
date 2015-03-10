using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp.Common;

namespace HuyNKSeriesV2
{
    /// <summary>
    //Không được chỉnh sửa bất cứ dòng nào trong đây
    /// </summary>
    class Program
    {
       
            static void Main(string[] args)
            {
                CustomEvents.Game.OnGameLoad += LoadTuong;

            }
         
            static void LoadTuong(EventArgs args)
            {
                Tuong champ = new Tuong(true);
            }
        
    }
}
