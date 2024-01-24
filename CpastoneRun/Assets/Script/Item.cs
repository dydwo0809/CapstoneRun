using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggrEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.addItemScore(5f);
            Destroy(gameObject);
        }
    }
}
