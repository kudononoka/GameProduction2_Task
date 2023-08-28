using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("Level")] int _levelNum;
    [SerializeField, Header("���s���x")]protected float _walkSpeed;
    [SerializeField, Header("HP�ő�l")] protected int _maxhp;
    [SerializeField, Header("�U����")] protected int _attackPower;
    [SerializeField, Header("�o���l")] protected int _point;
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
