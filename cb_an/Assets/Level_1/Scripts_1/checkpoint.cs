using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkpoint : MonoBehaviour
{
    private GameObject player;
    public GameObject checkpointui ;
    public GameObject nextlevelui ; // next level

    public float delay = 3f;  // Delay in seconds before pausing the game

    [SerializeField] ObjectCollector sc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Collidable");
    }

    // Update is called once per frame
    void Update()
    {
        if ((player == null) && (sc.score >= 10))
        {
            gameOver();
            // Perform any desired actions when the GameObject is destroyed
        }
        if ((sc.score >= 80))
        {
            win();
            // Perform any desired actions when the GameObject is destroyed
        }
 
    }
    public void gameOver()
    {
        checkpointui.SetActive(true);
        PauseAfterDelay();

    }
    public void win()
    {
        nextlevelui.SetActive(true);
        PauseAfterDelay();
    }
    public void nextlevel()
    {
        SceneManager.LoadScene(2);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void checkpoint_1(){
        ToggleResume();
        player.SetActive(true);
        sc.score = 10 ;
    }
    public void TogglePause()
    {
            Time.timeScale = 0f;
    }
    public void ToggleResume()
    {  
            // Resume the game
            Time.timeScale = 1f;
    }
    public IEnumerator PauseAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        TogglePause();
    }

}
