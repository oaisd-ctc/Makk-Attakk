using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    Animator myAnimator;
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }
    public void RestartSpecific(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

   
}
