using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] Animator crossfade;

    [SerializeField] float time = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerIsDead()
    {
        // slow down time awhile 
        // die awhile 
        // cross fade 
        // check if got next scene? 
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, 2, "fade"));
    }

    private void GameOver()
    {

    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(1, 0, "fade"));
    }

    public void PauseGame()
    {

    }

    private IEnumerator LoadLevel(int levelIndex, float fadeDelay, string trigger)
    {
        yield return new WaitForSecondsRealtime(fadeDelay);
        crossfade.SetTrigger(trigger);

        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(levelIndex);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
