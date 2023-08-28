using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemFieldInstance : MonoBehaviour
{
    [SerializeField, Header("生成したいオブジェクト")] SerializaFieldDictinary<InstanceItemState, GameObject>[] _instanceItem;
    /// <summary>フィールド上に生成させたいItemとそのState名</summary>
    Dictionary<InstanceItemState, GameObject> _instanceItemDic = new Dictionary<InstanceItemState, GameObject>();
    private void Awake()
    {
        //KeyでValueが取得できるようにDictinaryに入れなおす
        foreach (var instanceItem in _instanceItem)
        {
            _instanceItemDic.Add(instanceItem.Key, instanceItem.Value);
        }
    }

    /// <summary>フィールド上に生成させたいItem</summary>
    /// <param name="key">生成させたいオブジェクトのState名</param>
    /// <param name="instancePos">生成場所</param>
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
    /// <summary>経験値Up用</summary>
    PointUp,
    /// <summary>宝箱</summary>
    Takarabako,
}
