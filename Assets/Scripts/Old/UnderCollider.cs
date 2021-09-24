using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderCollider : MonoBehaviour
{
    [SerializeField] private GameObject blackHole;
    [SerializeField] private Transform corner;
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject particle;
    private void OnMouseDown()
    {
        if (!MenuController.isPause)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!(mousePos.x < corner.position.x && mousePos.y > corner.position.y))
            {   
                Instantiate(blackHole, new Vector3(mousePos.x, mousePos.y, -1), Quaternion.identity);
                Instantiate(particle, gun.position, Quaternion.identity);
            }
        }
    }
}
