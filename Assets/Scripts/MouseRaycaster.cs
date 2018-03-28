using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycaster : MonoBehaviour {
  void Update () {
    if (Input.GetMouseButtonDown(0) == false) {
      return;
    }

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit) == false) {
      return;
    }

    Kubus kubus = hit.transform.GetComponent<Kubus>();

    if (kubus == null) {
      return;
    }

    if (kubus.isAttachedToUjungPengait) {
      UjungTali.instance.AttachNewKubus();
    }
  }
}
