using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    [SerializeField, Header("インターバル")]protected float _intervalTime;
    [SerializeField, Header("生存時間")] protected float _lifeTime;
    [SerializeField, Header("攻撃力")] int _attackPower;
    protected float _timer;
    protected bool _isActive;

    public float IntervalTime => _intervalTime;
    public float LifeTime => _lifeTime;
    public float Timer { get { return _timer; }set { _timer = value; } }
    public abstract void Active(bool active);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Enemyに当たったら
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<Enemy>().Damage(_attackPower);
        }
    }
}
