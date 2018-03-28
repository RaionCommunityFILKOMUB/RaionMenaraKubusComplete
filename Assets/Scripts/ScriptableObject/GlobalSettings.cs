using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings.Global", menuName = "ScriptableObject/Settings.Global")]
public class GlobalSettings : ScriptableObject {
  private static GlobalSettings instance_;
  public static GlobalSettings instance {
    get {
      if (instance_ == null) {
        instance_ = Resources.Load<GlobalSettings>("Settings.Global");
      }

      return instance_;
    }
  }

  [Header("Ujung Pengait Settings")]
  public float ujungPengaitSwingOffset = 16;
}
