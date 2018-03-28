using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabContainer", menuName = "ScriptableObject/PrefabContainer")]
public class PrefabContainer : ScriptableObject {
  private static PrefabContainer instance_;
  public static PrefabContainer instance {
    get {
      if (instance_ == null) {
        instance_ = Resources.Load<PrefabContainer>("PrefabContainer");
      }

      return instance_;
    }
  }

  public List<GameObject> prefabs;
}
