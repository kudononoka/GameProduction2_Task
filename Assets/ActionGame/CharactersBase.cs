using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersBase : MonoBehaviour
{
    [SerializeField, Header("弾丸Prefab")] GameObject _bulletPrefab;
    [SerializeField, Header("弾丸生成場所")]protected Transform _bulletGeneratePos;
    /// <summary>最大値HP</summary>
    [SerializeField, Header("Hp最大値")]protected int _maxHp = 5;
    /// <summary>現在のHP</summary>
    protected int _nowHp = 0;
    
    
    private void Awake()
    {
        _nowHp = _maxHp;
    }
    protected void Generate(Quaternion rotate)
    {
        Instantiate(_bulletPrefab, _bulletGeneratePos.position, rotate);
    }

    public void Damage(int damage)
    {
        _nowHp -= damage;
        if (_nowHp <= 0)
        {
            CollisionDetectionController[] collisions = FindObjectsOfType<CollisionDetectionController>();
            foreach (CollisionDetectionController collision in collisions)
            {
                collision.NullChack();
            }
            Destroy(this.gameObject);
        }
    }

    
}
