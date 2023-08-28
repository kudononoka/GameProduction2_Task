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
            //�������s��
            () => Instantiate(_enemyPrefab).GetComponent<Enemy>(),
            //�v�[������擾�������̏���
            target => target.gameObject.SetActive(true),
            //�v�[���ɓ��ꂽ���̏���
            target => target.gameObject.SetActive(false),
            //�v�[���̋��e�ʂ𒴂������̍폜����
            target => Destroy(target.gameObject),
            //���Ƀv�[���ɂ���ꍇ�ɕ񍐂���i��O�𓊂���j���ǂ���
            true,
            //�����̋��e��
            30,
            //�ő勖�e��
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
