using UnityEngine;
using System.Collections;

public class Scr_padrao1Col : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Shield"){
            GameObject.Find("Player").GetComponent<Scr_Control>().Contador();
            Destroy(gameObject);
        }if (coll.tag == "Player"){
            coll.gameObject.GetComponent<Scr_Control>().life -= 1;
            Destroy(gameObject);
        }
    }
}
