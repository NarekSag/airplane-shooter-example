using Cysharp.Threading.Tasks;
using Develop.Runtime.Core.Target;
using Develop.Runtime.Utilities;
using Develop.Runtime.Utilities.Logging;
using System.Collections.Generic;
using UnityEngine;
using Resources = UnityEngine.Resources;

namespace Develop.Runtime.Core
{
    public class TargetFactory : ILoadUnit
    {
        private Dictionary<string, TargetController> _targetPrefabs;

        UniTask ILoadUnit.Load()
        {
            string[] taretsToLoad = RuntimeConstants.Targets.All;
            _targetPrefabs = new Dictionary<string, TargetController>(taretsToLoad.Length);

            foreach (string targetToLoad in taretsToLoad)
                _targetPrefabs.Add(targetToLoad, Resources.Load<TargetController>($"{RuntimeConstants.Resources.Targets}{targetToLoad}"));
            return UniTask.CompletedTask;
        }

        public TargetController CreateTarget(string targetName, Vector3 position, Quaternion rotation)
        {
            if (!_targetPrefabs.TryGetValue(targetName, out var prefab))
            {
                Log.Core.E($"Target prefab not found: {targetName}");
                return null;
            }

            TargetController target = Object.Instantiate(prefab, position, rotation);
            target.Initialize();

            return target;
        }
    }
}