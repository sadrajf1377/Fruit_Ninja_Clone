using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.parent.rotation = Quaternion.LookRotation(new Vector3(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y, 0));
    }
}
