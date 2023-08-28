using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("Level")] int _levelNum;
    [SerializeField, Header("歩行速度")]protected float _walkSpeed;
    [SerializeField, Header("HP最大値")] protected int _maxhp;
    [SerializeField, Header("攻撃力")] protected int _attackPower;
    [SerializeField, Header("経験値")] protected int _point;
    protected int _nowhp;
    
    public void ParamerterSet(int level, int hp, int point, float speed, int power)
    {
        _levelNum = level;
        _walkSpeed = speed; 
        _maxhp = hp;
        _attackPower = power;
        _point = point;
    }
}
