using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawn : MonoBehaviour
{
    public GameObject TreePrefab;
    private GameObject NewTreePoint;
    public GameObject ParkFencePrefab;
    private GameObject NewParkFencePoint;
    public Vector3[] ArrayOfParkFencePoints;
    private float TreeSpawnX;
    private float TreeSpawnZ;
    private float NewTreeMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        while (NewTreeMax <= 200)
        {
            TreeSpawnOnStart();
        }
        ParkFenceSpawnOnStart();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void TreeSpawnOnStart()
    {
        TreeSpawnX = Random.Range(-1000,1000);
        TreeSpawnZ = Random.Range(-1000, 1000);

        if (NewTreeMax <= 200)
        {
            for (int i = 0; i <= 0; i++)
            {
                NewTreePoint = Instantiate(TreePrefab, new Vector3(TreeSpawnX, 15, TreeSpawnZ), Quaternion.identity);
                NewTreeMax++; 
                if (TreeSpawnX >= -50f && TreeSpawnX <= 50f)
                {
                    Destroy(NewTreePoint);
                }
                if (TreeSpawnZ >= -50f && TreeSpawnZ <=50f)
                {
                    Destroy(NewTreePoint);
                }
            }
        }
    }

    void ParkFenceSpawnOnStart()
    {
        for (int i = 0; i <= ArrayOfParkFencePoints.Length; i++)
        {
            NewParkFencePoint = Instantiate(ParkFencePrefab, ArrayOfParkFencePoints[i], Quaternion.identity);

            if (i == 1)
            {
                NewParkFencePoint.transform.Rotate(0, -90, 0);
            }

            if (i == 2)
            {
                NewParkFencePoint.transform.Rotate(0, 90, 0);
            }

        }
    }
}
