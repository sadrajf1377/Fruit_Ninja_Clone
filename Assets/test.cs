using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] Transform blade;
    [SerializeField] Vector3 forward;
    [SerializeField] Transform cube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        blade.position =Camera.main.WorldToScreenPoint( Input.mousePosition);
        cube.LookAt(Input.mousePosition);
        forward = blade.forward;
        
    }
}
