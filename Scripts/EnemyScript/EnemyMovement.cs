using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    //public Vector2 EnemyMoveOffsetPosition;

    //public Vector2 EnemyMoveToPosition;

    //public Vector2 EnemyMoveFromPosition;

    public Vector2 startPosition;

    public Vector2 EndPosition;

    //public Vector2 Movement;

    void Start()
    {
        //EnemyMoveFromPosition = transform.position;
        //EnemyMoveToPosition = EnemyMoveFromPosition + EnemyMoveOffsetPosition;
        EnemyMoveTween();
    }
        
    public void EnemyMoveTween()
    {
        transform.DOMove(EndPosition, 1f).From(startPosition).SetLoops(-1, LoopType.Yoyo);

    }
}
