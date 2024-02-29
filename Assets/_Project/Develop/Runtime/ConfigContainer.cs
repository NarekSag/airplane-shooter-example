using System;
using Cysharp.Threading.Tasks;
using Develop.Runtime.Utilities;
using UnityEngine;

namespace Develop.Runtime
{
    public sealed class ConfigContainer : ILoadUnit
    {
        public CoreConfigContainer Core;

        public UniTask Load()
        {
            var asset = AssetService.R.Load<TextAsset>(RuntimeConstants.Configs.ConfigFileName);
            JsonUtility.FromJsonOverwrite(asset.text, this);
            return UniTask.CompletedTask;
        }
    }

    [Serializable]
    public class CoreConfigContainer
    {
        public AirplaneConfig AirplaneConfig;
        //public JoystickConfig JoystickConfig;
    }

    [Serializable]
    public class AirplaneConfig
    {
        public float Responsiveness;
        public BulletConfig Bullet;
    }

    [Serializable]
    public class BulletConfig
    {
        public float Speed;
        public float LifeTime;
    }

    [Serializable]
    public sealed class JoystickConfig
    {
        public float HandleOffsetActivation;
        public float JoystickJitter;
    }
}