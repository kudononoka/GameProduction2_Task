using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField,Header("生成場所")]Transform[] _spawnPos;
    [SerializeField] CreateObject _createObject; 
    [SerializeField] Transform _player;
    [SerializeField] Enemy _enemyPrefab;
    [SerializeField, Header("生成のインターバル")] float _interval;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _spawnPos.Length; i++)
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
        transform.position = _player.position;
        _timer += Time.deltaTime;
        if(_timer > _interval )
        {
            _timer = 0;
            int index = Random.Range( 0, _spawnPos.Length);
            _createObject.PoolGetEnemy(_spawnPos[index].position);
        }

    }


}
