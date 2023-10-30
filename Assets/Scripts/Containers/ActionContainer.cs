using System;
using Utilities;

namespace Containers
{
    public class ActionContainer
    {
        public static Action OnShoot;
        public static Action OnReload;
        public static Action OnReloadEnd;
        public static Action<ModsEnum> OnModeChanged;
        public static Action OnHittingTheTarget;
        public static Action OnTimeOut;
        public static Action OnReset;
        public static Action<float> OnDifficultyChange;
    }
}
