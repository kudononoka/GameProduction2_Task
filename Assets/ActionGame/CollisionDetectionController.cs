using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Linq;

public class CollisionDetectionController : MonoBehaviour
{
    [SerializeField]List<Transform> _targetPos;
    [SerializeField]List<CharactersBase> _targetCharactersBase;
    [SerializeField]List<GameObject> _targetGO;
    [SerializeField]string _targetTagName;
    private void Awake()
    {
        _targetGO = GameObject.FindGameObjectsWithTag(_targetTagName).ToList();
       
    }


    void Start()
    { 
        if(_targetGO.Count > 0)
        {
            for (int i = 0; i < _targetGO.Count; i++)
            {
                _targetPos.Add(_targetGO[i].GetComponent<Transform>());
                _targetCharactersBase.Add(_targetGO[i].GetComponent<CharactersBase>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        HitJudge();
    }
    public void NullChack()
    {
        for(int i = 0; i < _targetGO.Count;i++)
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
                    _targetCharactersBase[i].Damage();
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
�@�@�@�@
        //�����̍��΂ߊp�̍��W�ƉE�΂߉��̊p�̍��W
        float x = transform.position.x - (transform.localScale.x / 2);
        float y = transform.position.y + (transform.localScale.y / 2);
        float x2 = transform.position.x + (transform.localScale.x / 2);
        float y2 = transform.position.y - (transform.localScale.y / 2);

        //�㉺�̓����蔻��
        if((x < tarPosX  && tarPosX < x2) && (y - r < tarPosY && tarPosY < y2 + r ))
        {
            updown = true;
        }
        //���E�̓����蔻��
        if((y < tarPosY && tarPosY < y2) && (x - r < tarPosX && tarPosX < x2 + r))
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



