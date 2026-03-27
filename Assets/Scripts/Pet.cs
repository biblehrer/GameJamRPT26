using System.Collections;
using UnityEngine;
using TMPro; // If using legacy UI Text instead, use UnityEngine.UI

public class Pet : MonoBehaviour
{
    [Header("Find Dog")]
    public float interactRange = 3f;

    [Header("Follow Settings")]
    public float followSpeed = 3f;
    public float followStopDistance = 1.5f; // Pet stops when this close to player

    [Header("UI")]
    [Tooltip("Assign a TextMeshProUGUI element in the Canvas")]
    public TextMeshProUGUI discoveryText;
    public float textDisplayDuration = 3f;

    [Header("Sprites")]
    public Sprite idleSprite;
    public Sprite followingSprite;

    private SpriteRenderer spriteRenderer;


    private Transform player;
    private bool isFound = false;
    private bool isFollowing = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.transform;

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (discoveryText != null)
            discoveryText.gameObject.SetActive(false);

        // Set first sprite
        if (spriteRenderer != null && idleSprite != null)
            spriteRenderer.sprite = idleSprite;
    }
    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //E to collect
        if (!isFound)
        {
            if (distanceToPlayer <= interactRange && Input.GetKeyDown(KeyCode.E))
            {
                DiscoverPet();
            }
        }

        // ── After found: follow the player 
        if (isFollowing)
        {
            FollowPlayer(distanceToPlayer);
        }

        void DiscoverPet()
        {
            isFound = true;
            isFollowing = true;

            Debug.Log("You Found Struppi!");

            // switch to walk sprite
            if (spriteRenderer != null && followingSprite != null)
            {
                spriteRenderer.sprite = followingSprite;
            }

            if (discoveryText != null)
            {
                discoveryText.text = "You Found Struppi!";
                StartCoroutine(ShowDiscoveryText());
            }
        }

        void FollowPlayer(float distanceToPlayer)
        {
            if (player == null) return;

            float directionX = player.position.x - transform.position.x;
            float targetYAngle = directionX > 0 ? 0f : 180f;

            Quaternion targetRotation = Quaternion.Euler(0, targetYAngle, 0);
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * followSpeed
            );
            float distance = Vector2.Distance(transform.position, player.position);

            if (distance > followStopDistance)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    followSpeed * Time.deltaTime
                );
            }
        }


        IEnumerator ShowDiscoveryText()
        {
            discoveryText.gameObject.SetActive(true);

            yield return new WaitForSeconds(textDisplayDuration);

            discoveryText.gameObject.SetActive(false);
        }
    }
}