using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType {
    horizontal, vertical
}

public class Platform : Controllable
{

    public MoveType moveType;
    public bool carryThePlayer;

    Rigidbody2D rigidbody2d;
    float speed = 5;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(rigidbody2d.velocity != Vector2.zero) rigidbody2d.velocity = Vector2.zero;

        if(GameManager.activeControllable != this) return;

        if(moveType == MoveType.horizontal){
            MoveTypeHorizontal();
        }
    }

    void MoveTypeHorizontal(){
        if(Input.GetKey(KeyCode.A)){
            rigidbody2d.MovePosition(transform.position + Vector3.left * Time.deltaTime * speed);
            
        }
        if(Input.GetKey(KeyCode.D)){
            rigidbody2d.MovePosition(transform.position + Vector3.right * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(!other.gameObject.CompareTag("Player")) return;
        
        if(carryThePlayer){
            other.transform.GetComponentInParent<Player>().Brake(other.gameObject);
            other.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if(!other.gameObject.CompareTag("Player")) return;

        
        other.transform.SetParent(null);
    }
}
