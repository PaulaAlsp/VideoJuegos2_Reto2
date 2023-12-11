using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControlGeneral : MonoBehaviour
{
    public GameObject buttonInicial;

    public void CambioEscena(int N_escena){
        SceneManager.LoadScene(N_escena);
    }

    public void StopScene(){
      Time.timeScale=0f;
    }

      public void PlayScene(){
      Time.timeScale=1f;
      EventSystem.current.SetSelectedGameObject(buttonInicial);
    }

    public void quitGame(){
      #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
      #endif
      Application.Quit();
   }
}
