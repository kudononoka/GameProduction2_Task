using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : EnemyBase, IPause
{
    ItemFieldInstance _itemFieldInstance;
    CreateObject _createObject;
    Transform _playerTra;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _createObject = FindObjectOfType<CreateObject>();
        _itemFieldInstance = FindObjectOfType<ItemFieldInstance>();
        _playerTra = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _nowhp = _maxhp;
    }

    private void FixedUpdate()
    {
        Vector2 dir = (_playerTra.position - transform.position).normalized;
        _rb.velocity = dir * _walkSpeed;
    }

    /// <summary>É_ÉÅÅ[ÉWÇ™â¡ÇÌÇËÇ‹Ç∑</summary>
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        _nowhp -= damage;
        if (_nowhp <= 0)
        {
            GameObject go = _itemFieldInstance.InstanceItem(InstanceItemState.PointUp, this.gameObject.transform.position);
            go.GetComponent<pointUp>().PointUpNum = _point;
            _createObject.ReleaseEnemy(this);
        }
    }

    void IPause.Pause()
    {
        _rb.simulated = false;
        _rb.Sleep();
    }
    void IPause.Resume()
    {
        _rb.simulated = true;
        _rb.WakeUp();
    }

}
