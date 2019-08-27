using UnityEngine;
using System.Collections;

public class Scr_EShoot : MonoBehaviour
{
    public int SpeedShoot = 7;
    public float angulo;
    public bool cond;
    private float timeDamage = 0;
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
            if (gameObject.tag == "ShootBlue")
                Tag = 0;
            else if (gameObject.tag == "Enemy_shoot")
                Tag = 1;
            coll.gameObject.GetComponent<Scr_Control>().Damage(Tag);
            Destroy(gameObject);

        }
    }

    // Use this for initialization
    void Start()
    {
        if (GameObject.FindWithTag("Enemy") != null)
        {
            angulo = GameObject.FindWithTag("Enemy").GetComponent<Scr_Move_SH>().angulo;
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
