using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
 
public class Scr_Boss_1 : MonoBehaviour {
    public float time = 4;
    public int speedDown = 2;
    public int BossLife = 400;
    public int cond = 0;
    public GameObject Boss_power;
    public int c;
    public int a=0;//inverte x
    public GameObject Explosion;
    private Animator Damage;
    public float t = 0;
    public int speedX = 5;

    // Use this for initialization
    void Start()
    {
        Damage = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Shoot")
        {
            Destroy(coll.gameObject);
            GameObject.Find("Controlador").GetComponent<Scr_MusicControl>().Explosion();
            BossLife -= 1;
            t += Time.deltaTime;
        }
            
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<Scr_Control>().life -= 1;

        }
    }
    // Update is called once per frame
    void Update () {
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        transform.Translate(new Vector2(0.1f * speedX * Time.deltaTime * a, -0.1f * speedDown * Time.deltaTime));
        if (cond == 1 && transform.position.y > 5) {
            speedDown = 8;
            BossLife = 400;
        } else if (transform.position.y < 5){
            speedDown = 0;

            time += Time.deltaTime;
            if (time > 5 && c == 1)
            {
                Instantiate(Boss_power, new Vector2(transform.position.x, 6), Quaternion.identity);
                c = -1;
            }
            if (time > 10)
            {
                Instantiate(Boss_power, new Vector2(transform.position.x, 6), Quaternion.identity);
                time = 0;
                c = 1;
            }
            if (BossLife <= 200 && a == 0)
                a = 1;
            if (transform.position.x < leftBorder)
                a = 1;
            if (transform.position.x > rightBorder)
                a = -1;

            if (BossLife <= 0)
            {
                Instantiate(Explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Destroy(gameObject);
                SceneManager.LoadScene(3);
            }
            if(t > 0){
                t += Time.deltaTime;
                Damage.SetBool("Damage", true);
                if (t >= 0.05){
                    Damage.SetBool("Damage", false);
                    t = 0;
                }
            }

        }
	}
}
