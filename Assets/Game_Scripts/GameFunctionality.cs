using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.Rendering.Universal;

public class GameFunctionality : MonoBehaviour
{

    float startSeconds;
    float defaultTimer;
    [SerializeField] Text currentTimeCounterText;
    bool decreaseTimeFlag;

    private bool checkTop;

    [SerializeField] Transform respawnPoint;

    [SerializeField] int maxHealth;
    public int currentHealth;
    [SerializeField] HealthBar healthBar;

    [SerializeField] GameObject redSwitch;
    [SerializeField] GameObject greenSwitch;
    [SerializeField] GameObject redLight;
    [SerializeField] GameObject greenLight;

    [SerializeField] GameObject nextLevelUI;

    [SerializeField] GameObject gameOverUI;

    [SerializeField] GameObject switchControlUI;

    [SerializeField] AudioSource characterJump;

    [SerializeField] AudioSource characterPowerUp;

    [SerializeField] AudioSource characterDeath;

    [SerializeField]  UnityEngine.Experimental.Rendering.Universal.Light2D lightRadius;

    private void Start()
    {
        currentHealth = maxHealth;
        
    }
    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
        PowerUp();
    }

    //To attract the charcter to the rod and start the time.
    private void PowerUp()
    {
        if (startSeconds != 0 && Input.GetKeyDown(KeyCode.Space))
        {
            if(checkTop == false)
            {
                characterJump.Play();
                Debug.Log("Music is palying");
                InverseGravity();
                StartCoroutine(PowerDown());
            }
              
        }
    }

    //This function is used to inver the gravity and rotate the character
    private void InverseGravity()
    {
        decreaseTimeFlag = true;
        Physics2D.gravity = new Vector2(0, 9.8f);
        Rotate();
    }

    //When the charcter stays in the powerup room timer starts to sound down 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag ("PowerUpRoom"))
        {
            TimeCheck();
        }
        
    }

    //This method is executed whenever character collides with other object 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Charcter respawns when character touches the traps
        if (collision.gameObject.CompareTag("Trap"))
        {
            characterDeath.Play();
            TakeDamage(1);
            Respawn();
            currentTimeCounterText.text = startSeconds.ToString(Mathf.Round(startSeconds) + " Sec");
            redSwitch.SetActive(true);
            greenSwitch.SetActive(false);
            redLight.SetActive(true);
            switchControlUI.SetActive(false);
        }
        //Health bar is decreased
        if (currentHealth == 0)
        {
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = collision.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    //This method is executed whenever character collides with other object and pass throug it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Powerup sound is played
        if (collision.CompareTag("PowerUpRoom"))
        {
            characterPowerUp.Play();
        }
        //Players dies when they touches laser
        else if (collision.gameObject.CompareTag("Laser"))
        {
            TakeDamage(1);
            Respawn();
            currentTimeCounterText.text = startSeconds.ToString(Mathf.Round(startSeconds) + " Sec");
            redSwitch.SetActive(true);
            greenSwitch.SetActive(false);
            redLight.SetActive(true);
            switchControlUI.SetActive(false);
        }
        
       else  if (collision.gameObject.CompareTag("RedSwitch"))
        {
            redSwitch.SetActive(false);
            greenSwitch.SetActive(true);
            redLight.SetActive(false);
            greenLight.SetActive(true);
        }
        //Next level Ui will be loaded when ever the exit door is touched
        else if (collision.gameObject.CompareTag("ExitDoor"))
        {
            Time.timeScale = 0f;
            nextLevelUI.SetActive(true);  
        }
        //If the level is final then final level UI is seen
        else if (collision.gameObject.CompareTag("FinalLevelExitDoor"))
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("GameEnded");
        }
        else if (collision.gameObject.CompareTag("SwitchController"))
        {
                switchControlUI.SetActive(true);
        }
        //This method will change the radius of the light whenever charcter touches this object
        else if (collision.gameObject.CompareTag("SwitchControllerNormalLight"))
        {
            lightRadius.pointLightOuterRadius = (10f);
            Invoke("LightRadiusDecrease", 1f);
        }
        //This method is used called if the charcter touches this object and radius of the light is given
        else if (collision.gameObject.CompareTag("SwitchControllerLight") && lightRadius.pointLightOuterRadius == 1.8f)
        {
            switchControlUI.SetActive(true);
        }
        else
        {
            switchControlUI.SetActive(false);
        }
        
    }
    //This functions increase time.
    void TimeCheck()
    {
        startSeconds += Time.deltaTime;
        currentTimeCounterText.text = Mathf.Round(startSeconds).ToString() + " Sec";
    }

    //This method rotates the charcter 180 degree is top is false
    void Rotate()
    {
        if (checkTop == false)
        {

            transform.eulerAngles = new Vector3(0, 0, 180f);
            transform.Rotate(0f, 180, 0f);

        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        checkTop = !checkTop;

    }
    //When ever the powerup room is left time decreased
    void DecreaseTime()
    {
        if (decreaseTimeFlag)
        {
            startSeconds -= Time.deltaTime;
            currentTimeCounterText.text = Mathf.Round(startSeconds).ToString() + " Sec"; 

        }

    }

    void Respawn()
    {
        this.transform.position = respawnPoint.position;
        startSeconds = defaultTimer;
        decreaseTimeFlag = false;
        transform.eulerAngles = Vector3.zero;
        Physics2D.gravity = new Vector2(0, -9.8f);
    }

    //This is in build method of unity to wait for some time before executing a method
    IEnumerator PowerDown()
    {
        yield return new WaitForSeconds(startSeconds);
        NormalGravity(); 
    }
    // This method is used to make gravity normal
    private void NormalGravity()
    {
        startSeconds = defaultTimer;
        decreaseTimeFlag = false;
        Physics2D.gravity = new Vector2(0, -9.8f);
        Rotate();
    }
    void TakeDamage(int damage)
    {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
    }
    void LightRadiusDecrease()
    {
        lightRadius.pointLightOuterRadius = (1.8f);
    }
}

