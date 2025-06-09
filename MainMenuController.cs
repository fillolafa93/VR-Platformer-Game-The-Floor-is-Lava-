using UnityEngine;
using UnityEngine.SceneManagement;   
using UnityEngine.UI; 

public class MainMenuController : MonoBehaviour
{
    public Button scene1Button; //game story
    public Button scene2Button; // actual game
    public Button exitButton;

    void Start()
    {
        if (scene1Button != null)
        {
            scene1Button.onClick.AddListener(LoadScene1);
        }
        
        if (scene2Button != null)
        {
            scene2Button.onClick.AddListener(LoadScene2);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    void LoadScene1()
    {
        SceneManager.LoadScene("GameStory"); 
    }

    void LoadScene2()
    {
        SceneManager.LoadScene("Game");  
    }

     void ExitGame()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();  
    }
}
