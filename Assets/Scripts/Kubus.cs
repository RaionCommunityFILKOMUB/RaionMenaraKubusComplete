using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class Kubus : MonoBehaviour {
  private static Color[] colorList;
  static Kubus() {
    colorList = new Color[] {
      Color.magenta,
      Color.yellow,
      Color.cyan
    };
  }

  public
  bool isAttachedToUjungPengait = false,
       isBaseKubus = false;

  private
  Material material_;
  private
  Rigidbody rigidbody_;

  private
  void OnEnable() {
    material_ = GetComponent<Renderer>().material;
    material_.color = colorList[(int)(Random.value * colorList.Length)];

    rigidbody_ = GetComponent<Rigidbody>();
  }

  private
  void Update() {
    rigidbody_.useGravity = !isAttachedToUjungPengait;
    rigidbody_.isKinematic = isBaseKubus;

    if (isBaseKubus) {
      rigidbody_.useGravity = false;
      return;
    }

    if (isAttachedToUjungPengait) {
      transform.position = UjungTali.instance.transform.position;
      return;
    }

    if (transform.position.y <= -1.0f) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      return;
    }
  }
}
