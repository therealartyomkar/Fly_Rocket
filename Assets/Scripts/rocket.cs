using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class rocket : MonoBehaviour
{
    [SerializeField] float jRotSpeed;
    [SerializeField] float rotSpeed;
    [SerializeField] float flySpeed;
    [SerializeField] private GameObject WarningPanel;
    [SerializeField] AudioClip flySound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip boostSound;
    [SerializeField] ParticleSystem finishParticle;
    [SerializeField] ParticleSystem boomParticle;
    [SerializeField] ParticleSystem FlyParticle;
    [SerializeField] ParticleSystem lRotateParticle;
    [SerializeField] ParticleSystem rRotateParticle;
    private bool fly;
    private bool rot;
    private float verticalMove;
    [SerializeField] private float thrust = 1f;
    public int fuelSize;
    [SerializeField] private int fuelUsage;
    [SerializeField] private int fuelAdd;
    [SerializeField] private Text fuelText;
    [SerializeField] private Text ShopFuelText;
    [SerializeField] private Text BuyBoostIntText;
    [SerializeField] private Text BuyFuelIntText;
    [SerializeField] private Text BuyBoostCostText;
    [SerializeField] private Text BuyFuelCostText;
    [SerializeField] private Image imageCooldown;
    [SerializeField] private float cooldown = 10;
    bool isCooldown;
    private int currentFuel;
    [SerializeField] private GameObject Button;
    [SerializeField] private GameObject boostButton;
    private Button _boostButton;
    [SerializeField] private GameObject buyBoostButton;
    private Button _buyBoostButton;
    [SerializeField] private GameObject buyFuelButton;
    private Button _buyFuelButton;
    [SerializeField] private GameObject rotateJoystick;
    [SerializeField] private GameObject CanvasDeath;
    [SerializeField] private GameObject CanvasFly;
    [SerializeField] private GameObject CanvasReset;
    private GameObject _rocket_Body;
    bool collisionOff = false;
    [SerializeField] private Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float rotateH;
    private int fuelKey;
    private int cooldownKey;
    private int fuelAddKey;
    private int upgradeBoostCostKey;
    private int upgradeFuelCostKey;
    private int boostValue;
    public int upgradeBoostCost;
    public int upgradeFuelCost;

    public enum State { Playing, Dead, NextLevel, NoFuel, Pause, Restart };
    State state = State.Playing;
    GameObject Laser;
    public void Start()
    {
        _boostButton = boostButton.GetComponent<Button>();
        _buyBoostButton = buyBoostButton.GetComponent<Button>();
        _buyFuelButton = buyFuelButton.GetComponent<Button>();


        if (!PlayerPrefs.HasKey("currentFuel"))
        {
            PlayerPrefs.SetInt("currentFuel", currentFuel);
        }
        else
        {
            currentFuel = PlayerPrefs.GetInt("currentFuel");
        }
        if (!PlayerPrefs.HasKey("cooldown"))
        {
            PlayerPrefs.SetFloat("cooldown", cooldown);
        }
        else
        {
            cooldown = (int)PlayerPrefs.GetFloat("cooldown");
        }
        if (!PlayerPrefs.HasKey("fuelAdd"))
        {
            PlayerPrefs.SetFloat("fuelAdd", fuelAdd);
        }
        else
        {
            fuelAdd = (int)PlayerPrefs.GetFloat("fuelAdd");
        }

        if (!PlayerPrefs.HasKey("upgradeBoostCost"))
        {
            PlayerPrefs.SetFloat("upgradeBoostCost", upgradeBoostCost);
        }
        else
        {
            currentFuel = (int)PlayerPrefs.GetFloat("upgradeBoostCost");
        }
        if (!PlayerPrefs.HasKey("upgradeFuelCost"))
        {
            PlayerPrefs.SetFloat("upgradeFuelCost", upgradeFuelCost);
        }
        else
        {
            currentFuel = (int)PlayerPrefs.GetFloat("upgradeFuelCost");
        }
        fuelKey = PlayerPrefs.GetInt("currentFuel");
        cooldownKey = (int)PlayerPrefs.GetFloat("cooldown");
        fuelAddKey = (int)PlayerPrefs.GetFloat("fuelAdd");
        upgradeBoostCostKey = PlayerPrefs.GetInt("upgradeBoostCost");
        upgradeFuelCostKey = PlayerPrefs.GetInt("upgradeFuelCost");

        GameObject gameObject1 = GameObject.FindGameObjectWithTag("Laser");
        Laser = gameObject1;
        if (Laser == null)
        {
            state = State.Playing;
        }
        else
        {
            GameEvents.current.onLaserTriggerEnter += Lose;
        }


        state = State.Playing;
        audioSource = GetComponent<AudioSource>();
        currentFuel = fuelKey + fuelSize;
        cooldown = cooldownKey;
        fuelAdd = fuelAddKey;
        upgradeBoostCost = upgradeBoostCostKey;
        upgradeFuelCost = upgradeFuelCostKey;
        _rocket_Body = GameObject.Find("Rocket_Body");
    }
    public void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex; //просчитывает индекс сцен в Build Settings
        int NextLevelIndex = currentLevelIndex + 1; //прибавляет 1 к верхнему заключению
        if (NextLevelIndex == SceneManager.sceneCountInBuildSettings) // а это для того, чтобы при окончаний индекса сцен в Build Settings
                                                                      // загружался нулевой индекс(то есть первый уровень, ну или меню) :)
        {
            NextLevelIndex = 0;
        }
        SceneManager.LoadScene(NextLevelIndex); //загружает сцену с индексом +1 от предыдущей сцены! 
    }
    public void LoadCurrentLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }

        if (state == State.Playing)
        {
            Button.SetActive(false);
            Rotation();
            launch();
            KeyBoost();
            BoostButtonOff();
            BoostButtonOn();
            BuyBoostButtonOff();
        }
        if (Debug.isDebugBuild)
        {
            DebugKeys();
        }
        ShopFuelText.text = currentFuel.ToString();
        BuyBoostIntText.text = cooldown.ToString() + " sec";
        BuyFuelIntText.text = "+" + fuelAdd.ToString();
        BuyBoostCostText.text = upgradeBoostCost.ToString();
        BuyFuelCostText.text = upgradeFuelCost.ToString();

        if (state == State.Dead || state == State.NextLevel || state == State.NoFuel || state == State.Pause)
        {
            rotateJoystick.SetActive(false);
            boostButton.SetActive(false);
        }
        else if (state == State.Playing)
        {
            boostButton.SetActive(true);
            rotateJoystick.SetActive(true);
        }
        if (state == State.Dead || state == State.NoFuel)
        {
            Button.SetActive(true);
            PlayerPrefs.DeleteKey("currentFuel");
        }
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;
            if (imageCooldown.fillAmount == 1)
            {
                isCooldown = false;
            }

        }


    }
    public void Restart()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex);
    }
    public void FlyPointerDown()
    {
        fly = true;
    }
    public void FlyPointerUp()
    {
        fly = false;
    }
    void FixedUpdate()
    {
        if (state == State.Playing)
        {
            rotateH = joystick.Horizontal * jRotSpeed;
            rigidBody.AddTorque(transform.forward * rotateH);
        }

    }

    void ButtonOn()
    {
        Button.SetActive(true);
    }
    public void DebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionOff = !collisionOff;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (state == State.Dead || state == State.NextLevel || collisionOff)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                Finish();
                break;
            case "FinishATO":
                FinishATO();
                break;
            case "Fuel":
                PlusFuel(fuelAdd, collision.gameObject);
                break;
            default:
                Lose();
                break;

        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Fuel"))
        {
            PlusFuel(fuelAdd, collision.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Board")) 
        {
            Lose();
        }
    }
    public void PlusFuel(int fuelAdd, GameObject FuelObj)
    {
        FuelObj.GetComponent<BoxCollider>().enabled = false;
        currentFuel += fuelAdd;
        fuelText.text = currentFuel.ToString();
        Destroy(FuelObj);
    }
    public void Finish()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        finishParticle.Play();
        state = State.NextLevel;
        FlyParticle.Stop();
        rRotateParticle.Stop();
        lRotateParticle.Stop();
        PlayerPrefs.SetInt("currentFuel", currentFuel);
        PlayerPrefs.SetFloat("cooldown", cooldown);
        PlayerPrefs.SetFloat("fuelAdd", fuelAdd);
        PlayerPrefs.SetInt("upgradeBoostCost", upgradeBoostCost);
        PlayerPrefs.SetInt("upgradeFuelCost", upgradeFuelCost);
        if (PlayerPrefs.GetInt("Level") < LevelIndexSaver.levelIndex)
        {
            PlayerPrefs.SetInt("Level", LevelIndexSaver.levelIndex);
        }
        Invoke("LoadNextLevel", 1.6f);
    }
    public void FinishATO()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winSound);
        finishParticle.Play();
        state = State.NextLevel;
        FlyParticle.Stop();
        rRotateParticle.Stop();
        lRotateParticle.Stop();
        Invoke("LoadMainMenu", 1.6f);
    }
    public void Lose()
    {
        fly = false;
        rigidBody.isKinematic = true;
        audioSource.Stop();
        audioSource.PlayOneShot(deathSound);
        boomParticle.Play();
        state = State.Dead;
        FlyParticle.Stop();
        rRotateParticle.Stop();
        lRotateParticle.Stop();
        _rocket_Body.SetActive(false);
        CanvasDeath.SetActive(true);
        CanvasFly.SetActive(false);
        CanvasReset.SetActive(false);
        //Invoke("LoadCurrentLevel", 1.9f);

    }
    public void RestartOnSpawnpoint()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // There is no internet connection
            Debug.Log("Error. Check internet connection!");
            WarningPanel.SetActive(true);
        }
        else
        {

            _rocket_Body.SetActive(true);
            rigidBody.isKinematic = false;
            transform.position = Spawnpoints.SpawnPosition;
            transform.rotation = Quaternion.Euler(0,0,0);
            state = State.Playing;
            CanvasDeath.SetActive(false);
            CanvasFly.SetActive(true);
            CanvasReset.SetActive(true);
            if (Ad.ad != null) //если что то не так, то виновата эта проверка :)
                {
                    Ad.ad.AdReward(); 
                }
            currentFuel += 500;
        }


    }
    ////public void IfRevive()
    //{
    //}
    
    public void launch()
    {
            if(currentFuel <= 0)
            {
                state = State.NoFuel;
                FlyParticle.Stop();
                rRotateParticle.Stop();
                lRotateParticle.Stop();
                audioSource.Pause();
                Invoke(nameof(ButtonOn), 3f);
                return;
            }

       
            float flyingSpeed = flySpeed * Time.deltaTime;
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (fly == false)
                {
                    currentFuel -= Mathf.RoundToInt(fuelUsage * Time.deltaTime);
                    fuelText.text = currentFuel.ToString();
                    rigidBody.AddRelativeForce(Vector3.up * flyingSpeed);
                    if (!audioSource.isPlaying)
                    audioSource.PlayOneShot(flySound);
                    FlyParticle.Play();
                }
                
            }
            else
            {
            if (fly == false)
                {
                FlyParticle.Stop();
                audioSource.Stop();
                }
            }

        if (fly)
        {
            
            currentFuel -= Mathf.RoundToInt(fuelUsage * Time.deltaTime);
            fuelText.text = currentFuel.ToString();
            rigidBody.AddRelativeForce(Vector3.up * flyingSpeed);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(flySound);
            FlyParticle.Play();
        }
    }

    public void KeyBoost()
    {
        
        
            if(Input.GetKeyDown(KeyCode.Space))
            {

                Boost();
            }
        
    }
    public void Boost()
    {     
            if (state == State.Playing)
            {
            imageCooldown.fillAmount = 0;
            isCooldown = true;
            rigidBody.AddForce(transform.up * thrust);
            }
       
        
    }
    public void BoostButtonOn() 
    {
        if (isCooldown == false)
        {
            _boostButton.enabled = true; //boostButton.GetComponent<Button>().enabled = true; было
        }
    }
    public void BoostButtonOff()
    {
        if (isCooldown == true)
        {
            _boostButton.enabled = false; //boostButton.GetComponent<Button>().enabled = false; было
        }
    }
    public void PlusBoostValue() 
    {
        boostValue++;
        Debug.Log(boostValue);
    }
    public void GetBoostButton() //если нажимаем на buy и наш бензин больше чем стоймость покупки - то применяется upgrade(+1 страховка, чтобы весь бензин не потратился!)
    {
        if (currentFuel >= upgradeBoostCost + 1)
        {
            currentFuel -= upgradeBoostCost;
            upgradeBoostCost += 100;
            cooldown -= 0.5f;
        }
    }
    public void GetFuelButton()
    {
        if (currentFuel >= upgradeFuelCost + 1)
        {
            currentFuel -= upgradeFuelCost;
            upgradeFuelCost += 100;
            fuelAdd += 50;
        }
    }
    public void BuyBoostButtonOff()//если наш бензин больше чем стоймость покупки - то кнопка покупки становится активной
    {
        if (upgradeBoostCost < currentFuel)
        {
            _buyBoostButton.enabled = true; //buyBoostButton.GetComponent<Button>().enabled = true; было
        }
        else 
        {
            _buyBoostButton.enabled = false; //buyBoostButton.GetComponent<Button>().enabled = false; было
        }
    }
    public void BuyFuelButtonOff()
    {
        if (upgradeFuelCost < currentFuel)
        {
            _buyFuelButton.enabled = true; //buyFuelButton.GetComponent<Button>().enabled = true; было
        }
        else
        {
            _buyFuelButton.enabled = false; //buyFuelButton.GetComponent<Button>().enabled = false; было
        }
    }


    public void Rotation()
    {
       float rotationSpeed = rotSpeed * Time.deltaTime;
        if (currentFuel <= 0)
            {
                return;
            }
            

        
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
              
                transform.Rotate(Vector3.forward * rotationSpeed);

            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(-Vector3.forward * rotationSpeed);
               
            }
        




        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rot = true;
            lRotateParticle.Play();
        }
        else
        {
            lRotateParticle.Stop();
        }
        if (rot) 
        {
            lRotateParticle.Play();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rRotateParticle.Play();
        }
        else
        {
            rRotateParticle.Stop();
        }

        

    }

}
