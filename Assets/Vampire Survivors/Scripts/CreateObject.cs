using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CreateObject : MonoBehaviour
{
    ObjectPool<Enemy> _enemyPool;
    [SerializeField, Tooltip("EnemyPrefab")] GameObject _enemyPrefab;
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
    }
    
    public Enemy PoolGetEnemy(Vector2 pos)
    {
        var obj = _enemyPool.Get();
        Transform tra = obj.transform;
        tra.position = pos;
        return obj;
    }
    public void ReleaseEnemy(Enemy enemy)
    {
        _enemyPool.Release(enemy);
    }
}
