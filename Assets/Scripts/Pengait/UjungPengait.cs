using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UjungPengait : MonoBehaviour {
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

  public
  float swingOffset {
    get {
      return GlobalSettings.instance.ujungPengaitSwingOffset;
    }
  }

  public
  Kubus attachedKubus;

  public static UjungPengait instance;

  private
  void OnEnable() {
    instance = this;

    attachedKubus = Instantiate(kubusPrefab, Vector3.forward * 2, Quaternion.identity).GetComponent<Kubus>();
    attachedKubus.isAttachedToUjungPengait = true;

    Vector3 pos = transform.parent.position;
    pos.x = (Random.value * swingOffset * 2) - swingOffset;
    transform.parent.position = pos;
  }

  private
  void OnDisable() {
    if (attachedKubus == null) {
      return;
    }

    attachedKubus.isAttachedToUjungPengait = false;
    attachedKubus = null;

    Pengait.instance.MoveUp(1.0f);
  }

  public
  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      this.OnDisable();
      this.OnEnable();
    }
  }
}
