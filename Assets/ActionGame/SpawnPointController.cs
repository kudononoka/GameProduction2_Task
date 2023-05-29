using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    [SerializeField, Header("SpawnPoint‚ÌŒÂ”")] int _spawnPointCount;
    [SerializeField, Header("SpawnêŠ")] List<Transform> _spawnPointPosition;
    [SerializeField, Header("¶¬‚·‚é‚ÌPlayer‚Æ‚Ì‹——£")] float _distanceMax;
    [SerializeField, Header("EnemyPrafab")] GameObject _enemyPrefab;
    Transform _player;
    [SerializeField]List<Vector3> _spawnPos = new List<Vector3>();
    /// <summary>“G‚ª‚¢‚é‚©‚Ç‚¤‚©</summary>
    bool _isEnemy = false;
    /// <summary>¶¬‚·‚é‚©‚Ç‚¤‚©</summary>
    bool _isSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        SpawnPosReset();
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.childCount == 0)
        //{
        //    _isEnemy = false;
        //}

        for (int i = 0; i < _spawnPos.Count; i++)
        {
            if(_player != null && !_isEnemy && Vector2.Distance(_player.position, _spawnPos[i]) < _distanceMax)
            {
                _isSpawn = true;
            }
        }

        if(_isSpawn)
        {
            foreach (var i in  _spawnPos)
            {
                Spawn(i);
            }
            _isEnemy = true;
            _isSpawn = false;
        }
    }

    void Spawn(Vector3 spawnPos)
    {
        CollisionDetectionController[] date = FindObjectsOfType<CollisionDetectionController>();
        foreach (CollisionDetectionController d in date)
        {
            d.TargetDataClear();
        }
        GameObject go = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        go.transform.parent = transform;
        
    }

    void SpawnPosReset()
    {
        List<Transform> spawnPos = _spawnPointPosition;
        for (int i = 0; i < _spawnPointCount; i++)
        {
            int index = Random.Range(0, spawnPos.Count);
            _spawnPos.Add(spawnPos[index].position);
            spawnPos.RemoveAt(index);
        }
    }
}
