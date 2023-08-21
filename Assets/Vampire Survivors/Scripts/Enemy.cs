using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : EnemyBase
{
    private CreateObject _createObject;
    // Start is called before the first frame update
    void Start()
    {
        _createObject = FindObjectOfType<CreateObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
