using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Pool;

public class pointUp : ItemBase
{
    [SerializeField, Header("�o���lUp��")] int _upNum;

    public int PointUpNum { get { return _upNum; } set { _upNum = value; } }
    //private CreateObject _createObject;
    // Start is called before the first frame update
    void Start()
    {
        //_createObject = FindObjectOfType<CreateObject>();
    }

    private void Update()
    {
        
    }

    //Collition�̑傫���Łu�v���C���[�̎���1px�ȓ��ɓ�������A�v���C���[�ɋz�������v�̂𒲐�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player�ɓ���������
        if(collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Player>().PointNumUp(_upNum);
            Destroy(gameObject);
        }
    }
}
