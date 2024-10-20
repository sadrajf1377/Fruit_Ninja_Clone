using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class spawn_fruits : MonoBehaviour
{
   
    [SerializeField] Transform left, right;
    public static Vector3 left_pos, right_pos;
    [SerializeField] GameObject fruit_prefab;
    GameObject go;
    [SerializeField] GameObject background;
    [SerializeField] float width, height;
    int user_score=0, user_health=3;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] Transform health;
    [SerializeField] List<Texture2D> txtrs;
    public static int selected_level=0;
    private void Awake()
    {
        
        left_pos = new Vector3(0.03f, 0.05f, 2);
        right_pos = new Vector3(0.975f, 0.05f, 2);
        var spr = background.GetComponent<SpriteRenderer>().sprite;
        print(Sprite.Create(txtrs[selected_level], spr.rect, spr.pivot).texture);
        background.GetComponent<SpriteRenderer>().sprite = Sprite.Create(txtrs[selected_level], spr.rect,spr.pivot);

    }
    void Start()
    {
        Time.timeScale = 0.75f;
        StartCoroutine(create_fruits());
    }

    // Update is called once per frame
    void Update()
    {
        left.position = Camera.main.ViewportToWorldPoint(left_pos);
        right.position = Camera.main.ViewportToWorldPoint(right_pos);
        resize();



    }
    IEnumerator create_fruits()
    {
        for (; ; )
        {
            float time = Random.Range(0.5f, 3);
            
            yield return new WaitForSeconds(time);
            Vector3 inst_pos = new Vector3(Random.Range(left_pos.x, right_pos.x), right.position.y, right.position.z);
             go = Instantiate(fruit_prefab, inst_pos, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(0, 270, 0);
            go.GetComponent<Rigidbody>().angularVelocity += new Vector3(1, 1, 1);
            go.GetComponent<destory_fruits>().sp = this;
            go.GetComponent<destory_fruits>().enabled = true;
            go = null;
        }
    }
    private void OnDrawGizmos()
    {
       
    }
    void resize()
    {
        
        if (background == null) return;
        var sr = background.GetComponent<SpriteRenderer>();
        background.transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = background.transform.localScale;
        xWidth.x = (worldScreenWidth / width)*48;
        background.transform.localScale = xWidth;
        
        Vector3 yHeight = background.transform.localScale;
        yHeight.y = (worldScreenHeight / height)*48;
       background.transform.localScale = yHeight;
      
    }
    public void update_score()
    {
        user_score += 10;
        score.text = user_score.ToString();
        
    }
    public void update_health()
    {
        user_health -= 1;
        Destroy(health.GetChild(0).gameObject);
    }

}
