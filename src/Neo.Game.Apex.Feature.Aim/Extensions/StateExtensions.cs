using Neo.Game.Apex.Core;
using Neo.Game.Apex.Core.Models;
using Neo.Game.Apex.Feature.Aim.Enums;
using Neo.Game.Apex.Feature.Aim.Interfaces;
using Neo.Game.Apex.Feature.Aim.Models;

namespace Neo.Game.Apex.Feature.Aim.Extensions
{
    public static class StateExtensions
    {
        #region Statics

        public static TargetType GetTargetType(this State state, Player localPlayer)
        {
            if (localPlayer.BleedoutState != 0)
            {
                return TargetType.None;
            }

            //if (state.Buttons.InSpeed != 0)
            //{
            //    return TargetType.All;
            //}

            if (state.Buttons.InAttack != 0 && (state.Buttons.InZoom != 0 || localPlayer.VecPunchWeaponAngle.X != 0 || localPlayer.VecPunchWeaponAngle.Y != 0))
            {
                return TargetType.Enemy;
            }

            return TargetType.None;
        }

        public static IEnumerable<ITarget> IterateTargets(this State state)
        {
            foreach (var (_, npc) in state.Npcs)
            {
                yield return new NpcTarget(npc);
            }

            foreach (var (_, player) in state.Players)
            {
                yield return new PlayerTarget(player);
            }
        }

        #endregion
    }
}