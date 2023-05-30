using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollildingWith : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject redBull;
    private void Start()
    {
        FindObjectOfType<GameObject>(redBull);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("redbull");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
