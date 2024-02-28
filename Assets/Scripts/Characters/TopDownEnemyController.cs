using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownEnemyController : TopDownCharacterController
{
    CharacterGameManager characterGameManager;
    protected Transform ClosestTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        characterGameManager = CharacterGameManager.instance;
        ClosestTarget = characterGameManager.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
}