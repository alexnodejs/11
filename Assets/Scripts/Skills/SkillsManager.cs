using UnityEngine;
using System.Collections;

public class SkillsManager : MonoBehaviour
{
    /// <summary>
    /// Event handler.
    /// Skills Controller instance.
    /// </summary>
    private SkillsController skillsController;

    /// <summary>
    /// Action Bar script refference.
    /// </summary>
    private ActionBar actionBar;

    public void Start()
    {
        skillsController = new SkillsController();
        actionBar = GameObject.FindGameObjectWithTag(Global.Tags.actionBar).GetComponent<ActionBar>();
        skillsController.SkillAdded += actionBar.OnSkillAdded;

        LoadStubSkills();
    }

    /// <summary>
    /// Load stub skills.
    /// </summary>
    private void LoadStubSkills()
    {
        skillsController.AddSkill(new SkillHero("Steals", "A_Armadura01") {
            keyCode = KeyCode.Alpha1,
            interval = 3.5f,
            energyConsumption = 20.0f,
            isAvailable = true,
            description = "Invisible Mode",
        });

        skillsController.AddSkill(new SkillHero("Kinetic Leap", "A_Armadura03") {
            keyCode = KeyCode.Alpha2,
            interval = 1.0f,
            energyConsumption = 999.0f,
            isAvailable = false,
            description = "Rapid Jump",
        });

        skillsController.AddSkill(new SkillHero("Hologram", "W_Machado010") {
            keyCode = KeyCode.Alpha3,
            interval = 10.0f,
            energyConsumption = 10.0f,
            isAvailable = true,
            description = "Distracting Image",
        });
    }
}
