using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yaldaTrigger : MonoBehaviour
{
    public GameObject BM;
    public GameObject Block;
    void Start()
    {
         Block.SetActive(false);
        BM.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BM.SetActive(true);
            Block.SetActive(true);
        }
    }

}
