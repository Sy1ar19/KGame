using Assets.Scripts.Ifrastructure.Factory;
using Assets.Scripts.Ifrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToHero : MonoBehaviour
    {
        private const float MinimumDistance = 1;

        private NavMeshAgent _navMeshAgent;
        private Transform _heroTransform;
        private IGameFactory _gameFactory;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_heroTransform != null && _gameFactory.HeroGameObject != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += OnHeroCreated;
        }

        private void Update()
        {
            if (HeroNotReached())
                _navMeshAgent.destination = _heroTransform.position;
        }

        private void OnHeroCreated() =>
            InitializeHeroTransform();

        private void InitializeHeroTransform() =>
            _heroTransform = _gameFactory.HeroGameObject.transform;

        private bool HeroNotReached() =>
            _heroTransform != null && Vector3.Distance(_navMeshAgent.transform.position, _heroTransform.position) >= MinimumDistance;
    }
}