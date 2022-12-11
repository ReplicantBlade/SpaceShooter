using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Slider fuelSlider;
    public Slider healthSlider;
    public TextMeshPro bulletAmountText;

    [HideInInspector]
    public float fuel = 0f;
    public float maxFuel = 0f;

    private int health = 0;
    public int maxHealth = 0;

    private int bullet = 0;
    public int maxBullet = 0;

    private PlayerController playerController;
    private Collider2D myCollider;

    // Start is called before the first frame update
    void Awake()
    {
        fuel = maxFuel;
        health = maxHealth;
        InitSliders(fuel, health);

        playerController = transform.GetComponent<PlayerController>();
        myCollider = transform.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        bulletAmountText.text = bullet.ToString() + " Bullet";
    }

    private void IncreaseBullet(int amount)
    {
        bullet = bullet + amount > maxBullet ? maxBullet : bullet + amount;
        bulletAmountText.text = bullet.ToString() + " Bullet";
    }

    private void Fire()
    {
        print("Fire");
        DecreaseBullet(1);
    }
    
    private void InitSliders(float fuel ,int health)
    {
        fuelSlider.maxValue = fuel;
        fuelSlider.value = fuel;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
}
