using Assets.Scripts.Data;

namespace Assets.Scripts.Ifrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}