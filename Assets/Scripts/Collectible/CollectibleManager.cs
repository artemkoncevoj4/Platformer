using System;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    public event Action<int> OnCollectibleCollected;

    private int _collectedCount = 0;
    private int _totalCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        var collectibles = FindObjectsByType<Collectible>(FindObjectsSortMode.None);
        _totalCount = collectibles.Length;
        _collectedCount = 0;
        OnCollectibleCollected?.Invoke(_collectedCount);
    }

    public void Collect(Collectible item)
    {
        _collectedCount++;
        OnCollectibleCollected?.Invoke(_collectedCount);
        Debug.Log($"Собран предмет! Всего: {_collectedCount}/{_totalCount}");
    }

    public int GetCollected() => _collectedCount;
    public int GetTotal() => _totalCount;
}