using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerVampireSurvivors : MonoBehaviour
{
    bool _isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseReaume()
    {
        _isPause = !_isPause;
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (_isPause)
            {
                i?.Pause();     
            }
            else
            {
                i?.Resume();
            }
        }
    }
}
