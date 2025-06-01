using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem Item = collision.GetComponent<IItem>();
        if(Item != null)
        {
            Item.Collect();
        }
    }
}
