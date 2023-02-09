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
      windForce = Random.Range(50, 100);
      //windBarImage.fillAmount = windForce / 1000;
      if (windForce <= 65)
      {
         windBarImage.fillAmount = 0.35f;
      }
      else
      {
         windBarImage.fillAmount = windForce /100;
      }

      return windForce;
   }
}
