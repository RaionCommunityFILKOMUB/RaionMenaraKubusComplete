using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pengait : MonoBehaviour {
  public static Pengait instance;

  void OnEnable() {
    instance = this;
  }

  public void MoveUp(float distance) {
    transform.position += Vector3.up * distance;
  }
}