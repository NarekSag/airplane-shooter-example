using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Develop.Runtime.Core.Input
{
    public class MobileInput : MonoBehaviour, IInput
    {
        [SerializeField] FloatingJoystick _floatingJoystick;
        [SerializeField] Button _shootBtn;

        public Vector3 Direction => _floatingJoystick.Direction;

        public IObservable<Unit> ShootClick => _shootBtn.OnClickAsObservable();
    }
}
