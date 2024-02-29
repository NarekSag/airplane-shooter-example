using UnityEngine.SceneManagement;

namespace Develop.Runtime
{
    public static class RuntimeConstants
    {
        public static class Scenes
        {
            public static readonly int Bootstrap = SceneUtility.GetBuildIndexByScenePath("0.Bootstrap");
            public static readonly int Loading = SceneUtility.GetBuildIndexByScenePath("1.Loading");
            public static readonly int Core = SceneUtility.GetBuildIndexByScenePath("2.Core");
        }

        public static class Configs
        {
            public const string ConfigFileName = "Config";
        }

        public static class Airplanes
        {
            public const string Corncob = "corncob";

            public static readonly string[] All = { Corncob };
        }

        public static class Targets
        {
            public const string HotAirBalloon = "hot_air_balloon";

            public static readonly string[] All = { HotAirBalloon };
        }

        public static class PhysicLayers
        {
            public const string PlayerBody = "player_body";
            public const string PlayerBullet = "player_bullet";
            public const string TargetBody = "target_body";
        }

        public static class Bullets
        {
            public const string UniversalBullet = "universal_bullet";
        }

        public static class Resources
        {
            public const string Airplanes = "Airplanes/";
            public const string Bullets = "Bullets/";
            public const string Targets = "Targets/";
        }
    }
}