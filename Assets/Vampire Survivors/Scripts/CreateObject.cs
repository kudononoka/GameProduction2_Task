using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreateObject : MonoBehaviour
{
    ObjectPool<Enemy> _enemyPool;
    ObjectPool<LevelUp> _levelUpPool;
    [SerializeField, Tooltip("EnemyPrefab")] GameObject _enemyPrefab;
    [SerializeField, Tooltip("LevelUpPrefab")] GameObject _levelUpPrefab;
    private void Awake()
    {
        _enemyPool = new ObjectPool<Enemy>(
            //生成を行う
            () => Instantiate(_enemyPrefab).GetComponent<Enemy>(),
            //プールから取得した時の処理
            target => target.gameObject.SetActive(true),
            //プールに入れた時の処理
            target => target.gameObject.SetActive(false),
            //プールの許容量を超えた時の削除処理
            target => Destroy(target.gameObject),
            //既にプールにある場合に報告する（例外を投げる）かどうか
            true,
            //初期の許容量
            30,
            //最大許容量
            30
        );
        _levelUpPool = new ObjectPool<LevelUp>(
            //生成を行う
            () => Instantiate(_levelUpPrefab).GetComponent<LevelUp>(),
            //プールから取得した時の処理
            target => target.gameObject.SetActive(true),
            //プールに入れた時の処理
            target => target.gameObject.SetActive(false),
            //プールの許容量を超えた時の削除処理
            target => Destroy(target.gameObject),
            //既にプールにある場合に報告する（例外を投げる）かどうか
            true,
            //初期の許容量
            100,
            //最大許容量
            200
        );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PoolGetEnemy(Vector2 pos)
    {
        var obj = _enemyPool.Get();
        Transform tra = obj.transform;
        tra.position = pos;
    }
    public void ReleaseEnemy(Enemy enemy)
    {
        _enemyPool.Release(enemy);
    }
    public void PoolGetLevelUp(Vector2 pos)
    {
        var obj = _levelUpPool.Get();
        Transform tra = obj.transform;
        tra.position = pos;
    }
    public void ReleaseLevelUp(LevelUp levelUp)
    {
        _levelUpPool.Release(levelUp);
    }
}
