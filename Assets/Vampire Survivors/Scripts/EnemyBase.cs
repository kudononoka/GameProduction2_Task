using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("歩行速度")]protected float _walkSpeed;
    [SerializeField, Header("HP最大値")] protected int _maxhp;
    [SerializeField, Header("攻撃力")] protected int _attackPower;
    protected int _nowhp;
    
}
