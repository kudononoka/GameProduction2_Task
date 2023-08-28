using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Muchi : SkillBase
{
    public override void Active(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
