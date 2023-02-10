using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Wind : MonoBehaviour
{
   [SerializeField] private GameObject windRightArrow, windLeftArrow;
   [SerializeField] private Image windBarImageLeft, windBarImageRight;
   private Image currentBarImage { get; set; }
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
         windBarImageRight.gameObject.SetActive(true);
         windBarImageLeft.gameObject.SetActive(false);
         currentBarImage = windBarImageRight;
         return true;
      }
      isWindRight = false;
      windLeftArrow.SetActive(true);
      windRightArrow.SetActive(false);
      windBarImageRight.gameObject.SetActive(false);
      windBarImageLeft.gameObject.SetActive(true);
      currentBarImage = windBarImageLeft;
      return false;
   }

   public float SetWindForce(float windForce)
   {
      // 6-20
      windForce = Random.Range(3, 5);
      print(windForce);

      if (windForce == 3)
      {
         currentBarImage.fillAmount = 1f;
      }
      else if (windForce == 4) // 5-6
      {
         currentBarImage.fillAmount = .6f;
      }
      else if (windForce == 5)
      {
         currentBarImage.fillAmount = .3f;
      }

      return windForce;
   }
}
