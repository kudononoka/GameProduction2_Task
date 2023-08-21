using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    [SerializeField, Header("��������")] float _lifeTime;
    [SerializeField]List<GameObject> _enemy;
    [SerializeField]List<Transform> _enemyPos;
    List<GameObject> _enemyBulletPos;
    private void Awake()
    {
        _enemy = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        _enemyBulletPos = GameObject.FindGameObjectsWithTag("EnemyBullet").ToList();
        for (int i = 0; i < _enemy.Count; i++)
        {
            _enemyPos.Add(_enemy[i].GetComponent<Transform>());
        }
        
        Destroy(gameObject, _lifeTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < _enemy.Count; i++)
        {
            if (Hit(_enemyPos[i]))
            {
                _enemy[i].GetComponent<CharactersBase>().Damage(3);
                FindObjectOfType<GameManager>().HitStop(0.25f);
            }
        }
        for (int i = 0; i < _enemyBulletPos.Count; i++)
        {
            Transform pos = _enemyBulletPos[i].GetComponent<Transform>();
            if(Hit2(pos))
            {
                FindObjectOfType<GameManager>().HitStop(0.25f);
                Destroy(_enemyBulletPos[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //���[�U�[�ƓG(�~)�̔���O�ς��g�p
    bool Hit(Transform target)
    {
        Vector3 vec = target.position - transform.position;
        float angle = Vector2.Angle(transform.right, vec);
        float dis = vec.magnitude * Mathf.Sin(angle);
        if(Mathf.Abs(dis) < (target.localScale.x / 2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //���[�U�[�ƓG�̒e(��`)�̔���O�ς��g�p
    bool Hit2(Transform target)
    {
        //����o���b�g�����������ߓ�_�Ŕ��肵�Ă����B���[�U�[�̎n�_����e��`�̍��[�̓_�ƉE�[�̓_�̃x�N�g�����擾
        Vector3 leftpoint = new Vector3(target.position.x - (target.localScale.x / 2),target.position.y) - transform.position;
        Vector3 rightpoint = new Vector3(target.position.x + (target.localScale.x / 2),target.position.y)- transform.position;
        float angle = Vector2.Angle(transform.right, leftpoint);
        float angle2 = Vector2.Angle(transform.right, rightpoint);
        float dis = leftpoint.magnitude * Mathf.Sin(angle);
        float dis2 = rightpoint.magnitude * Mathf.Sin(angle2);

        if((dis2 <= 0 && dis >= 0) || (dis2 >= 0 && dis2 <= 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
