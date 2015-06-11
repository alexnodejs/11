﻿using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Should the cursor be visible?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Cursor-visible.html")]
	[System.Serializable]
	public  class SetCursorVisible : StateAction {
		public FsmBool visible;

		public override void OnEnter (){
			#if UNITY_5_0
				Cursor.visible = visible.Value;
			#else
				Cursor.visible=!visible.Value;
			#endif
			Finish ();
		}
	}
}