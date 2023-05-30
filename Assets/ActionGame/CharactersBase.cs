using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersBase : MonoBehaviour
{
    [SerializeField, Header("íeä€Prefab")] GameObject _bulletPrefab;
    [SerializeField, Header("íeä€ê∂ê¨èÍèä")]protected Transform _bulletGeneratePos;
    /// <summary>ç≈ëÂílHP</summary>
    [SerializeField, Header("Hpç≈ëÂíl")]protected int _maxHp = 5;
    /// <summary>åªç›ÇÃHP</summary>
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
