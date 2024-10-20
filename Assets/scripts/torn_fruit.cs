using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torn_fruit : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        foreach(var rig in GetComponentsInChildren<Rigidbody>())
        {
            rig.AddForce(rig.transform.up * 150);
        }
        Destroy(gameObject, 5);
    }
}
