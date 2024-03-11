using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Develop.Runtime.Core.Airplane;
using Develop.Runtime.Core.Input;
using Develop.Runtime.Utilities;
using UnityEngine;
using Resources = UnityEngine.Resources;

namespace Develop.Runtime.Core
{
    public class AirplaneFactory : ILoadUnit
    {
        private readonly ConfigContainer _configs;
        private Dictionary<string, AirplaneController> _prefabs;

        private MobileInput _mobileInput;

        public AirplaneFactory(ConfigContainer configs, MobileInput mobileInput)
        {
            _configs = configs;
            _mobileInput = mobileInput;
        }

        UniTask ILoadUnit.Load()
        {
            string[] planesToLoad = RuntimeConstants.Airplanes.All;
            _prefabs = new Dictionary<string, AirplaneController>(planesToLoad.Length);

            foreach (string planeToLoad in planesToLoad)
                _prefabs.Add(planeToLoad, Resources.Load<AirplaneController>($"{RuntimeConstants.Resources.Airplanes}{planeToLoad}"));
            return UniTask.CompletedTask;
        }

        public AirplaneController CreatePlayer(string planeName)
        {
            AirplaneController player = Object.Instantiate(_prefabs[planeName]);
            player.Initialize(_configs.Core.AirplaneConfig, GetPlayerInput());
            return player;
        }

        private IInput GetPlayerInput()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _mobileInput.gameObject.SetActive(false);
            return new KeyboardInput();
#elif UNITY_IOS || UNITY_ANDROID
            return _mobileInput;
#endif
        }
    }
}