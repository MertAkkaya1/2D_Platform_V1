using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{    
    private float MovementSpeedMultiplier = 10;

    public int Life;

    private Vector2 defaultPosition;

    public Rigidbody2D ObjRigidbody;

    public bool isJumping = false;

    private int _Coin;

    private Finish_StartControllerScript ControllerScript;

    private void Awake()
    {
        GameObject controllerGameobject = GameObject.FindWithTag("controller");
        if (controllerGameobject == null)
        {
            Debug.LogError("hata");
            return;
        }

        ControllerScript = controllerGameobject.GetComponent<Finish_StartControllerScript>();
        if (ControllerScript == null)
        {
            Debug.LogError("hata");
            
        }
    }

    private void Start()
    {
        ObjRigidbody = GetComponent <Rigidbody2D>();
        defaultPosition = transform.position;
        ControllerScript.SetLifeCount("Life: " + Life.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 MovementVector = new Vector3(horizontalMovement, 0, 0);

        // alttaki transform.Trnslate kodu karakterimizi hareket ettiriyor fakat bu daha çok isinlama gibi
        //transform.Translate(new Vector3(horizontalMovement, 0, 0) * Time.deltaTime);

        if (isJumping == true)
        {
            Vector3 JumpVector = new Vector3(0, 4, 0);
            ObjRigidbody.AddForce(JumpVector, ForceMode2D.Impulse); // Force surekli uygulanan guc / Impulse tum gucu bir frame de uygular
            isJumping = false;
        }

        ObjRigidbody.AddForce(MovementVector * MovementSpeedMultiplier, ForceMode2D.Force); // Force surekli uygulanan guc / Impulse tum gucu bir frame de uygular

        if (horizontalMovement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            //Destroy(gameObject);
            Life--;
            if (Life == 0)
            {
                //Destroy(gameObject);
                ControllerScript.EndGame();
            }
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Life--;
            ControllerScript.SetLifeCount("Life: " + Life.ToString());
            if (Life == 0)
            {
                //Destroy(gameObject);
                ControllerScript.EndGame();
            }
        }

    }      

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag =="BronzeTag")
        {
            _Coin += 1;
        }
        if (col.gameObject.tag == "SilverTag")
        {
            _Coin += 3;
        }
        if (col.gameObject.tag == "GoldTag")
        {
            _Coin += 5;
            
        }
        
        
    }
}
