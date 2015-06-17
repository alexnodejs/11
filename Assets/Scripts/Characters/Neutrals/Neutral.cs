using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Global;

public class Neutral : Character
{
    public enum TargetEngaging { All, Heroes, Enemys }
    public TargetEngaging CurTargetEngaging = TargetEngaging.Enemys;
    public Transform ScanerTransform;

    protected NeutralsController NC;

    protected override void Init()
    {
        base.Init();

        NC = GM.GetNeutralsCtr();

        InvokeRepeating("CheckPerimeterAround", 1, 1);
    }

    protected override void CharacterFixedUpdate()
    {
        base.CharacterFixedUpdate();

        //CheckPerimeterAround();
    }

    private void CheckPerimeterAround()
    {
        List<Collider> hitColliders = Physics.OverlapSphere(transform.position, SenceRadius, (1 << LayerMask.NameToLayer(Layers.heroes)) | (1 << LayerMask.NameToLayer(Layers.enemies))).ToList();

        hitColliders.OrderBy(col => Vector3.Distance(col.transform.position, transform.position)).ToList();
        hitColliders.Sort(delegate(Collider col1, Collider col2)
        {
            return
                Vector3.Distance(this.transform.position, col1.gameObject.transform.position)
                    .CompareTo(Vector3.Distance(this.transform.position, col2.gameObject.transform.position));
        });

        foreach (var obj in hitColliders)
        {
            Debug.Log("Character name: " + obj.transform.gameObject.GetComponent<Character>().Name);
        }

        //Debug.Log("Character name: " + col.transform.gameObject.GetComponent<Character>().Name);
        Debug.Log("##########################");
    }
}
