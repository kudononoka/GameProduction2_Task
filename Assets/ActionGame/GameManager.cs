using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool _isHitStop = false;
    float _hitStopTimer;
    List<HitStopControlle> hitStopControlles = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isHitStop)
        {
            _hitStopTimer -= Time.deltaTime;
            foreach(var controlle in hitStopControlles )
            {
                controlle.HitStopUpdate();
            }
            if(_hitStopTimer < 0 )
            {
                _isHitStop = false;
            }
        }
    }

    public void HitStop(float timer)
    {
        _hitStopTimer = timer;
        GameObject[] gos = FindObjectsOfType<GameObject>();
        foreach( GameObject go in gos )
        {
            HitStopControlle controlle = go.GetComponent<HitStopControlle>();
            hitStopControlles.Add(controlle);
        }
        hitStopControlles.RemoveAll(null);
        foreach(var controlle in hitStopControlles )
        {
            controlle.HitStopStart();
        }
        _isHitStop = true;
    }
}
