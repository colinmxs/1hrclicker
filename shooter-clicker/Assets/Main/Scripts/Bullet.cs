using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Public vars
    public float speed;
    public float damage;

    // Private vars
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 10) this.gameObject.SetActive(false);
        rb.MovePosition(rb.transform.position + new Vector3(1,0,0) * speed * Time.fixedDeltaTime);
    }

    private void OnCollision2D(Collider other)
    {
        Debug.Log("Collision");
    }
}
