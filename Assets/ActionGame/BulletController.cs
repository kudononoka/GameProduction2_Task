using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _lifetime;
    [SerializeField] bool _isMoveDirRight;
    float _moveDir = 0;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifetime);
        _moveDir = _isMoveDirRight ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += _moveDir * _moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    
}
