using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(HeroDetector))]
    [RequireComponent(typeof(AgentMoveToHero))]
    public class Aggro : MonoBehaviour
    {
        private HeroDetector _heroDetecter;
        private AgentMoveToHero _agent;

        private void Awake()
        {
            _heroDetecter = GetComponent<HeroDetector>();
            _agent = GetComponent<AgentMoveToHero>();

            _heroDetecter.HeroDetected += OnHeroDetected;
            _heroDetecter.HeroUndetected += OnHeroUndetected;

            _agent.enabled = false;
        }

        private void Start()
        {

        }

        private void OnHeroUndetected(Collider obj) => 
            _agent.enabled = false;

        private void OnHeroDetected(Collider obj)
        {
            Debug.Log("test");
            _agent.enabled = true;
        }
    }
}