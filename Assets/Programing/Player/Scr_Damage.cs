using UnityEngine;
using System.Collections;

public class Scr_Damage : MonoBehaviour {

    public float timeDamage = 0;
    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update()
    {
        timeDamage += Time.deltaTime;
        if (timeDamage >= 0.05)
        {
            Destroy(GameObject.FindWithTag("Damage"));
            timeDamage = 0;
        }
    }
}
