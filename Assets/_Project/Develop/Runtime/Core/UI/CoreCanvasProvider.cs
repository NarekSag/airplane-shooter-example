using System;
using Develop.Runtime.Utilities;
using UniRx;
using UnityEngine;
using VContainer;

namespace Develop.Runtime.Core.UI
{
    [RequireComponent(typeof(Canvas))]
    public sealed class CoreCanvasProvider : MonoBehaviour
    {
        public Canvas Canvas;
        public RectTransform CanvasRect => (RectTransform)Canvas.transform;
        public RectTransform SafeContainer;

        private IDisposable _disposable;

        [Inject]
        [UnityEngine.Scripting.Preserve]
        public void Inject(OrientationHelper orientationHelper)
        {
            _disposable = orientationHelper.OrientationChanged.Subscribe(o => FitSafeContainer());
        }

        public void FitSafeContainer()
        {
            SafeContainer.FitInSafeArea();
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }
}