using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
