using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour
{

    public static GameManager manager;


    public float totalFruitCollected;
    public float highScore;

    private void Awake()
    {
   
        if (manager == null)
        {

            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
 
    void Start()
    {

    }

   
    void Update()
    {
     

    }

    // Kaksi toimintoa Save ja Load

    public void Save()
    {
        Debug.Log("Game Saved!");
        BinaryFormatter bf = new BinaryFormatter(); // Tehd��n uusi olio tai instanssi luokasta Binaryformatter. 
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        GameData data = new GameData();
        // Siirret��n game managerin muuttujien arvot Game manager luokan instanssiin. 
        data.highScore = highScore;
        // Serialisoidaan GameData objekti, joka tallennetaan samalla tiedostoon.
        bf.Serialize(file, data);
        file.Close(); // Suljetaan tiedosto, ettei kukaan hakkeri p��se siihen k�siksi. 




    }

    public void Load()
    {
        // Muista. Aina kun lataat tiedostoa mist� tahansa, tarkasta ett� se on edes olemassa!.
        // Jos on, niin sitten vasta jatka prosessia. 
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            Debug.Log("Game Loaded!");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            // Deserialsoidaan ja muunnetaan data GameData -muotoon. Me tied�mme, ett� data on GameData objektin informaatio
            GameData data = (GameData)bf.Deserialize(file);
            // T�rke�. Muista sulkea tiedosto, ettei hakkerit p��se k�siksi.
            file.Close();

            // Kun tieto on ladattu data objektiin, siirret��n muuttujien arvot Game Manager:in muuttujiin
            highScore = data.highScore;
            

        }


    }
}

// Toinen luokka, joka voidaan serialisoida. Pit�� sis�ll��n vaan sen datan mit� halutaan serialisoida ja tallentaa.

[Serializable]
class GameData
{
   
    public float highScore;
    

}
