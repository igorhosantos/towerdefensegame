using System;
using System.Collections.Generic;
using Assets.Script.engine;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "WaveConfig")]
public class WaveConfigScriptableObject : ScriptableObject
{
    [SerializeField] private List<WaveData> waves;
    public List<WaveData> Waves => waves;
}

[Serializable]
public class WaveData
{
    [Header("Wave")]
    [Range(1, GameConfig.TotalSpawnPoints)]
    [SerializeField] private int spawnId;
    [SerializeField] private bool randomSpawn;
    [SerializeField] private float timeDelay;
    [SerializeField] private List<WaveMembers> members;

    public List<WaveMembers> Members => members;
    public bool RandomSpawn  => randomSpawn;
    public int SpawnId => spawnId;
    public float TimeDelay => timeDelay;
}

[Serializable]
public class WaveMembers
{
    [Header("Member")]
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private int amount;

    public EnemyType EnemyType => enemyType;
    public int Amount => amount;
}

