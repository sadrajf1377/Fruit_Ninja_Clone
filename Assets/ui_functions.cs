using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ui_functions : MonoBehaviour
{
    [SerializeField] GameObject Main_menu, Option_menu;
    [SerializeField] Animator anm;
   public void Change_menu(string to)
    {
        anm.SetTrigger("change"+to);
     /*   switch(i)
        {
            case 0:
                {
                    Option_menu.SetActive(false);
                    Main_menu.SetActive(true);
                }
                break;
            case 1:
                {
                    Main_menu.SetActive(false);
                    Option_menu.SetActive(true);
                }
                break;
        }*/
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
    public void replay()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
