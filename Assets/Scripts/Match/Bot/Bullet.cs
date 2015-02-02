using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Bullet : MonoBehaviour
{
    public int rotationSpeed = 500;
    public Explosion explosion;

    bool exploded = false;
    Rigidbody2D rigidBody2D;
    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // face direction of movement
        var velocity = rigidbody2D.velocity;
        if (velocity.magnitude > 1)
        {
            var angle = Mathf.Atan2(velocity.y, velocity.x) * 180f / Mathf.PI;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
            Explode();
    }

    public void Explode()
    {
        if (!exploded)
        {
            exploded = true;

            rigidBody2D.isKinematic = true;
            spriteRenderer.enabled = false;
            var explosionInstance = Instantiate(explosion, transform.position, transform.rotation) as Explosion;
            explosionInstance.Creator = this;
        }
    }

    public void Remove()
    {
        Destroy(this);
    }
}
