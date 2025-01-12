using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactLine : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public TMP_Text Text => text;

    [SerializeField] private TMP_Text idText;
    public TMP_Text IDText => idText;

    [SerializeField] private Button button;
    public Button Button => button;

    [SerializeField] private Image loadingCircle;
    public Image LoadingCircle=> loadingCircle;

 
}
