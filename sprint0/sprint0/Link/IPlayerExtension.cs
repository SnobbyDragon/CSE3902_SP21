using System;
namespace sprint0
{
    public static class IPlayerExtension
    {
        public static bool IsIdle(this IPlayer player)
            => player.State is UpIdleState || player.State is DownIdleState || player.State is LeftIdleState || player.State is RightIdleState;

        public static bool IsWalking(this IPlayer player)
            => player.State is UpWalkingState || player.State is DownWalkingState || player.State is LeftWalkingState || player.State is RightWalkingState;

        public static bool IsSword(this IPlayer player)
            => player.State is UpWoodSwordState || player.State is DownWoodSwordState || player.State is LeftWoodSwordState || player.State is RightWoodSwordState;

        public static bool IsJumping(this IPlayer player)
            => player.State is UpJumpingState || player.State is DownJumpingState || player.State is LeftJumpingState || player.State is RightJumpingState;
    }
}
