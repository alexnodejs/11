using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.Custom
{
    [Category(Category.Custom)]
    [Tooltip("Sets the image of an Button component.")]
    [System.Serializable]
    public class SetButtonImage : StateAction
    {
        [SharedPersistent]
        [Tooltip("GameObject to use.")]
        public FsmGameObject gameObject;
        [Tooltip("Image to set.")]
        public Sprite image;
        [Tooltip("Execute the action every frame.")]
        public bool everyFrame;

        private Image component;

        public override void OnEnter()
        {
            component = gameObject.Value.GetComponent<Image>();
            DoSetImage();
            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoSetImage();
        }

        private void DoSetImage()
        {
            component.sprite = image;
        }
    }
}
