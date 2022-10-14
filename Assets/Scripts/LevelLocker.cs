using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    public Button[] buttons = new Button[20];
    public int myLevel;

    private void Start()
    {
        

        for (int level = 0; level <= 19; level++)
        {
            buttons[level].interactable = false;
        }
        OnLevelWasLoaded();

    }


    private void OnLevelWasLoaded()
    {
        int myLevel = PlayerPrefs.GetInt("Level");
        for (int level = 0; level <= myLevel; level++)
        {
            buttons[level].interactable = true;
            buttons[level].transform.GetChild(1).gameObject.SetActive(false);  //image.sprite = Resources.Load<Sprite>("UISprite");
        }
    }




}
