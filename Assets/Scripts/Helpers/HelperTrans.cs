using UnityEngine;
using System.Collections;
using System;

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

    /// <summary>
    /// pointByRay;
    /// </summary>
    public static Vector3 pointByRay(Ray ray, Action<Vector3> callback)
    {
        Vector3 point = Vector3.zero;

        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        {
            point = hitInfo.point;
        }

        callback(point);

        return point;
    }

    public static Vector3 pointByRay(Ray ray)
    {
        Vector3 point = Vector3.zero;

        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
        {
            point = hitInfo.point;
        }

        return point;
    }
}
