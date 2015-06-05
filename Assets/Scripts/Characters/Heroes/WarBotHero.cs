using UnityEngine;
using System.Collections;
using Global;

[AddComponentMenu("Global/Characters/WarBotHero")]
public class WarBotHero : Hero
{
    private Vector3 _targetPoint;
    private float _angleToDestination;
    private bool _isPrepareToMove = false;

    protected override void Init()
    {
        base.Init();

        CharacterRotationSpeed = 60f;
    }

    protected override void CharacterFixedUpdate()
    {
        base.CharacterFixedUpdate();

        if (_isPrepareToMove)
        {
            CheckIsReadyToMove();
        }
    }

    private void CheckIsReadyToMove()
    {
        Vector3 direction = _targetPoint - transform.position;
        _angleToDestination = Vector3.Angle(direction, transform.forward);

        if (_angleToDestination < 5f)
        {
            _isPrepareToMove = false;
            SetCharacterDestination(_targetPoint);
        }
        else
        {
            RotateCharacter(_targetPoint);
        }
    }

    public override void SetDistinationPosition(Ray ray)
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            StopNavAgent();
            _targetPoint = ray.GetPoint(hitdist);
            _isPrepareToMove = true;
        }
    }

    public override void OrientateHero(Ray ray)
    {
        //base.OrientateHero(ray);
    }
}
