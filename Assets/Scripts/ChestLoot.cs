using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootEntry
{
    public GameObject lootPrefab;
    [Range(0f, 100f)]
    public float dropChance = 50f; // Percentage (0-100)
    public int minQuantity = 1;
    public int maxQuantity = 1;
}

public class ChestLoot : MonoBehaviour
{
    public GameObject Info;
    [Header("Loot Table")]
    public List<LootEntry> lootTable = new List<LootEntry>();

    [Header("Sprites")]
    public Sprite closedSprite;
    public Sprite openSprite;

    [Header("Settings")]
    public float lootDropRadius = 0.5f;
    public float interactRange = 1.5f;

    private bool _isOpen = false;
    private bool _playerNearby = false;
    private SpriteRenderer _spriteRenderer;
    private Transform _player;

    [Header("Audio")]
    public AudioSource chestSound; // Assign your AudioSource component here

    void Start()
    {
        Info.SetActive(false);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (closedSprite != null)
            _spriteRenderer.sprite = closedSprite;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            _player = playerObj.transform;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        if (_isOpen || _player == null) return;

        float dist = Vector2.Distance(transform.position, _player.position);
        _playerNearby = dist <= interactRange;

        if (_playerNearby && !_isOpen) Info.SetActive(true);
        if (!_playerNearby) Info.SetActive(false);

        // Changed to GetButtonDown to prevent the chest from "machine-gunning" sound/loot
        if (_playerNearby && Input.GetButtonDown("Use"))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        Info.SetActive(false);
        _isOpen = true;

        // Play the sound
        if (chestSound != null)
        {
            chestSound.Play();
        }

        // Swap sprite
        if (openSprite != null)
            _spriteRenderer.sprite = openSprite;

        // drop loot
        foreach (LootEntry entry in lootTable)
        {
            int quantity = Random.Range(entry.minQuantity, entry.maxQuantity + 1);
            for (int i = 0; i < quantity; i++)
            {
                float roll = Random.Range(0f, 100f);
                if (roll <= entry.dropChance && entry.lootPrefab != null)
                {
                    Vector2 offset = Random.insideUnitCircle * lootDropRadius;
                    Vector3 spawnPos = transform.position + new Vector3(offset.x, offset.y, 0);
                    Instantiate(entry.lootPrefab, spawnPos, Quaternion.identity);
                }
            }
        }
    }
}