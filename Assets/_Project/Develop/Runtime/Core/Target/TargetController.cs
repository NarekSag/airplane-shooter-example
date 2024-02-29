using System;
using UniRx;
using UnityEngine;

namespace Develop.Runtime.Core.Target
{
    public class TargetController : MonoBehaviour
    {
        private readonly BoolReactiveProperty _isDead = new(false);

        public BoolReactiveProperty IsDead => _isDead;
        public Action OnHit;

        public virtual void Initialize()
        {
            gameObject.layer = LayerMask.NameToLayer(RuntimeConstants.PhysicLayers.TargetBody);

            OnHit += Hit;
        }

        private void Hit()
        {
            _isDead.Value = true;

            Destroy(gameObject);
        }
    }
}