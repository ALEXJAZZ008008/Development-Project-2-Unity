using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityStandardAssets.Utility
{
    public class ParticleSystemDestroyer : MonoBehaviour
    {
        // shuts off emission, and waits for all particles to expire
        // before destroying the gameObject

        private float m_MaxLifetime;
        private bool m_EarlyStop;

        private IEnumerator Start()
        {
            var systems = GetComponentsInChildren<ParticleSystem>();

            // find out the maximum lifetime of any particles in this effect
            foreach (var system in systems)
            {
                m_MaxLifetime = Mathf.Max(system.main.startLifetime.constant, m_MaxLifetime);
            }

            while (!m_EarlyStop)
            {
                yield return null;
            }

            Debug.Log("stopping " + name);

            // turn off emission
            foreach (var system in systems)
            {
                var emission = system.emission;

                emission.enabled = false;
            }

            BroadcastMessage("Extinguish", SendMessageOptions.DontRequireReceiver);

            // wait for any remaining particles to expire
            yield return new WaitForSeconds(m_MaxLifetime);

            Destroy(gameObject);
        }


        public void Stop()
        {
            // stops the particle system early
            m_EarlyStop = true;
        }
    }
}