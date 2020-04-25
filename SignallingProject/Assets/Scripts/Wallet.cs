using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public UnityAction<int> Added;
    private int _count;
   
    public void AddCoin()
    {
        _count++;
        Added?.Invoke(_count);
    }
}
