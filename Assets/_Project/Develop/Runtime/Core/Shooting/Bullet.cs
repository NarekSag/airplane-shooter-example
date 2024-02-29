using Develop.Runtime.Core.Target;
using UnityEngine;

namespace Develop.Runtime.Core.Shooting
{
    public sealed class Bullet : MonoBehaviour
    {
        private BulletConfig _config;
        private Vector3 _previousPosition;

        public void Initialize(BulletConfig config, LayerMask collideMask)
        {
            _config = config;
            gameObject.layer = collideMask;
            Destroy(gameObject, config.LifeTime);
        }

        private void Start()
        {
            _previousPosition = transform.position;
        }

        void Update()
        {
            RaycastHit hit;
            if (Physics.Linecast(_previousPosition, transform.position, out hit))
            {
                if (hit.collider == null) return;

                if(hit.collider.gameObject.layer == LayerMask.NameToLayer(RuntimeConstants.PhysicLayers.TargetBody))
                {
                    hit.collider.GetComponent<TargetController>()?.OnHit?.Invoke();
                }

                Destroy(gameObject);
            }

            _previousPosition = transform.position;

            transform.position += transform.forward * (_config.Speed * Time.deltaTime);
        }
    }
}