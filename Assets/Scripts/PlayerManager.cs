using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Slider fuelSlider;
    public Slider healthSlider;
    public GameObject bulletPrefab;
    public RectTransform bulletAmountUI;

    [HideInInspector]
    public float fuel = 0f;
    public float maxFuel = 0f;

    private int health = 0;
    public int maxHealth = 0;

    private int bullet = 0;
    public int maxBullet = 0;
    public float bulletSpeed = 0f;

    private PlayerController playerController;
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;
    private TextMeshProUGUI bulletCounterText;

    // Start is called before the first frame update
    void Awake()
    {
        bullet = maxBullet;
        fuel = maxFuel;
        health = maxHealth;
        InitSliders(fuel, health);

        playerController = transform.GetComponent<PlayerController>();
        myCollider = transform.GetComponent<Collider2D>();
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        bulletCounterText = bulletAmountUI.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletAmountUI.position = new Vector2(transform.position.x , transform.position.y - 0.8f);
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (true)
        {
            DecreaseHealth(1);
        }
    }

    public void DecreaseFuel(float amount)
    {
        fuel = fuel - amount < 0 ? 0 : fuel - amount;
        fuelSlider.value = fuel;
    }

    public void IncreaseFuel(float amount)
    {
        fuel = fuel + amount > maxFuel ? maxFuel : fuel + amount;
        fuelSlider.value = fuel;
    }

    private void DecreaseHealth(int amount)
    {
        health = health - amount < 0 ? 0 : health - amount;
        healthSlider.value = health;
    }

    private void IncreaseHealth(int amount)
    {
        health = health + amount > maxHealth ? maxHealth : health + amount;
        healthSlider.value = health;
    }

    private void DecreaseBullet(int amount)
    {
        bullet = bullet - amount < 0 ? 0 : bullet - amount;
        bulletCounterText.text = bullet.ToString();
    }

    private void IncreaseBullet(int amount)
    {
        bullet = bullet + amount > maxBullet ? maxBullet : bullet + amount;
        bulletCounterText.text = bullet.ToString();
    }

    float cooldown = 0.2f;
    float cooldownTimestamp;
    private void Fire()
    {
        if (Time.time < cooldownTimestamp) return;
        var bulletInstance = Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        Vector2 bulletVelocity = myRigidbody.transform.up * bulletSpeed;
        bulletVelocity += myRigidbody.velocity * 1.0f;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = bulletVelocity;

        Destroy(bulletInstance,3);
        DecreaseBullet(1);
        cooldownTimestamp = Time.time + cooldown;
    }
    
    private void InitSliders(float fuel ,int health)
    {
        fuelSlider.maxValue = fuel;
        fuelSlider.value = fuel;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
}
