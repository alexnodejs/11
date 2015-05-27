using UnityEngine;
using System.Collections;
//using RAIN.Core;

public class Zomby: Character
{

    protected override void Init()
    {
        base.Init();
    }

	void Start ()
    {
        Init();
	}

    void Update()
    {
        if (LifeLevel <= 0 && !isDead)
        {
            isDead = true;
            anim.SetBool("Dead", isDead);
//            GetComponentInChildren<AIRig>().enabled = false;
        }
    }
}
