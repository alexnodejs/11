using UnityEngine;
using System.Collections;
using Global;

public class ItrTerminal : InteractiveObject
{
    public ItrDoor[] DoorsArray;

    private EnvironmentController EC;

    void Awake()
    {
        EC = GameObject.FindObjectOfType<EnvironmentController>();
    }

    public override void Interact()
    {
        base.Interact();

        //EC.ShowControlPanel(DoorsArray);
    }

    protected override void HeroExit()
    {
        base.HeroExit();

        EC.HideControlPanel();
    }
}
