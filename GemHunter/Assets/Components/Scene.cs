using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    private bool isEnd;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Gem[] gems = GameObject.FindObjectsOfType<Gem>();

        if (gems.Length <= 0 && !isEnd)
        {
            isEnd = true;
            Debug.Log("WIN");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }

}
