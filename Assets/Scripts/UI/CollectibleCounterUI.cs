using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleCounterUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    void Start()
    {
        if (_text == null)
            _text = GetComponent<TextMeshProUGUI>();

        UpdateText(0, 0);

        if (CollectibleManager.Instance != null)
        {
            CollectibleManager.Instance.OnCollectibleCollected += OnCollected;
            var mgr = CollectibleManager.Instance;
            UpdateText(mgr.GetCollected(), mgr.GetTotal());
        }
    }

    void OnCollected(int count)
    {
        UpdateText(count, CollectibleManager.Instance.GetTotal());
    }

    void UpdateText(int collected, int total)
    {
        _text.text = $"Игрушки: {collected}/{total}";
    }

    void OnDestroy()
    {
        if (CollectibleManager.Instance != null)
            CollectibleManager.Instance.OnCollectibleCollected -= OnCollected;
    }
}