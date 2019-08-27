using UnityEngine;
using System.Collections;

public class Scr_PowerBoss : MonoBehaviour
{
    public float Speed_power = 25;
    public int c;
    public int Tag = -1;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Shield")
        {
            GameObject.Find("Player").GetComponent<Scr_Control>().Contador();
            Destroy(gameObject);
        }
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<Scr_Control>().Damage(Tag);
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }
    void Update()
    {
        c = GameObject.Find("Boss_1").GetComponent<Scr_Boss_1>().c;
        transform.Translate(new Vector2(0, -0.1f * Speed_power * Time.deltaTime));
        transform.Rotate(new Vector3(0,0, Speed_power * Time.deltaTime * c));
    }
}
