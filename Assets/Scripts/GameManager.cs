using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

  public GameObject WallPrefab;
  public GameObject PickupPrefab;

  // Start is called before the first frame update
  void Start()
  {
    // Create walls or pickups every 20 units in the z.
    // Use % odd even to pick wall or pickup.

    //for (int i = 0; i < 10; i++)
    //{
    //  Instantiate(wallPrefab, transform.position, Quaternion.identity);
    //}
  }
}
