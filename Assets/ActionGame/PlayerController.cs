using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        //�W�����v��i�܂�
        if(Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
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
        }

        transform.position = pos;
    }
}
