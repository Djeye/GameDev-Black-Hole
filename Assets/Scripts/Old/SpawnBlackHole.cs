using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlackHole : MonoBehaviour
{
    [SerializeField] private float spaceSpeed_x;
    [SerializeField] private float spaceSpeed_y;
    private float yPos = 0f, startYPos;
    private float xPos = 0f, startXPos;

    private void Awake()
    {
        startYPos = transform.position.y;
        startXPos = transform.position.x;
    }

    private void Update()
    {
        if (!MenuController.isPause)
        {
            yPos += spaceSpeed_y * Time.fixedDeltaTime;
            xPos += spaceSpeed_x * Time.fixedDeltaTime;
            yPos = Mathf.Repeat(yPos, 12);
            xPos = Mathf.Repeat(xPos, 24);

            transform.position = new Vector3(-xPos + startXPos, -yPos + startYPos, 1);
        }
    }
}
