using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class NavigationController : MonoBehaviour {
  private
  void Update() {
    if (Input.GetKeyDown(KeyCode.Escape)) {
      Application.Quit();
      return;
    }

    if (Input.GetKeyDown(KeyCode.R)) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      return;
    }
  }
}
