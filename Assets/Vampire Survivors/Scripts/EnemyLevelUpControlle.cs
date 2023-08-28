using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelUpControlle : MonoBehaviour
{
    [SerializeField, Header("EnemyのLevelのテーブル")] TextAsset _levelTableTextAsset;
    List<LevelParamerter> _levelData = new List<LevelParamerter>();
    int index = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        LevelTableLoad();
    }
    
    public LevelParamerter LevelSet()
    {
        LevelParamerter paramerter = new LevelParamerter();
        if (index >= _levelData.Count)
        {
            paramerter = _levelData[_levelData.Count - 1];
        }
        else
        {
            paramerter = _levelData[index];
        }
        index++;
        return paramerter;
    }
    void LevelTableLoad()
    {
        System.IO.StringReader sr = new System.IO.StringReader(_levelTableTextAsset.text);
        //最初の一行は項目名なので飛ばす
        sr.ReadLine();
        while (true)
        {
            string line = sr.ReadLine();
            //lineがnullまたは""だった場合
            if (string.IsNullOrEmpty(line))
            {
                break;
            }

            int[] data = Array.ConvertAll(line.Split(','), int.Parse);
            var leveldata = new LevelParamerter(data[0], data[1], data[2], (float)data[3], data[4]);
            _levelData.Add(leveldata);
        }
    }
}

public struct LevelParamerter
{
    int levelNum;
    int maxHp;
    int pointUpNum;
    float walkSpeed;
    int attackPower;

    public int Level => levelNum;
    public int MaxHp => maxHp;
    public int PointUpNum => pointUpNum;
    public float WalkSpeed => walkSpeed;
    public int AttackPower => attackPower;


    public LevelParamerter(int levelNum,int maxhp,int point, float walkSpeed, int attackPower)
    {
        this.levelNum = levelNum;
        this.maxHp = maxhp;
        this.pointUpNum = point;
        this.walkSpeed = walkSpeed;
        this.attackPower = attackPower;
    }
}
