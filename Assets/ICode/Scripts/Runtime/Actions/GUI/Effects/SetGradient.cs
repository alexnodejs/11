using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Gradient=ICode.UnityGUI.Gradient;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]
	[Tooltip("Adds or updates the Gradient component.")]
	[System.Serializable]
	public class SetGradient : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Effect top color.")]
		public FsmColor topColor;
		[Tooltip("Effect bottom color.")]
		public FsmColor bottomColor;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Gradient component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Gradient>();
			if (component == null) {
				component = gameObject.Value.AddComponent<Gradient>();
			}
			DoSetGradient();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetGradient();
		}
		
		private void DoSetGradient(){
			component.topColor = topColor.Value;
			component.bottomColor = bottomColor.Value;
		}
		
	}
}