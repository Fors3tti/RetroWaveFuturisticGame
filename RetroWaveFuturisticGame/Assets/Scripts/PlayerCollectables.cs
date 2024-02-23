using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerCollectables : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    public int moneyNumber;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GameObject.FindGameObjectWithTag("MoneyUI").GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();
    }

    private void UpdateText()
    {
        textComponent.text = moneyNumber.ToString();
    }

    public void MoneyCollected()
    {
        moneyNumber += 1;
        UpdateText();
    }
}
