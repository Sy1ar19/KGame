using System;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class HeroDetector : MonoBehaviour
    {
        public event Action<Collider> HeroDetected;
        public event Action<Collider> HeroUndetected;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("detected");
            HeroDetected?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            HeroUndetected?.Invoke(other);
        }
    }
}