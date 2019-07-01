using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGame : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
