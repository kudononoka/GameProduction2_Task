using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : CharactersBase
{
    [SerializeField, Header("攻撃を開始する時のPlayerとの距離")] float _attackDistance;
    [SerializeField, Header("弾を生成インターバル")] float _intervalTime;
    [SerializeField, Header("突進するときのスピード")] float _moveSpeed;
    float _attacktimer;
    Transform _playerPos;
    GameObject _player;
    bool _isAttack = false;
    bool _isHit = false;
    Vector3 _attackMoveDir;
    bool _isKnockBack = false;
    float _knockBackDir = 1;
    [SerializeField] float _backTime;
    float _backTimer;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerPos = _player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerPos != null && Vector2.Distance(_playerPos.position, transform.position) < _attackDistance + 5)
        {
            Attack();
        }

        //突進攻撃
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

        if(_isKnockBack)
        {
            _backTimer += Time.deltaTime;
            Vector3 pos = transform.position;
            pos.x += (0.3f * _knockBackDir);
            transform.position = pos;
            if(_backTimer > _backTime)
            {
                _isKnockBack = false;
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
            _player.GetComponent<PlayerController>().IsKnockBack(1);
            _isHit = true;
        }
    }

    public void IsKnockBack(float dir)
    {
        _isKnockBack = true;
        _knockBackDir = dir;
        _backTime = 0;
    }
}
