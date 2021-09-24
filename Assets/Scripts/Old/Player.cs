using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject gunSprite;
    [SerializeField] private CanvasScript canvas;
    [SerializeField] private float rotSpeed = 0.2f;
    // Start is called before the first frame update

    [SerializeField] private GameObject deadPanel;

    private bool afterPause=false;
    private Vector2 pauseVelocity;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //transform.position = new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-5f, 5f));
        rb.AddForce(new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f)));
        rotSpeed *= Random.Range(0, 2) * 2 - 1;
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
            transform.Rotate(0, 0, rotSpeed);

            //transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), Mathf.Clamp(transform.position.y, -5f, 5f));

            Vector2 relativePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            gunSprite.transform.right = relativePos.normalized;

            if (transform.position.x > 9f || transform.position.x < -9f ||
                transform.position.y > 5f || transform.position.y < -5f) Dead();
            if (canvas.o2Level() <= 0f) Dead();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("o2cell"))
        {
            Destroy(collision.gameObject);
            canvas.AddO2();
        }
        else if (collision.CompareTag("Evil") || collision.CompareTag("Hole"))
        {
            Dead();
        }
    }


    private void Dead()
    {
        deadPanel.SetActive(true);
        MenuController.isPause = true;
        Destroy(this.gameObject);
    }
}
