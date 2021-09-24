using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleScript : MonoBehaviour
{
    //[SerializeField] 
    private Rigidbody2D player;
    private Rigidbody2D o2cell;
    [SerializeField] private float mass, o2ForceFactor, destroyTime;

    private float zRot, speedRot = 0.5f;
    private float force, distance, o2force, o2distance; 

    private Vector2 acceleration, lastVelocity;
    // Update is called once per frame

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        zRot = Random.Range(0f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, zRot);
    }

    void FixedUpdate()
    {
        if (!MenuController.isPause)
        {
            PlayerGravitation();

            transform.Rotate(0, 0, speedRot);
        }
    }

    private void PlayerGravitation()
    {
        //o2cell = GameObject.Find("o2sell").GetComponent<Rigidbody2D>();
        Vector2 motionVector = new Vector2(transform.position.x - player.position.x, transform.position.y - player.position.y);

        distance = Mathf.Clamp(motionVector.magnitude, 0.2f, 10f);
        motionVector.Normalize();

        force = mass * Time.fixedDeltaTime / Mathf.Pow(distance, 2);

        player.AddForce(motionVector * force);
    }

    private void OnMouseDown()
    {
        if (!MenuController.isPause)
        {
            Destroy(this.gameObject);
        }
    }
}
