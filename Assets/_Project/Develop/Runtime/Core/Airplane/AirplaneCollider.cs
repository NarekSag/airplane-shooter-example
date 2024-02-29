using UnityEngine;
using UnityEngine.Serialization;

namespace Develop.Runtime.Core.Airplane
{
    public class AirplaneCollider : MonoBehaviour
    {
        public bool collideSometing;

        [HideInInspector]
        public AirplaneController controller;

        private void OnTriggerEnter(Collider other)
        {
            collideSometing = true;
        }
    }
}