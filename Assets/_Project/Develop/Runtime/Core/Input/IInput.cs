using System;
using UniRx;
using UnityEngine;


namespace Develop.Runtime.Core.Input
{
    public interface IInput
    {
        Vector3 Direction { get; }
        public IObservable<Unit> ShootClick { get; }
    }
}
