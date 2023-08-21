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
        _levelUpPool = new ObjectPool<LevelUp>(
            //�������s��
            () => Instantiate(_levelUpPrefab).GetComponent<LevelUp>(),
            //�v�[������擾�������̏���
            target => target.gameObject.SetActive(true),
            //�v�[���ɓ��ꂽ���̏���
            target => target.gameObject.SetActive(false),
            //�v�[���̋��e�ʂ𒴂������̍폜����
            target => Destroy(target.gameObject),
            //���Ƀv�[���ɂ���ꍇ�ɕ񍐂���i��O�𓊂���j���ǂ���
            true,
            //�����̋��e��
            100,
            //�ő勖�e��
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
