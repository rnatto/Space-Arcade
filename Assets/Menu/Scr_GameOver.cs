using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scr_GameOver : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene(0);
    }
}   
