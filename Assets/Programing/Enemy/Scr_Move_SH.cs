using UnityEngine;

public class Scr_Move_SH : MonoBehaviour {
    public float speed_enemy = 8;
    public float speed_down = 2;
    public float speed_downGame = 10;
    public int c = 1;//c = constant to invert sin
    public int a = 0;
    public int Score = 0;
    private float time1shoot = 0;
    public float Px;
    public float Py;
    public GameObject EnemyShoot;
    public float angulo = 0;
    public int EnemyLife = 1;
    public int Tag = -1;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Shoot" || coll.tag == "Shield")
        {
            if(coll.tag == "Shield"){
                GameObject.Find("Player").GetComponent<Scr_Control>().Contador();
               EnemyLife = 0;
            }
        GameObject.Find("Score").GetComponent<Scr_Score>().ScorePlus();
            GameObject.Find("Controlador").GetComponent<Scr_MusicControl>().Explosion();
            Destroy(coll.gameObject);
            EnemyLife--;
        }
        if(coll.tag == "Player"){
            coll.gameObject.GetComponent<Scr_Control>().Damage(Tag);
            Destroy(gameObject);
            if(Score > 50)
                Score -= 50;
        }
    }
    void Start () {

	}
    void Update() {
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        var  bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        //Move_enemy
        if (transform.position.y < topBorder){
            transform.Translate(new Vector2(0, -0.1f * speed_downGame * Time.deltaTime));

        }
        if (transform.position.y > topBorder) { 
            transform.Translate(new Vector2(0, -0.1f * speed_down * Time.deltaTime));
            time1shoot = 0.1f;
        }
        if (transform.position.y < topBorder && transform.position.x < leftBorder || transform.position.y < topBorder && transform.position.x > rightBorder)
            transform.Translate(new Vector2(0.1f * speed_enemy * Time.deltaTime * c, 0));
        if (transform.position.y < topBorder + 2.2 && transform.position.x > leftBorder - 1){
            transform.Translate(new Vector2(c * speed_enemy  * Time.deltaTime, speed_enemy * Time.deltaTime * Mathf.Sin(2 * transform.position.x * Mathf.PI / 5)));
            speed_down = speed_downGame;
        }
        if (transform.position.x < leftBorder)
            c = 1;
        if (transform.position.x > rightBorder)
            c = -1;
        if (transform.position.y < bottomBorder - 2)
            Destroy(gameObject);
        time1shoot += Time.deltaTime;
        if (time1shoot > 0.6)
        {

            Px = GameObject.Find("Player").GetComponent<Scr_Control>().Px;
            Py = GameObject.Find("Player").GetComponent<Scr_Control>().Py;
            angulo = ((Mathf.Atan((transform.position.x - Px) / (transform.position.y - Py))) * Mathf.Rad2Deg * -1);
            Instantiate(EnemyShoot, new Vector2(transform.position.x, transform.position.y - 0.914f), Quaternion.identity);
            time1shoot = 0;
        }
        if (EnemyLife <= 0)
            Destroy(gameObject);


    }
}
