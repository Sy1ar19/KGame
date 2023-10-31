using Assets.Scripts.Data;
using Assets.Scripts.Ifrastructure.Services;

namespace Assets.Scripts.Ifrastructure.States
{
    public interface ISavedLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}