using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMotion : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject o2cell;
    [SerializeField] private float speed, amplitude;
    private Rigidbody2D evil;
    private Transform player;
    private float randStartPos;

    [SerializeField] GameObject particle;

    private int number;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        number = Random.Range(0, sprites.Length);
        sprite.sprite = sprites[number];
        
        player = GameObject.Find("Player").transform;
        evil = GetComponent<Rigidbody2D>();
        randStartPos = Random.Range(0, 360f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!MenuController.isPause)
        {
            Vector3 moveDir = player.position - transform.position;
            moveDir.Normalize();
            Vector3 normal = Vector2.Perpendicular(new Vector2(moveDir.x, moveDir.y));
            normal.Normalize();

            evil.velocity = (moveDir + normal * amplitude * Mathf.Sin((Mathf.Repeat(Time.time * 100f, 360f) + randStartPos) * Mathf.Deg2Rad)) * speed * Time.fixedDeltaTime;
        }
        else
        {
            evil.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hole"))
        {

            if (number == sprites.Length - 1)
            {
                CanvasScript.AddScore(10);
                Instantiate(o2cell, transform.position, Quaternion.identity);
            }
            else
            {
                if (Random.Range(0, 10) < 2)
                {
                    Instantiate(o2cell, transform.position, Quaternion.identity);
                }
                CanvasScript.AddScore(1);
            }
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
