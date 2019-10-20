using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{

    public delegate void DetectionEvent();
    public static event DetectionEvent Detection;

    public delegate void BeginDetectionEvent();
    public static event BeginDetectionEvent BeginDetection;

    public static void onDetected()
    {
        Detection();
    }

    public static void onBeginDetection()
    {
        BeginDetection();
    }

    /*  // whe the player collect a Collectible
      public delegate void CollectedEvent(Collectible col);
      public static event CollectedEvent Collected;

      public delegate void AfterCollectedManagerEvent(Collectible col);
      public static event AfterCollectedManagerEvent AfterCollectedManager;

      // when the player collect all Collectibles
      public delegate void AllCollectedEvent();
      public static event AllCollectedEvent AllCollected;

      // when the player dead
      public delegate void DeathEvent();
      public static event DeathEvent Death;

      //open the passerelle doorEnter from a portal scene script
      public delegate void OpenDoorEvent();
      public static event OpenDoorEvent OpenDoor;



    

      public static void onCollected(Collectible col)
      {
          Collected(col);
      }

      public static void onAfterCollectedManager(Collectible col)
      {
          AfterCollectedManager(col);
      }

      public static void onAllCollected()
      {
          AllCollected();
      }

      public static void onDeath()
      {
          Death();
      }


      public static void onOpenDoor()
      {
          OpenDoor();
      }*/

}
