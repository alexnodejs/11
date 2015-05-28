using UnityEngine;
using System.Collections;
using Global;

public class ItrTerminal : InteractiveObject
{
    private EnvironmentController EC;

    void Awake()
    {
        EC = GameObject.FindObjectOfType<EnvironmentController>();
    }

    protected override void OnHeroExit()
    {
        base.OnHeroExit();

        EC.HideControlPanel();
    }
}
