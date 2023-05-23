using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _lifetime;
    [SerializeField] bool _isPlayer;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifetime);
        if(_isPlayer )
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
        
        if(_isPlayer)
        {
            pos.x += dir.x * _moveSpeed * Time.deltaTime;
            pos.y += dir.y * _moveSpeed * Time.deltaTime;
        }
        else
        {
            pos.x += dir.x * _moveSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }

    
}
