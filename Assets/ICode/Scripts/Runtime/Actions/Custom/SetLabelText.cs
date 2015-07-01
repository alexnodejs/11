using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

namespace ICode.Actions.Custom
{
    [Category(Category.Custom)]
    [Tooltip("Set value of text.")]
    [System.Serializable]
    public class SetLabelText : StateAction
    {
        [SharedPersistent]
        [Tooltip("GameObject to use.")]
        public FsmGameObject gameObject;
        [Tooltip("Image to set.")]
        public FsmGameObject character;
        [Tooltip("Execute the action every frame.")]
        public bool everyFrame;

        private Text component;
        private float value;

        public override void OnEnter()
        {
            value = character.Value.GetComponent<Character>().HealthLevel;
            component = gameObject.Value.GetComponent<Text>();
            DoSetText();
            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoSetText();
        }

        private void DoSetText()
        {
            value = character.Value.GetComponent<Character>().HealthLevel;
            component.text = value.ToString(CultureInfo.InvariantCulture);
        }
    }
}

