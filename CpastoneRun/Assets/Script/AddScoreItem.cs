using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreItem : Item
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.tag == "Player" && gameObject.tag == "AddScoreItem")
        {
            GameManager.Instance.addItemScore(5f);
        }
    }
}