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

    protected override void OnUseButtonUp()
    {
        base.OnUseButtonUp();

        if (IsHeroAround)
        {
            EC.ShowControlPanel();
        }
    }
}
