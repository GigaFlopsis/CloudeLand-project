using UnityEngine;
using System.Collections;

public class ConfigurateTiles : MonoBehaviour {

    public int AvalibleLevels = 1;
    public int AvalibleStars = 0;
    public LevelTile[] levelTile;
    public bool updateTilesState = false;
    public int openLevels;

    void Awake() {
		if (PlayerPrefs.HasKey("AvalibleStars"))
        {
			AvalibleStars = PlayerPrefs.GetInt("AvalibleStars");    
        }
		if (PlayerPrefs.HasKey("AvalibleLevels"))
        {
			AvalibleLevels = PlayerPrefs.GetInt("AvalibleLevels");
        }

        openLevels = AvalibleLevels;
    }

    void Start() {
        OpenLevels();
    }

    void OnGUI()
    {
        if (AvalibleLevels != openLevels) {

            AvalibleLevels = openLevels;
			PlayerPrefs.SetInt("AvalibleLevels", AvalibleLevels);
            OpenLevels();
        }
        
                
     }


    // Use this for initialization
    void OpenLevels () {
        // Open availeble Tiles
        for (int i = 0; i < levelTile.Length; i++)
        {
            levelTile[i].OpenLevel(false);
        }
        if (levelTile.Length >= AvalibleLevels - 1) {
            for (int i = 0; i < AvalibleLevels; i++)
            {
                levelTile[i].OpenLevel(true);
            }
        }          
        if (levelTile.Length < AvalibleLevels - 1)
        {
            for (int i = 0; i < levelTile.Length; i++)
            {
                levelTile[i].OpenLevel(true);
            }
        }
        StartCoroutine(TileUpdateCoroutine());
    }

    



    IEnumerator TileUpdateCoroutine()
    {
        UpdateTiles(true);
        yield return new WaitForSeconds(3f);
        UpdateTiles(false);
        yield return null;
    }




    public void UpdateTiles(bool UpdateTiles)
    {
        if (UpdateTiles && !levelTile[levelTile.Length - 1].enabled)
        {
            for (int i = 0; i < levelTile.Length - 1; i++)
                levelTile[i].enabled = true;
        }
        if (!UpdateTiles && levelTile[levelTile.Length - 1].enabled)
        {
            for (int i = 0; i < levelTile.Length - 1; i++)
                levelTile[i].enabled = false;
        }
    }
}
