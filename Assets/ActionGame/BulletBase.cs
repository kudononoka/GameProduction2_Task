using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    [SerializeField] List<Transform> _targetPos;
    [SerializeField] List<CharactersBase> _targetCharactersBase;
    [SerializeField] List<GameObject> _targetGO;
    [SerializeField] string _targetTagName;
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _lifetime;
    [SerializeField] bool _isPlayer;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        TargetDataClear();
        Destroy(gameObject, _lifetime);
        if (_isPlayer)
        {
            Transform tra = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - tra.position).normalized;
        }
        else
        {
            dir.x = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (_isPlayer)
        {
            pos.x += dir.x * _moveSpeed * Time.deltaTime;
            pos.y += dir.y * _moveSpeed * Time.deltaTime;
        }
        else
        {
            pos.x += dir.x * _moveSpeed * Time.deltaTime;
        }
        transform.position = pos;
        HitJudge();
    }

    public void TargetDataClear()
    {
        _targetGO.Clear();
        _targetPos.Clear();
        _targetCharactersBase.Clear();
        _targetGO = GameObject.FindGameObjectsWithTag(_targetTagName).ToList();
        if (_targetGO.Count > 0)
        {
            for (int i = 0; i < _targetGO.Count; i++)
            {
                _targetPos.Add(_targetGO[i].GetComponent<Transform>());
                _targetCharactersBase.Add(_targetGO[i].GetComponent<CharactersBase>());
            }
        }
    }
    public void NullChack()
    {
        for (int i = 0; i < _targetGO.Count; i++)
        {
            if (_targetGO[i] == null)
            {
                _targetGO.RemoveAt(i);
                _targetPos.RemoveAt(i);
                _targetCharactersBase.RemoveAt(i);
            }
        }
    }
    public void HitJudge()
    {
        for (int i = 0; i < _targetPos.Count; i++)
        {
            if (_targetPos[i] != null)
            {
                Transform target = _targetPos[i];
                if (HitJudge2(target))
                {
                    _targetCharactersBase[i].Damage(1);
                    Destroy(gameObject);
                }
            }
        }
    }

    bool HitJudge2(Transform target)
    {
        //�㉺�̓�����t���O
        bool updown = false;
        //���E�̓�����t���O
        bool rightleft = false;
        //�΂߂̓�����t���O
        bool diagonal = false;
        //�Ώۂ̒��S���W�Ɣ��a
        float tarPosX = target.position.x;
        float tarPosY = target.position.y;
        float r = target.localScale.x / 2;

        //�����̍��΂ߊp�̍��W�ƉE�΂߉��̊p�̍��W
        float x = transform.position.x - (transform.localScale.x / 2);
        float y = transform.position.y + (transform.localScale.y / 2);
        float x2 = transform.position.x + (transform.localScale.x / 2);
        float y2 = transform.position.y - (transform.localScale.y / 2);

        //�㉺�̓����蔻��
        if ((x < tarPosX && tarPosX < x2) && (y - r < tarPosY && tarPosY < y2 + r))
        {
            updown = true;
        }
        //���E�̓����蔻��
        if ((y < tarPosY && tarPosY < y2) && (x - r < tarPosX && tarPosX < x2 + r))
        {
            rightleft = true;
        }
        //�΂߂̓����蔻��
        if (Mathf.Pow(x - tarPosX, 2) + Mathf.Pow(y - tarPosY, 2) < Mathf.Pow(r, 2) ||
           Mathf.Pow(x2 - tarPosX, 2) + Mathf.Pow(y - tarPosY, 2) < Mathf.Pow(r, 2) ||
           Mathf.Pow(x - tarPosX, 2) + Mathf.Pow(y2 - tarPosY, 2) < Mathf.Pow(r, 2) ||
           Mathf.Pow(x2 - tarPosX, 2) + Mathf.Pow(y2 - tarPosY, 2) < Mathf.Pow(r, 2))
        {
            diagonal = true;
        }

        //�ǂꂩ��ł�����������true��Ԃ�
        return updown || rightleft || diagonal;
    }
}
