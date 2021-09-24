using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o2cellScript : MonoBehaviour
{
    [SerializeField] private float mass;
    [SerializeField] private float _rotateSpeed;

    private float distance, force;
    private Rigidbody2D rb;
    private Transform player;

    private bool afterPause = false;
    private Vector2 pauseVelocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MenuController.isPause)
        {
            if (afterPause)
            {
                afterPause = false;
                rb.velocity = pauseVelocity;
            }
            transform.Rotate(0, 0, _rotateSpeed * Time.fixedDeltaTime);

            Vector2 motionVector = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

            distance = Mathf.Clamp(motionVector.magnitude, 0.2f, 10f);
            motionVector.Normalize();

            force = mass * Time.fixedDeltaTime / Mathf.Pow(distance, 2);

            rb.AddForce(motionVector * force);
        }
        else
        {
            if (!afterPause)
            {
                afterPause = true;
                pauseVelocity = rb.velocity;
            }
            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CameraCollider")) { Destroy(this.gameObject); }
    }
}
