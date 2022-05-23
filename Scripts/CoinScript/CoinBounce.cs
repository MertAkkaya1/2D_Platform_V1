using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinBounce : MonoBehaviour
{
    public Vector2 MoveOffsetPosition;

    public Vector2 MoveToPosition;

    public Vector2 MoveFromPosition;

    

    void Start()
    {
        MoveFromPosition = transform.position;
        MoveToPosition = MoveFromPosition + MoveOffsetPosition;
        MoveTween();
    }

    // Update is called once per frame
    public void MoveTween()
    {
        transform.DOMove(MoveToPosition, 1f).From(MoveFromPosition).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
                
    }
}
