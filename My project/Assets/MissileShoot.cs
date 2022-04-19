using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShoot : MonoBehaviour
{
    public Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        print("MISSILEEEE");
        rb2D.velocity = new Vector2(10f, transform.position.y);
        /*rb2D.velocity = new Vector2(10000, transform.position.y).normalized;
        transform.position = new Vector2(10000, transform.position.y).normalized;*/
    }

    private void fixedUpdate()
    {
        //rb2D.velocity = new Vector2(100, transform.position.y);
        //transform.position = new Vector2(10000, transform.position.y).normalized;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        
        Destroy(collision.gameObject);

    }
}