using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainCamera : MonoBehaviour {
  public static MainCamera instance;

  private void OnEnable() {
    instance = this;
  }

  public
  Transform target;

  private
  void Update() {
    if (target == null) {
      return;
    }

    transform.position = target.position;
  }
}
