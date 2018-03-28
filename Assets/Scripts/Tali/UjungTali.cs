using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UjungTali : MonoBehaviour {
  private GameObject kubusPrefab_;
  public GameObject kubusPrefab {
    get {
      if (kubusPrefab_ == null) {
        kubusPrefab_ = PrefabContainer.instance.prefabs.Find(
                         item => item.name.ToLower().Equals("Prefab.Kubus".ToLower())
                       );
      }

      return kubusPrefab_;
    }
  }

  private
  float distance;

  public
  Kubus attachedKubus;

  public
  float swingOffset {
    get {
      return GlobalSettings.instance.ujungPengaitSwingOffset;
    }
  }

  public
  void DetachCurrentKubus() {
    if (attachedKubus == null) {
      return;
    }

    attachedKubus.isAttachedToUjungPengait = false;
    attachedKubus = null;

    Tali.instance.MoveUp(1.0f);

    ScoreText.instance.UpdateScore();
  }

  public
  void AttachNewKubus() {
    DetachCurrentKubus();

    distance = transform.localPosition.magnitude;

    attachedKubus = Instantiate(kubusPrefab, Vector3.forward * 2, Quaternion.identity).GetComponent<Kubus>();
    attachedKubus.isAttachedToUjungPengait = true;
  }

  public static UjungTali instance;

  private
  void OnEnable() {
    instance = this;

    AttachNewKubus();
  }

  private
  void Update() {
    float f = (Mathf.PingPong(Time.time * 180.0f, 90) + 225) * Mathf.Deg2Rad;

    Vector3 pos = transform.localPosition;
    pos.x = Mathf.Cos(f);
    pos.y = Mathf.Sin(f);
    pos.z = 0.0f;
    pos *= distance;

    transform.localPosition = pos;

    if (Input.GetKeyDown(KeyCode.Space)) {
      this.AttachNewKubus();
    }
  }
}
