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
        actionBar = GameObject.FindGameObjectWithTag("ActionBar").GetComponent<ActionBar>();
        skillsController.SkillAdded += actionBar.OnSkillAdded;

        LoadStubSkills();
    }

    /// <summary>
    /// Load stub skills.
    /// </summary>
    private void LoadStubSkills()
    {
    }
}
