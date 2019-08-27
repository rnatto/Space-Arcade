using UnityEngine;
using System.Collections;

public class Scr_Shield : MonoBehaviour
{
    public float speed_player = 15;
    private float time;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(
            x * Time.deltaTime * speed_player,
            y * Time.deltaTime * speed_player)
            );
        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp(transform.position.y, topBorder + 2, bottomBorder - 2)
            );

        if (transform.position.x == leftBorder)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        else if (transform.position.x == rightBorder)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if(time > 1)
        {
            GameObject.Find("Player").GetComponent<Scr_Control>().Contador();
            Destroy(gameObject);
        }
    }
}
