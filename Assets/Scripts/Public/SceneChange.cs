using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (gameObject.tag == "DaughterTrigger")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("DaughterScene");
            }
            else if (gameObject.tag == "MapTrigger")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MapScene");
            }
            else if (gameObject.tag == "LivingroomTrigger")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("LivingroomScene");
            }
        }
    }

}
