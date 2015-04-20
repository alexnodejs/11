using UnityEngine;
using System.Collections;

using Global;

public static class HelperTrans
{
	public static float angleBetwineTwoTransforms(Transform transformA, Transform transformB)
	{
		Vector3 direction = transformA.position -transformB.position;
		float angle = Vector3.Angle(direction, transformB.forward);
		return angle;
	}

    public static float distanceBetwineTwoTransforms(Transform transformA, Transform transformB)
    {
        float distance = Vector3.Distance(transformA.position, transformB.position);
        return distance;
    }
}
