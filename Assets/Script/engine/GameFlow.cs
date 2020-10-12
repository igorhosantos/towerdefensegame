using System.Collections;
using System.Collections.Generic;
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


    //game finish control 
    private int totalEnemies;
    private int enemiesKilled;

    void Start()
    {
        NotifyStart?.Invoke();
        waveConfig.Waves.ForEach(SetWave);
    }

    private void SetWave(WaveData wv)=> StartCoroutine(NextWave(wv));
    
    private IEnumerator NextWave(WaveData wave)
    {
        yield return new WaitForSeconds(wave.TimeDelay);
        NotifyNewWave?.Invoke(wave.Members, wave.RandomSpawn ? Random.Range(1,GameConfig.TotalSpawnPoints) : wave.SpawnId);
    }
}
