using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Wind : MonoBehaviour
{
   [SerializeField] private GameObject windRightArrow, windLeftArrow;
   [SerializeField] private Image windBarImage;
   public static bool isWindRight;

   public bool IsWindRight()
   {
      string[] directions = new string[] {"left", "right"};
      string direction = directions[Random.Range(0, directions.Length)];

      if (direction == "right")
      {
         isWindRight = true;
         windRightArrow.SetActive(true);
         windLeftArrow.SetActive(false);
         return true;
      }
      isWindRight = false;
      windLeftArrow.SetActive(true);
      windRightArrow.SetActive(false);
      return false;
   }

   public float SetWindForce(float windForce)
   {
      // 6-20
      windForce = Random.Range(3, 7);
      print(windForce);

      if (windForce == 3)
      {
         windBarImage.fillAmount = .2f;
      }
      else if (windForce == 4) // 5-6
      {
         windBarImage.fillAmount = .4f;
      }
      else if (windForce == 5)
      {
         windBarImage.fillAmount = .6f;
      }
      else if (windForce == 6)
      {
         windBarImage.fillAmount = .8f;
      }
      else if (windForce == 7)
      {
         windBarImage.fillAmount = 1f;
      }
      return windForce;
   }
}
