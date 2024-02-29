using System;
using UniRx;
using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Develop.Runtime.Core.Input
{
    public class KeyboardInput : IInput
    {
        public Vector3 Direction => GetKeyboardDirection();

        private readonly IObservable<Unit> shootClick = Observable.EveryUpdate()
            .Where(_ => UnityInput.GetKeyDown(KeyCode.Space) || UnityInput.GetMouseButtonUp(0)) // Ignore frame count, check input
            .Select(_ => Unit.Default); // Emit Unit on input press

        public IObservable<Unit> ShootClick => shootClick;

        private Vector3 GetKeyboardDirection()
        {
            float horizontal = UnityInput.GetAxis("Horizontal");
            float vertical = UnityInput.GetAxis("Vertical");
            float yawValue = UnityInput.GetKey(KeyCode.Q) ? -1 : (UnityInput.GetKey(KeyCode.E) ? 1 : 0);

            return new Vector3(horizontal, vertical, yawValue);
        }
    }
}

