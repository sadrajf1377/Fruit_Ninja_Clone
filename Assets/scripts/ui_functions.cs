using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_functions : MonoBehaviour
{
   

    [SerializeField] Animator anm;
    [SerializeField] spawn_fruits spwn;

   public void switch_tab(string to)
    {
       
        anm.SetTrigger("change_to_"+to);
     
    }
    public void load_level(int ind)
    {
        spawn_fruits.selected_level = ind;
       
        SceneManager.LoadScene(1);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void return_to_main()
    {
        SceneManager.LoadScene(0);
    }
    public void replay()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    public void pause_unpause(string to_do)
    {
        switch(to_do)
        {
            case "pause": {
                    spwn.set_spawnloop_stat(true);
                    anm.SetTrigger("change_to_pause");
                }
                break;
            case "unpause": { anm.SetTrigger("change_to_normal");
                    StartCoroutine(wait_before_function(1.5f, delegate () { spwn.set_spawnloop_stat(false); }));
                    
                } break;
            default: { }break;
        }
    }
    IEnumerator wait_before_function(float seconds,Action act)
    {
        yield return new WaitForSeconds(seconds);
        act();
    }
   
}
