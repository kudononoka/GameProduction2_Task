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
    List<Hit> _hitList = new List<Hit>();
    [SerializeField]string _targetTagName;
    float disXHit;
    float disYHit;
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
                float disXHit = (transform.localScale.x / 2) + (_targetPos[i].localScale.x / 2);
                float disYHit = (transform.localScale.y / 2) + (_targetPos[i].localScale.y / 2);
                Hit hit = new Hit(disYHit, disXHit);
                _hitList.Add(hit);
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
                Transform _target = _targetPos[i];
                float dis = Vector2.Distance(transform.position, _target.position);
                if (dis <= _hitList[i].DisXHit || dis <= _hitList[i].DisYHit)
                {
                    _targetCharactersBase[i].Damage();
                    Destroy(gameObject);
                }
            }
        }
    }
}



public struct Hit
{
    private float disYHit;
    private float disXHit;

    public float DisYHit => disYHit;
    public float DisXHit => disXHit;
    public Hit(float disYHit, float disXHit)
    {
        this.disYHit = disYHit;
        this.disXHit = disXHit;
    }
}
