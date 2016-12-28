using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TilesGenerator : MonoBehaviour{

    public enum modeType { Straight,Round};
    public modeType modeGen;
	public Transform targetCam;
	public GameObject canvas;
	public float angle = 30f;
	public float dist = 0f;

	public int Row;
	public int Collum;

	public float indentionX;
    public float indentionY;

    public GameObject Prefab;

    List<GameObject> listTile = new List<GameObject>();


    RectTransform RectTile;


    void UpdateTest()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GenerateStraightTile(Prefab, Row, Collum, indentionX, indentionY);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            GenerateRoundTile(Prefab, targetCam, Row, Collum, dist, angle);

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            DestroyTiles();
        }
    }

		
	public Vector3 TileRotate(Vector3 mainPos, float dist = 0, float angle = 0, float y = 0)
	{
		Vector3 pos;
		pos.z = (dist*Mathf.Cos(angle* Mathf.Deg2Rad))+mainPos.z; 
		pos.x = (-dist*Mathf.Sin(angle* Mathf.Deg2Rad))+mainPos.x;
		pos.y = y;
		return pos;
	}

    public void ButtonGenStraightTile()
    {
        GenerateStraightTile(Prefab, Row, Collum, indentionX, indentionY);
    }

    public void ButtonGenRoundTile()
    {
        GenerateRoundTile(Prefab, targetCam, Row, Collum, dist, angle);
    }


    public void GenerateRoundTile(GameObject Prefab, Transform mainPos, int Row, int Collum, float dist = 0, float angle = 0)
    {
        Prefab.active = false;
        Vector2 TileSize;
        TileSize = Prefab.GetComponent<RectTransform>().rect.size;
        float scaleY = canvas.GetComponent<RectTransform>().localScale.y ;
        for (int s = 0; s < Row; s++)
        {
            float rowAngle = -angle* (float)(Collum-1)/2 - mainPos.transform.eulerAngles.y;
            for (int i = 0; i < Collum; i++)
            {
                float y = ((TileSize.y + indentionY) * s);
                y -= (TileSize.y / 2f + indentionY / 2);
                y -= ((TileSize.y + indentionY) * (float)(Row - 2) / 2);
                y = y * scaleY;

                Vector3 newPos = TileRotate(mainPos.position, dist, rowAngle, y);

                Vector3 lookPos = newPos - mainPos.position;
                lookPos.y = 0;
                Quaternion rotation = Quaternion.LookRotation(lookPos);

                RectTransform rectPos = Prefab.GetComponent<RectTransform>();
                GameObject Tile = Instantiate(Prefab) as GameObject;
                listTile.Add(Tile);
                
                Tile.transform.position = newPos;
                Tile.transform.parent = canvas.transform;
                Tile.GetComponent<RectTransform>().localScale = rectPos.localScale;
                Tile.GetComponent<RectTransform>().rotation = rotation;
                listTile[listTile.Count - 1].active = true;
                rowAngle += angle;
            }
        }
    }

    public void GenerateStraightTile(GameObject Prefab, int Row, int Collum, float indentionX, float indentionY) 
	{
        Prefab.active = false;

        Vector2 TileSize;
		TileSize = Prefab.GetComponent<RectTransform>().rect.size;
        	
		for(int s = 0; s < Row; s++)
			for(int i = 0; i < Collum; i++)
			{
                // create Tiles with an offset relative to the center. To ensure that all the tile was in the middle.
                float x = ((TileSize.x + indentionX) * i);
                x -= (TileSize.x / 2f+ indentionX/ 2);
                x -= ((TileSize.x + indentionX) * (float)(Collum-2) / 2);
                float y = ((TileSize.y + indentionY) * s);
                y -= (TileSize.y / 2f+ indentionY / 2);
                y -= ((TileSize.y + indentionY) * (float)(Row-2) / 2);

                RectTransform rectPos = Prefab.GetComponent<RectTransform>();
				GameObject Tile = Instantiate(Prefab) as GameObject;
                listTile.Add(Tile);
                Tile.transform.parent = canvas.transform;
				Tile.GetComponent<RectTransform>().localScale = rectPos.localScale; 
				Tile.GetComponent<RectTransform>().localPosition = new Vector3(x,y, dist);
                listTile[listTile.Count - 1].active = true;
            }
	}

    public void DestroyTiles()
    {        
      for (int i = listTile.Count-1; i >= 0; i--)
        {
            DestroyImmediate(listTile[i]);
            listTile.RemoveAt(i);
               
        }
        Prefab.active = true;


    }
}


