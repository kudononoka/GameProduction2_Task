using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField, Header("���s���x")]protected float _walkSpeed;
    [SerializeField, Header("HP�ő�l")] protected int _maxhp;
    [SerializeField, Header("�U����")] protected int _attackPower;
    protected int _nowhp;
    
}
