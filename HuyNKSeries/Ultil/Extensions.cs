using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace HuyNKSeries.Ultil
{
    public static class Extensions
    {
        private const string E_BUFF_NAME = "KalistaExpungeMarker";

        public static bool HasRendBuff(this Obj_AI_Base target)
        {
            return target.HasBuff(E_BUFF_NAME);
        }

        public static BuffInstance GetRendBuff(this Obj_AI_Base target)
        {
            return target.Buffs.FirstOrDefault(b => b.DisplayName == E_BUFF_NAME);
        }
    }
}
