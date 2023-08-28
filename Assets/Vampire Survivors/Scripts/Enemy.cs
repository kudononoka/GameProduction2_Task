using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : EnemyBase
{
    CreateObject _createObject;
    Transform _playerTra;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _createObject = FindObjectOfType<CreateObject>();
        _playerTra = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _nowhp = _maxhp;
    }

    private void FixedUpdate()
    {
        Vector2 dir = (_playerTra.position - transform.position).normalized;
        _rb.velocity = dir * _walkSpeed;
    }

    public void Damage(int damage)
    {
        _nowhp -= damage;
        if (_nowhp <= 0)
        {
            _createObject.ReleaseEnemy(this);
        }
    }

}
