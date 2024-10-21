using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory_fruits : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject torn_fruit;
    public spawn_fruits sp;
    Rigidbody rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
    }
    private void Update()
    {

        if(transform.position.y<=sp.left_pos.y-1.5f)
        {

            sp.update_health();
            Destroy(gameObject);
        }
        rg.isKinematic = sp.fruits_rg_iskinematic;
    }
    
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0))
        {
            Destroy(GetComponent<BoxCollider>());

            sp.update_score();
            GameObject g=  Instantiate(torn_fruit, transform.position, Quaternion.identity);
             Vector3 pos =Camera.main.ScreenToWorldPoint(Input.mousePosition);

            g.transform.right = new Vector3(pos.x - transform.position.x, pos.y - transform.position.y, g.transform.right.z);
            Destroy(gameObject);
        }
    }
    
}
