using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float normalSpeed = 5f; // Normal movement speed
    public float boostSpeed = 10f; // Boosted movement speed
    public float boostDuration = 2f; // How long the boost lasts
    public float boostCooldown = 5f; // Cooldown duration for the boost
    public Image boostIcon; // UI icon for boost status

    private float boostTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isBoosting = false;

    void Update()
    {
        HandleMovement();
        HandleBoost();
        UpdateBoostIcon();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        float speed = isBoosting ? boostSpeed : normalSpeed;
        Vector3 movement = new Vector3(moveX, 0, moveY) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    void HandleBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift) && cooldownTimer <= 0f && !isBoosting)
        {
            isBoosting = true;
            boostTimer = boostDuration;
        }

        if (isBoosting)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0f)
            {
                isBoosting = false;
                cooldownTimer = boostCooldown;
            }
        }

        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void UpdateBoostIcon()
    {
        if (boostIcon != null)
        {
            if (cooldownTimer > 0f)
            {
                boostIcon.gameObject.SetActive(false); // Hide icon during cooldown
            }
            else
            {
                boostIcon.gameObject.SetActive(true); // Show icon when ready or boosting
            }
        }
    }
}

