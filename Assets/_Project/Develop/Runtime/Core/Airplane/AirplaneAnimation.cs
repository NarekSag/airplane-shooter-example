using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Develop.Runtime.Core.Airplane
{
    public class AirplaneAnimation : MonoBehaviour
    {
        [Header("Engine propellers settings")]
        [Range(10f, 10000f)]
        [SerializeField]
        private float propelSpeedMultiplier = 100f;

        [SerializeField] private GameObject[] propellers;

        [Header("Turbine light settings")]
        [Range(0.1f, 20f)]
        [SerializeField]
        private float turbineLightDefault = 1f;

        [Range(0.1f, 20f)] [SerializeField] private float turbineLightTurbo = 5f;

        [SerializeField] private Light[] turbineLights;

        [Header("Wing trail effects")]
        [Range(0.01f, 1f)]
        [SerializeField]
        private float trailThickness = 0.045f;
        [SerializeField] private TrailRenderer[] wingTrailEffects;

        public void UpdateAnimation(bool isDead, float currentSpeed)
        {
            if (!isDead)
            {
                //Rotate propellers if any
                if (propellers.Length > 0)
                {
                    RotatePropellers(propellers, currentSpeed * propelSpeedMultiplier);
                }

                //Control lights if any
                if (turbineLights.Length > 0)
                {
                    ControlEngineLights(turbineLights, turbineLightDefault, isDead);
                }
            }
            else
            {
                //Rotate propellers if any
                if (propellers.Length > 0)
                {
                    RotatePropellers(propellers, 0f);
                }

                //Control lights if any
                if (turbineLights.Length > 0)
                {
                    ControlEngineLights(turbineLights, 0f, isDead);
                }
            }
        }

        private void RotatePropellers(GameObject[] rotateThese, float speed)
        {
            for (int i = 0; i < rotateThese.Length; i++)
            {
                rotateThese[i].transform.Rotate(Vector3.forward * (-speed * Time.deltaTime));
            }
        }

        private void ControlEngineLights(Light[] lights, float intensity, bool isDead)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                if (!isDead)
                {
                    lights[i].intensity = Mathf.Lerp(lights[i].intensity, intensity, 10f * Time.deltaTime);
                }
                else
                {
                    lights[i].intensity = Mathf.Lerp(lights[i].intensity, 0f, 10f * Time.deltaTime);
                }
            }
        }

/*        private void ChangeWingTrailEffectThickness(float thickness)
        {
            for (int i = 0; i < wingTrailEffects.Length; i++)
            {
                wingTrailEffects[i].startWidth = Mathf.Lerp(wingTrailEffects[i].startWidth, thickness, Time.deltaTime * 10f);
            }
        }*/
    }
}