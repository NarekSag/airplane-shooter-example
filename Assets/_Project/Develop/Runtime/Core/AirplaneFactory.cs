using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Develop.Runtime.Core.Airplane;
using Develop.Runtime.Core.Input;
using Develop.Runtime.Core.Shooting;
using Develop.Runtime.Utilities;
using UniRx;
using UnityEngine;
using Resources = UnityEngine.Resources;

namespace Develop.Runtime.Core
{
    public class AirplaneFactory : ILoadUnit
    {
        private readonly ConfigContainer _configs;
        private Dictionary<string, AirplaneController> _prefabs;

        public AirplaneFactory(ConfigContainer configs)
        {
            _configs = configs;
        }

        UniTask ILoadUnit.Load()
        {
            string[] planesToLoad = RuntimeConstants.Airplanes.All;
            _prefabs = new Dictionary<string, AirplaneController>(planesToLoad.Length);

            foreach (string planeToLoad in planesToLoad)
                _prefabs.Add(planeToLoad, Resources.Load<AirplaneController>($"{RuntimeConstants.Resources.Airplanes}{planeToLoad}"));
            return UniTask.CompletedTask;
        }

        public AirplaneController CreatePlayer(string planeName, IInput input)
        {
            AirplaneController player = Object.Instantiate(_prefabs[planeName]);
            player.Initialize(_configs.Core.AirplaneConfig, input);
            return player;
        }
    }
}