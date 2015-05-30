using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]
	[Tooltip("Adds or updates the Outline component.")]
	[System.Serializable]
	public class SetOutline : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Effect color.")]
		public FsmColor color;
		[Tooltip("Effect distance.")]
		public FsmVector2 effectDistance;
		[Tooltip("Use graphic alpha.")]
		[DefaultValue(true)]
		public FsmBool useGraphicAlpha;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Outline component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Outline>();
			if (component == null) {
				component = gameObject.Value.AddComponent<Outline>();
			}
			DoSetOutline();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetOutline();
		}
		
		private void DoSetOutline(){
			component.effectColor = color.Value;
			component.effectDistance = effectDistance.Value;
			component.useGraphicAlpha = useGraphicAlpha.Value;
		}
		
	}
}