using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerScoreVisual : MonoBehaviour
{
    [SerializeField] private PlayerScore _score;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _score.SetedScore += OnSetedScore;
    }

    private void OnDisable()
    {
        _score.SetedScore -= OnSetedScore;     
    }

    private void OnSetedScore(int score)
    {
        _text.text = score.ToString();
    }
}
