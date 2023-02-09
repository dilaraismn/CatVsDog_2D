using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wind : MonoBehaviour
{
   [SerializeField] private GameObject windRightArrow, windLeftArrow;

   public bool IsWindRight()
   {
      string[] directions = new string[] {"left", "right"};
      string direction = directions[Random.Range(0, directions.Length)];

      if (direction == "right")
      {
         return true;
      }
      return false;
   }

   private void Start()
   {
      if (IsWindRight())
      {
         windRightArrow.SetActive(true);
         windLeftArrow.SetActive(false);
      }
      else
      {
         windLeftArrow.SetActive(true);
         windRightArrow.SetActive(false);
      }
   }
}
