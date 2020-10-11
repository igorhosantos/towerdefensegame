using System.Collections.Generic;
using System.Linq;
using Assets.Script.engine;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField] private WaveConfigScriptableObject waveConfig;
    [SerializeField] private BoardView boardView;
    [SerializeField] private HudView hudView;


    public delegate void GameEvent();
    public static event GameEvent NotifyLose;
    public static event GameEvent NotifyWin;
    public static event GameEvent NotifyStart;

    public delegate void WaveEvent(List<WaveMembers> members, int spawnId);
    public static event WaveEvent NotifyNewWave;

    void Start()
    {
        Invoke(nameof(NextWave),1f);
    }

    private void NextWave()
    {
        NotifyStart?.Invoke();
        var wave = waveConfig.Waves.First();
        NotifyNewWave?.Invoke(wave.Members, wave.RandomSpawn ? Random.Range(1,GameConfig.TotalSpawnPoints) : wave.SpawnId);
    }
}
