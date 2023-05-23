using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : CharactersBase
{
    [SerializeField, Header("�U�����J�n���鎞��Player�Ƃ̋���")] float _attackDistance;
    [SerializeField, Header("�e�𐶐��C���^�[�o��")] float _intervalTime;
    float _attacktimer;
    Transform _playerPos;
    void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(_playerPos != null && Vector2.Distance(_playerPos.position, transform.position) < _attackDistance)
        {
            Attack();
        }
    }

    void Attack()
    {
        _attacktimer += Time.deltaTime;
        if(_attacktimer > _intervalTime)
        {
            Generate(Quaternion.identity);
            _attacktimer = 0;
        }
    }
}
