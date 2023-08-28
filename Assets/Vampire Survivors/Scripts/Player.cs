using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    float _dirX = 0;
    float _dirY = 0;
    /// <summary>���ݏ������Ă���Skill</summary>
    List<SkillBase> _skills = new List<SkillBase>();
    [SerializeField, Header("���s���x")] float _walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        //���`����
        Muchi muchi = FindObjectOfType<Muchi>();
        _skills.Add(muchi);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _skills.Count; i++)
        {
            SkillBase skill = _skills[i];
            skill.Timer += Time.deltaTime;
            //Skill�̃I�u�W�F�N�g�̐������Ԃ��߂�����
            if (skill.Timer > (skill.IntervalTime + skill.LifeTime))
            {
                //����
                skill.Active(false);
                skill.Timer = 0;
            }
            //��莞�Ԃ�������
            else if (_skills[i].Timer > skill.IntervalTime)
            {
                //����
                skill.Active(true);
            }
        }
        
        _dirX = Input.GetAxisRaw("Horizontal");
        _dirY = Input.GetAxisRaw("Vertical");
        if(_dirX == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (_dirX == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void FixedUpdate()
    {
         _rb.velocity = new Vector2(_dirX, _dirY) * _walkSpeed;
    }
}
