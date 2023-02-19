using System;
using UnityEngine;

namespace App.View.Mono.Particles
{
    public class ParticleSystemStoppedEventNotifier: MonoBehaviour
    {
        public event Action ParticleSystemSopped;

        private void OnParticleSystemStopped()
        {
            ParticleSystemSopped?.Invoke();
        }
    }
}