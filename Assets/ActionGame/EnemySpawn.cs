using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField, Header("生成時のインターバル")] float _spawnIntervalTime;
    [SerializeField, Header("EnemyのPrefab")] GameObject _enemyPrefab;
    float _spawnTimer;
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
            _spawnTimer += Time.deltaTime;
            if(_spawnTimer > _spawnIntervalTime)
            {
                Spawn();
                _spawnTimer = 0;
            }
        }
    }

    void Spawn()
    {
        CollisionDetectionController[] date = FindObjectsOfType<CollisionDetectionController>();
        foreach(CollisionDetectionController d in date)
        {
            d.TargetDataClear();
        }
        GameObject go = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        go.transform.parent = transform;
    }
}
