using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IPause
{
    LevelParamerter _prameter = new LevelParamerter();
    EnemyLevelUpControlle _levelData = new EnemyLevelUpControlle();
    [SerializeField,Header("生成場所")]Transform[] _spawnPos;
    [SerializeField] CreateObject _createObject; 
    [SerializeField] Transform _player;
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField, Header("生成のインターバル")] float _interval;
    [SerializeField, Header("EnemyLevelUpTime")] float _levelUpTime;
    float _timer;
    float _levelUpTimer;
    [SerializeField]bool _isPause;
    // Start is called before the first frame update
    void Start()
    {
        _levelData = FindObjectOfType<EnemyLevelUpControlle>();
        _prameter = _levelData.LevelSet();
        for (int i = 0; i < _spawnPos.Length; i++)
        {
            for(int j = 0; j < 30;  j++)
            {
                Enemy enemy = Instantiate(_enemyPrefab, _spawnPos[i].position, Quaternion.identity);
                _createObject.ReleaseEnemy(enemy);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isPause)
        {
            transform.position = _player.position;
            _timer += Time.deltaTime;
            _levelUpTimer += Time.deltaTime;
            if (_levelUpTimer > _levelUpTime)
            {
                _prameter = _levelData.LevelSet();
                _levelUpTimer = 0;
            }

            if (_timer > _interval)
            {
                _timer = 0;
                int index = Random.Range(0, _spawnPos.Length);
                Enemy enemy = _createObject.PoolGetEnemy(_spawnPos[index].position);
                EnemyBase enemyBase = enemy as EnemyBase;
                enemyBase.ParamerterSet(_prameter.Level, _prameter.MaxHp, _prameter.PointUpNum, _prameter.WalkSpeed, _prameter.AttackPower);
            }
        }
    }

    void IPause.Pause()
    {
        _isPause = true;
    }
    void IPause.Resume()
    {
        _isPause = false;
    }

}
