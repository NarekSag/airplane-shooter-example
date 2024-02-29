using Develop.Runtime.Utilities;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Develop.Runtime.Bootstrap
{
    public class ApplicationConfigurationLoadUnit : ILoadUnit
    {
        public UniTask Load()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
            return UniTask.CompletedTask;
        }
    }
}