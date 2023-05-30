using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharactersBase
{
    [SerializeField, Header("レーザーPrefab")] GameObject _laserPrefab;
    /// <summary>キー何秒長押しでレーザーを生成させるか</summary>
    [SerializeField, Header("レーザー生成までの時間")]float _laserTimeInterval;
    float _laserTimer;
    [SerializeField, Header("移動速度")] float _moveSpeed;
    /// <summary>ジャンプするときの最初の初速度</summary>
    [SerializeField, Header("ジャンプ力")] float _jumpPower;
    /// <summary>ジャンプ中の時間</summary>
    float _jumpingTime = 0;
    /// <summary>ジャンプ前の地面についているPlayerのYポジション</summary>
    float _playerIsGroundPosY = 0;
    /// <summary>ジャンプするときの最初のポジション</summary>
    float _jumpStartPos = 0;
    /// <summary>ジャンプ中かどうか</summary>
    bool _isJump = false;
    /// <summary>ジャンプした数</summary>
    int _jumpCount = 0;
    bool _isKnockBack = false;
    float _knockBackDir = 1;
    [SerializeField] float _backTime;
    float _backTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 pos = transform.position;
        //横移動
        pos.x += x * _moveSpeed * Time.deltaTime;

        if (_isKnockBack)
        {
            _backTimer += Time.deltaTime;
            pos = transform.position;
            pos.x += (0.01f * _knockBackDir);
            transform.position = pos;
            if (_backTimer > _backTime)
            {
                _isKnockBack = false;
            }
        }
        else
        {
            _backTimer = 0;
        }
        //ジャンプ二段まで
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
        {
            //ジャンプをしていなかったら
            if(_jumpCount == 0)
            {
                //地面との設置場所を保存
                _playerIsGroundPosY = transform.position.y;
                //ジャンプする時の最初のPositionY取得
                _jumpStartPos = transform.position.y;
            }
            else
            {
                _jumpingTime = 0;
                _jumpStartPos = transform.position.y;
            }
            _jumpCount++;
            _isJump = true;
        }

        if(_isJump)
        {
            _jumpingTime += Time.deltaTime;
            //重力があるように見せたいので鉛直投げ上げの公式を使った
            pos.y = _jumpStartPos +((-0.5f * 9.8f * _jumpingTime * _jumpingTime) + (_jumpPower * _jumpingTime));
        }
        
        //地面に設置したら
        if(transform.position.y < _playerIsGroundPosY && _isJump)
        {
            _isJump = false;
            _jumpCount = 0;
            _jumpingTime = 0;
            pos.y = _playerIsGroundPosY;
        }

        transform.position = pos;
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        float _radian = Mathf.Atan2(dir.y, dir.x);
        transform.rotation = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, Vector3.forward);
        if (Input.GetKey(KeyCode.Z))
        {
            _laserTimer += Time.deltaTime;
            if (_laserTimer > _laserTimeInterval && _laserTimer < _laserTimeInterval + Time.deltaTime)
            {
                Instantiate(_laserPrefab, _bulletGeneratePos.position, transform.rotation);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            if (_laserTimer < _laserTimeInterval)
            {
                Generate(transform.rotation);
            }
            _laserTimer = 0;
        }
    }

    public void IsKnockBack(float dir)
    {
        _knockBackDir = dir;
        _isKnockBack = true;
    }
}
