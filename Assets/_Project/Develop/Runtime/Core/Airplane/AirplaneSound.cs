using UnityEngine;
using static Develop.Runtime.Core.Airplane.AirplaneController;

namespace Develop.Runtime.Core.Airplane
{
    public class AirplaneSound : MonoBehaviour
    {
        [Header("Engine sound settings")]
        [SerializeField]
        private AudioSource engineSoundSource;

        [SerializeField] private float maxEngineSound = 1f;

        [SerializeField] private float defaultSoundPitch = 1f;

        [SerializeField] private float turboSoundPitch = 1.5f;

        public void UpdateAudio(bool isDead, AirplaneState airplaneState)
        {
            if (engineSoundSource == null)
                return;

            if (airplaneState == AirplaneState.Flying)
            {
                engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, defaultSoundPitch, 10f * Time.deltaTime);

                if (isDead)
                {
                    engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, 0f, 10f * Time.deltaTime);
                }
                else
                {
                    engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, maxEngineSound, 1f * Time.deltaTime);
                }
            }
            else if (airplaneState == AirplaneState.Landing)
            {
                engineSoundSource.pitch = Mathf.Lerp(engineSoundSource.pitch, defaultSoundPitch, 1f * Time.deltaTime);
                engineSoundSource.volume = Mathf.Lerp(engineSoundSource.volume, 0f, 1f * Time.deltaTime);
            }
        }
    }
}