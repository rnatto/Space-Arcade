using UnityEngine;

public class Scr_Move_Cos : MonoBehaviour
{
    public float speed_enemy = 8;
    public float speed_down = 2;
    public float speed_downGame = 2;
    public int c = 1;//c = constant to invert sin
    public int Score = 0;
    public int b = 1;
    public int EnemyLife = 3;
    public int Tag = -1;
    private bool InGame;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Shoot" || coll.tag == "Shield")
        {
            if (coll.tag == "Shield"){
                GameObject.Find("Player").GetComponent<Scr_Control>().Contador();
                EnemyLife = 1;
            }
            GameObject.Find("Score").GetComponent<Scr_Score>().ScorePlus();
            GameObject.Find("Controlador").GetComponent<Scr_MusicControl>().Explosion();
            Destroy(coll.gameObject);
            EnemyLife--;
        }
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<Scr_Control>().Damage(Tag);
            Destroy(gameObject);
            if (Score > 50)
                Score -= 50;
        }
    }
    void Start()
    {

    }
    void Update()
    {
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        float x = transform.position.x;
        float y = transform.position.y;
        //Move_enemy
        if (transform.position.y > topBorder)
            transform.Translate(new Vector2(0, -0.1f * speed_down * Time.deltaTime));
        if (transform.position.y < topBorder && transform.position.x < leftBorder || transform.position.y < topBorder && transform.position.x > rightBorder )
            transform.Translate(new Vector2(0.1f * speed_enemy * Time.deltaTime * c, 0));

        if (transform.position.y < topBorder + 2 && transform.position.x > leftBorder - 1 || InGame == true) {
            InGame = true;
            transform.Translate(new Vector2(b * c * speed_enemy * Time.deltaTime , speed_downGame * speed_enemy * Time.deltaTime * -Mathf.Cos(  transform.position.x * Mathf.PI / 5)));
        } if (transform.position.x < leftBorder)
            c = 1;
        if (transform.position.x > rightBorder)
            c = -1;
        if (transform.position.y < bottomBorder - 2)
            Destroy(gameObject);
        if (EnemyLife <= 0)
            Destroy(gameObject);


    }
}
