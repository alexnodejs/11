using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Adds or updates the shadow component.")]
	[System.Serializable]
	public class SetShadow : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Effect color.")]
		public FsmColor color;
		[Tooltip("Effect distance.")]
		public FsmVector2 effectDistance;
		[Tooltip("Use graphic alpha.")]
		public FsmBool useGraphicAlpha;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Shadow component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Shadow>();
			if (component == null) {
				component = gameObject.Value.AddComponent<Shadow>();
			}
			DoSetShadow ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetShadow ();
		}

		private void DoSetShadow(){
			component.effectColor = color.Value;
			component.effectDistance = effectDistance.Value;
			component.useGraphicAlpha = useGraphicAlpha.Value;
		}
		
	}
}