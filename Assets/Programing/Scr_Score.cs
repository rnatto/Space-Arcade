using UnityEngine;
using System.Collections;

public class Scr_Score: MonoBehaviour{
    public GUIStyle estilo;
    public int score;
    private int cont = 1;
    public int Combo = 0;
    private int comboMult = 1;
    public float Shield;
    void OnGUI()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null)
            Shield = player.GetComponent<Scr_Control>().contador;
        int life = 0;
        if (player != null)
            life = player.GetComponent<Scr_Control>().life;
        GUI.Label(new Rect(5, 0, 100, 20), "LIFE: " + life, estilo);
        GUI.Label(new Rect(100, 0, 100, 20), "SCORE  " + score, estilo);
        GUI.Label(new Rect(200, 0, 100, 20), "COMBO: " + Combo, estilo);
        GUI.Label(new Rect(5, 10, 100, 20), "+UP: " + 1000*cont, estilo);
        GUI.Label(new Rect(230, 300, 100, 20), "SHIELD: " + Shield, estilo);

        if (Combo > 10)
        {
            comboMult = Combo / 10;
            if (Combo > 50)
                comboMult = 5;
        }
        if (score == 1000*cont)
        {
            player.GetComponent<Scr_Control>().life++;
            cont++;
        }
    }
    public void ScorePlus()
    {
        score += 50*comboMult;
        Combo++;
    }
    public void Combo0()
    {
        Combo = 0;
    }

}
