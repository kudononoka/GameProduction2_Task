using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharactersBase
{
    [SerializeField, Header("���[�U�[Prefab")] GameObject _laserPrefab;
    /// <summary>�L�[���b�������Ń��[�U�[�𐶐������邩</summary>
    [SerializeField, Header("���[�U�[�����܂ł̎���")]float _laserTimeInterval;
    float _laserTimer;
    [SerializeField, Header("�ړ����x")] float _moveSpeed;
    /// <summary>�W�����v����Ƃ��̍ŏ��̏����x</summary>
    [SerializeField, Header("�W�����v��")] float _jumpPower;
    /// <summary>�W�����v���̎���</summary>
    float _jumpingTime = 0;
    /// <summary>�W�����v�O�̒n�ʂɂ��Ă���Player��Y�|�W�V����</summary>
    float _playerIsGroundPosY = 0;
    /// <summary>�W�����v����Ƃ��̍ŏ��̃|�W�V����</summary>
    float _jumpStartPos = 0;
    /// <summary>�W�����v�����ǂ���</summary>
    bool _isJump = false;
    /// <summary>�W�����v������</summary>
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
        //���ړ�
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
        //�W�����v��i�܂�
        if (Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
        {
            //�W�����v�����Ă��Ȃ�������
            if(_jumpCount == 0)
            {
                //�n�ʂƂ̐ݒu�ꏊ��ۑ�
                _playerIsGroundPosY = transform.position.y;
                //�W�����v���鎞�̍ŏ���PositionY�擾
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
            //�d�͂�����悤�Ɍ��������̂ŉ��������グ�̌������g����
            pos.y = _jumpStartPos +((-0.5f * 9.8f * _jumpingTime * _jumpingTime) + (_jumpPower * _jumpingTime));
        }
        
        //�n�ʂɐݒu������
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
