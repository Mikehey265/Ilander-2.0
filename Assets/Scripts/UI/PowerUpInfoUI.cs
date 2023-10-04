using System;
using TMPro;
using UnityEngine;

public class PowerUpInfoUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform powerUpTemplate;
    [SerializeField] private TextMeshProUGUI powerUpName;

    private void Awake()
    {
        powerUpTemplate.gameObject.SetActive(false);
    }
}
