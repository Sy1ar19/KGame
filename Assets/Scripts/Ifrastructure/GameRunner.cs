using UnityEngine;

namespace Assets.Scripts.Ifrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootStrapper _bootStrapperPrefab;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootStrapper>();

            if (bootstrapper == null)
                Instantiate(_bootStrapperPrefab);
        }
    }
}