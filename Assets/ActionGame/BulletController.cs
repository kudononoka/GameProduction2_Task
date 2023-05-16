using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += _moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
