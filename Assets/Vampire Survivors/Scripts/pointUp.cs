using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Pool;

public class pointUp : ItemBase
{
    [SerializeField, Header("経験値Up数")] int _upNum;

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

    //Collitionの大きさで「プレイヤーの周囲1px以内に入ったら、プレイヤーに吸収される」のを調整
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Playerに当たったら
        if(collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Player>().PointNumUp(_upNum);
            Destroy(gameObject);
        }
    }
}
