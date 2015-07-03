using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Global;

public class Neutral : Character
{
    public enum TargetEngaging { All, Heroes, Enemys }
    public TargetEngaging CurTargetEngaging = TargetEngaging.Enemys;
    public Transform ScanerTransform;

    protected NeutralsController NC;

    protected override void Init()
    {
        base.Init();

        NC = GM.GetNeutralsCtr();
    }

    protected override void CharacterFixedUpdate()
    {
        base.CharacterFixedUpdate();
    }
}
