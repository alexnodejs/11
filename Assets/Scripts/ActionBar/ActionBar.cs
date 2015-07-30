using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    //  public GameObject skillSlot;
    public HealthSlotsController healthSlotsController;
    public EnergySlotsController energySlotsController;

    public void OnSkillAdded(object source, SkillEventArgs e)
    {
        //  healthSlotsController.OrganizeInEmptySlot(e.SkillHero);
        energySlotsController.OrganizeInEmptySlot(e.SkillHero);
    }
}
