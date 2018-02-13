using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKIeasy : MonoBehaviour
{

    private Rigidbody2D enemy;
    public float speed;
    public float maxSpeed;
    Vector2 move = new Vector2(1, 0);

    public int schaden;
    private SpriteRenderer mySpriteRenderer;

    


    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

       
    }


    // Update is called once per frame
    void Update()
    {

        


        enemy.position += move * speed;
        enemy.velocity = (enemy.velocity.x > maxSpeed) ? new Vector2(maxSpeed, enemy.velocity.y) : enemy.velocity;
        enemy.velocity = (enemy.velocity.x < -maxSpeed) ? new Vector2(-maxSpeed, enemy.velocity.y) : enemy.velocity;
            
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameManager.instance.health -= schaden;
        }
        else { move.x *= -1; }
    }


}
