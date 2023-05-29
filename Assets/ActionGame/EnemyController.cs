using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : CharactersBase
{
    [SerializeField, Header("�U�����J�n���鎞��Player�Ƃ̋���")] float _attackDistance;
    [SerializeField, Header("�e�𐶐��C���^�[�o��")] float _intervalTime;
    [SerializeField, Header("�ːi����Ƃ��̃X�s�[�h")] float _moveSpeed;
    float _attacktimer;
    Transform _playerPos;
    GameObject _player;
    bool _isAttack = false;
    bool _isHit = false;
    Vector3 _attackMoveDir;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_playerPos != null && Vector2.Distance(_playerPos.position, transform.position) < _attackDistance)
        //{
        //    Attack();
        //}

        //�ːi�U��
        if (!_isAttack && _player != null && Vector2.Distance(_playerPos.position, transform.position) < _attackDistance)
        {
            _attackMoveDir = (_playerPos.position - transform.position).normalized;
            float angle = Vector2.Angle(-transform.right, _attackMoveDir);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            _isAttack = true;
        }

        if (_isAttack)
        {
            transform.position += (_attackMoveDir * _moveSpeed * Time.deltaTime);
            if (!_isHit)
            {
                Hit();
            }
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Attack()
    {
        _attacktimer += Time.deltaTime;
        if (_attacktimer > 3)
        {
            Generate(transform.rotation);
            Debug.Log(_attacktimer);
            _attacktimer = 0;
        }
    }

    void Hit()
    {
        float hit = ((transform.localScale.x / 2) + (_playerPos.localScale.x / 2));  
        float dir = Vector2.Distance(transform.position, _playerPos.position);

        if (dir < hit)
        {
            _player.GetComponent<CharactersBase>().Damage(2);
            _isHit = true;
        }
    }
}
