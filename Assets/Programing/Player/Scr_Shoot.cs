using UnityEngine;
using System.Collections;

public class Scr_Shoot : MonoBehaviour{
    public float speed_shoot = 10;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        transform.Translate(new Vector2(0, speed_shoot * Time.deltaTime));

        if (transform.position.y > topBorder-1)
        {
            GameObject.Find("Score").GetComponent<Scr_Score>().Combo0();
            Destroy(gameObject);
        }
	}
}
