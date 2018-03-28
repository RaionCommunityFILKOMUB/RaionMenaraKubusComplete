using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
  Text text;

  public static ScoreText instance;

  private
  void OnEnable() {
    instance = this;

    text = GetComponent<Text>();
    text.text = "0";
  }

  public void UpdateScore() {
    text.text = (Int32.Parse(text.text) + 1).ToString();
  }
}
