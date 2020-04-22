using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    private int _count;
    [SerializeField] Text _coinCountText;

    public void AddCoin()
    {
        _count++;
        _coinCountText.text = _count.ToString();
    }
}
