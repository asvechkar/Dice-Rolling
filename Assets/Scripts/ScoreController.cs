using System;
using Events;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        EventBus.Subscribe<ScoreChangedEvent>(ScoreChanged);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<ScoreChangedEvent>(ScoreChanged);
    }

    private void ScoreChanged(ScoreChangedEvent evt)
    {
        text.text = evt.Score.ToString();
    }
}