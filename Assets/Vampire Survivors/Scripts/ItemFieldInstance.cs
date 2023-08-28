using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFieldInstance : MonoBehaviour
{
    [SerializeField, Header("�����������I�u�W�F�N�g")] SerializaFieldDictinary<InstanceItemState, GameObject>[] _instanceItem;
    /// <summary>�t�B�[���h��ɐ�����������Item�Ƃ���State��</summary>
    Dictionary<InstanceItemState, GameObject> _instanceItemDic = new Dictionary<InstanceItemState, GameObject>();
    private void Awake()
    {
        //Key��Value���擾�ł���悤��Dictinary�ɓ���Ȃ���
        foreach (var instanceItem in _instanceItem)
        {
            _instanceItemDic.Add(instanceItem.Key, instanceItem.Value);
        }
    }

    /// <summary>�t�B�[���h��ɐ�����������Item</summary>
    /// <param name="key">�������������I�u�W�F�N�g��State��</param>
    /// <param name="instancePos">�����ꏊ</param>
    public GameObject InstanceItem(InstanceItemState key, Vector2 instancePos)
    {
        GameObject gameObject = _instanceItemDic[key];
        GameObject instancedGO = Instantiate(gameObject, instancePos, Quaternion.identity);
        return instancedGO;
    }
}

[Serializable]
public class SerializaFieldDictinary<TKey, TValue>
{
    [SerializeField]private TKey key;
    [SerializeField]private TValue value;

    public TKey Key => key;
    public TValue Value => value;
}

public enum InstanceItemState
{
    /// <summary>�o���lUp�p</summary>
    PointUp,
    /// <summary>��</summary>
    Takarabako,
}
