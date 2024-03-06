using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    // Start is called before the first frame update
    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLastWinner();
        if (lastWinner != "")
            uiWinner.text = $"Último vencedor: {lastWinner}";
        else 
            uiWinner.text = "";
    }

}
