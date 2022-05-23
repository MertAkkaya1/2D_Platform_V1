using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenMove : MonoBehaviour
{
    public Vector2 position1;

    public Vector2 position2;

    public Tween CurrentTween;
        

    public void Start()
    {
        TweenMove();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))  
        {
            // Input.GetKeyDown(KeyCode.Mouse0) mouse'a 1 kere basildigini alir
            // Input.GetKey(KeyCode.Mouse0) mouse'a basili tutuldugu surece girdi alir
            // Input.GetKeyUp(KeyCode.Mouse0) mouse'a 1 kere basilip birakildiktan sonra girdi alir
            CurrentTween.DOTimeScale(10f, 1f);
        }
    }

    public void TweenMove()
    {
        // pozisyon1den 2 ye 2 den 1 e gelis
        CurrentTween = transform.DOMove(position1, 1f).From(position2).SetDelay(2f).OnComplete(() =>
        {
            transform.DOMove(position2, 1f).From(position1);
        });

        //transform.DOMove(position1, 10f); // (gidecegi pozisyon, gidecegi pozisyona ne kadar surede gidecegi)
        //CurrentTween = transform.DOMove(position1, 1f).From(position2).SetDelay(5f); // pozisyon2 den pozisyon1'e hareket ettirmemizi sagliyor
        //transform.DOMove(position1, 1f).From(position2).SetLoops(4, LoopType.Yoyo); // pozisyon2 den pozisyon1'e oradan tekrar pozisyon2'ye 4 defa hareket ettirmemizi sagliyor

        //transform.DOMove(position1, 1f).From(position2).SetDelay(5f); // ustteki koda delay eklenmis hali
        //transform.DOMove(position1, 1f).OnComplete(() =>
        //{
        //onComplete ile pozisyon1'e gittikten sonra su su su islemleri yap diyebiliyoruz. Veya onComplete icine direk fonsiyon da verilebiliyor

        //});

        /*
         * OnComplete ile pozisyon2 den pozisyon1 e gidis 
         
        public void Start()
        {
            TweenMove(position1, position2);
        }

        public void TweenMove(Vector2 pos1, Vector2 pos2)
        {
            //transform.DOMove(position1, 10f); // (gidecegi pozisyon, gidecegi pozisyona ne kadar surede gidecegi)
            transform.DOMove(position1, 1f).From(position2); // pozisyon2 den pozisyon1'e hareket ettirmemizi sagliyor
                                                             //transform.DOMove(position1, 1f).From(position2).SetLoops(4, LoopType.Yoyo); // pozisyon2 den pozisyon1'e oradan tekrar pozisyon2'ye 4 defa hareket ettirmemizi sagliyor

            transform.DOMove(position1, 1f).OnComplete(() =>
            {
                //onComplete ile pozisyon1'e gittikten sonra su su su islemleri yap diyebiliyoruz. Veya onComplete icine direk fonsiyon da verilebiliyor
                transform.DOMove(position2, 1f);
            });
        }*/


    }
}
