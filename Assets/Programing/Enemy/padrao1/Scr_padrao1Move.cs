using UnityEngine;
using System.Collections;

public class Scr_padrao1Move : MonoBehaviour
{
    public int SpeedShoot = 7;
    public float angulo;
    public bool cond;
    private float timeDamage = 0;
    public GameObject damage;

    // Use this for initialization
    void Start()
    {
        if (GameObject.FindWithTag("Enemy3") != null)
        {
            Rotate(angulo);
        }
    }
    void Rotate(float ang)
    {
        transform.Rotate(new Vector3(0, 0, ang));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, -SpeedShoot * Time.deltaTime));


    }
}
