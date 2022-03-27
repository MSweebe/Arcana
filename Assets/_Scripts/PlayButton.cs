using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   void TaskOnClick () {
       SceneManager.LoadScene(0);
   }

}
