using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
  public float RueckWurf;

    // Start is called before the first frame update
      private void OnTriggerEnter2D(Collider2D collision)
    {
      collision.GetComponent<PlayerMovement>().horizontalMove = 0;
      collision.GetComponent<PlayerMovement>().currentSpeed = 0;
      collision.transform.position += new Vector3(RueckWurf,0,0);
    }
}
