using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletText : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        _wallet.Added += OnCoinAdded;
    }

    private void OnDisable()
    {
        _wallet.Added -= OnCoinAdded;
    }

    private void OnCoinAdded(int count)
    {
        _text.text = count.ToString();
    }
}