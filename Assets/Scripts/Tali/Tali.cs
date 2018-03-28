using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tali : MonoBehaviour {
  public static Tali instance;

  void OnEnable() {
    instance = this;
  }

  public void MoveUp(float distance) {
    transform.position += Vector3.up * distance;

    Kubus[] kubuses = Resources.FindObjectsOfTypeAll<Kubus>();
    if (kubuses.Length == 0) {
      return;
    }
    Kubus highestKubus = kubuses[0];
    for (int i = 1, len = kubuses.Length; i < len; i++) {
      if (highestKubus.transform.position.y <= kubuses[i].transform.position.y) {
        highestKubus = kubuses[i];
      }
    }
    MainCamera.instance.target = highestKubus.transform;
  }
}
