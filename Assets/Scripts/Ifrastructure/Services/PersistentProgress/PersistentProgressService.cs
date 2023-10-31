using Assets.Scripts.Data;
using Assets.Scripts.Ifrastructure.Services.PersistentProgress;

public class PersistentProgressService : IPersistentProgressService
{
    public PlayerProgress Progress { get; set; }
}