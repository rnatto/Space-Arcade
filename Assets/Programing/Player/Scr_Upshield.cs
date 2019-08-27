using UnityEngine;
using System.Collections;

public class Scr_Upshield : MonoBehaviour
{
    public GameObject Up;
    public int speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag != "Upgrade"  && gameObject == null)
        {
            Instantiate(Up, new Vector2(0, 12), Quaternion.identity);
        }
        if(tag == "Upgrade")
            transform.Translate(new Vector2(0, -Time.deltaTime * speed));
    }
}
