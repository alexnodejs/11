using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public abstract class AbstractSlotsController: MonoBehaviour {

    public List<GameObject> SlotsPlaceholders = new List<GameObject>();
    
    public Sprite SelectedSlot;
    public Sprite DeselectedSlot;
    
    /// <summary>
    /// Skill slot prefab.
    /// </summary>
    public GameObject skillSlot;
    
	/// <summary>
    /// Skills slots storage.
    /// </summary>
    protected List<GameObject> SkillSlots = new List<GameObject>();
    

	public virtual void Start()
    {
        AddEmptySlots();
        SkillSlotController.SlotUpdated += DeselectSlot;
    }

	/// <summary>
    /// Find an empty slot on the action bar and assign s skill to it.
    /// </summary>
    public void OrganizeInEmptySlot(SkillHero skill)
    {

        foreach (GameObject placeholder in SlotsPlaceholders)
        {
            SkillSlotController controller = placeholder.transform.GetChild(0)
                .GetComponent<SkillSlotController>();

            if (!controller.HasSkill())
            {
                controller.SetSkill(skill);
                break;
            }
        }
    }

	/// <summary>
    /// Create and add an empty skill slot to the action bar.
    /// </summary>
    private void AddEmptySlots()
    {
        foreach (GameObject placeholder in SlotsPlaceholders)
        {
            GameObject slot = Instantiate(skillSlot) as GameObject;
            slot.transform.SetParent(placeholder.transform, false);
            // RectTransform rectTransform = slot.GetComponent<RectTransform>();
            //
            // rectTransform.localPosition = new Vector3(
            // 	rectTransform.localPosition.x + rectTransform.rect.width * i,
            // 	rectTransform.localPosition.y,
            // 	0);
            SkillSlots.Add(slot);
        }
    }

	#region ChangeActiveSlot handler

    /// <summary>
    /// Remove focused state from a non selected slot.
    /// </summary>
    void DeselectSlot(GameObject newSelectedSlot)
    {
        if (newSelectedSlot.transform.parent.parent.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) {
            return;
        }
        
        foreach (GameObject slot in SkillSlots) {
            if (newSelectedSlot.GetInstanceID() == slot.GetInstanceID()) {
                slot.transform.parent.GetComponent<Image>().sprite = SelectedSlot;
            } else {
                slot.transform.parent.GetComponent<Image>().sprite = DeselectedSlot;
                //  slot.GetComponent<SkillSlotController>().Blur();
            }
        }
    }

    #endregion;

}
