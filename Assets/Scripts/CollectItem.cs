using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour, IItem
{
    public static event Action<int> OnItemCollect;
    public int worth = 5;
    public void Collect()
    {
        OnItemCollect.Invoke(worth);
        SoundEffectManager.Play("Item");
        Destroy(gameObject);
    }
}