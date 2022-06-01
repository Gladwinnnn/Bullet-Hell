using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] Animator crossfade;

    [SerializeField] float time = 1f;
    [SerializeField] float timeSlowed;
    [SerializeField] float howLong;

    // Start is called before the first frame update
    void Start()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        if (buildIndex == 2)
        {
            FindObjectOfType<Player>().SetCanShoot();
        }

        if (buildIndex == 3)
        {
            FindObjectOfType<Player>().SetCanShoot();
            FindObjectOfType<Player>().SetCanGrenade();
        }
        if (buildIndex == 4)
        {
            FindObjectOfType<Timer>().Finish();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.V))
        //{
        //    StartCoroutine(SlowTime());
        //}
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, 0, "fade"));
    }

    public void PlayerIsDead()
    {
        // slow down time awhile 
        // die awhile 
        // cross fade 
        StartCoroutine(SlowTime());
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, 3.5f, "fade"));
    }

    IEnumerator SlowTime()
    {
        Time.timeScale = timeSlowed;
        yield return new WaitForSecondsRealtime(howLong);
        Time.timeScale = 1;
    }

    private void GameOver()
    {

    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(1, 0, "fade"));
        FindObjectOfType<Timer>().Reset();
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
