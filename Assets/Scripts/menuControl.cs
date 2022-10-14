using UnityEngine;
using UnityEngine.SceneManagement;


public class menuControl : MonoBehaviour
{
    [SerializeField] private GameObject GameSelectCanvas;
    [SerializeField] private GameObject LvlSelectCanvas;

    public void StartLvl1() 
    
    {
        SceneManager.LoadScene(2);
    }
    public void StartLvl2()

    {
        SceneManager.LoadScene(3);
    }
    public void StartLvl3()

    {
        SceneManager.LoadScene(4);
    }
    public void StartLvl4()

    {
        SceneManager.LoadScene(5);
    }
    public void StartLvl5()

    {
        SceneManager.LoadScene(6);
    }
    public void StartLvl6()

    {
        SceneManager.LoadScene(7);
    }
    public void StartLvl7()

    {
        SceneManager.LoadScene(8);
    }
    public void StartLvl8()

    {
        SceneManager.LoadScene(9);
    }
    public void StartLvl9()

    {
        SceneManager.LoadScene(10);
    }
    public void StartEasyLvl1()

    {
        SceneManager.LoadScene(11);
    }
    public void StartEasyLvl2()

    {
        SceneManager.LoadScene(12);
    }
    public void StartEasyLvl3()

    {
        SceneManager.LoadScene(13);
    }
    public void StartEasyLvl4()

    {
        SceneManager.LoadScene(14);
    }
    public void StartEasyLvl5()

    {
        SceneManager.LoadScene(15);
    }
    public void StartEasyLvl6()

    {
        SceneManager.LoadScene(16);
    }
    public void StartEasyLvl7()

    {
        SceneManager.LoadScene(17);
    }
    public void StartEasyLvl8()

    {
        SceneManager.LoadScene(18);
    }
    public void StartEasyLvl9()

    {
        SceneManager.LoadScene(19);
    }
    public void StartAllInOneEasy()

    {
        SceneManager.LoadScene(20);
    }
    public void StartAllInOne()

    {
        SceneManager.LoadScene(1);
    }
    public void ShowGoogleAd() 
    {
        Ad.ad.AdGoogle();
    }
    public void ShowGoogleRewardAd()
    {
        Ad.ad.AdReward();
    }
    //public void OpenGameSelectCanvas() 
    //{
    //    GameSelectCanvas.SetActive(true);
    //}
    //public void OpenLvlSelectCanvas()
    //{
    //    LvlSelectCanvas.SetActive(true);
    //}
}
