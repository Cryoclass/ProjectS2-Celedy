using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving
{
    public static void SavePlayerData(Ya_Health Yaelle)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Yaelle.txt";
        
        FileStream stream = new FileStream(path, FileMode.Create); //créer un fichier de sauvegarde dans le chemin spécifié
            YaelleData data = new YaelleData(Yaelle);
        
        formatter.Serialize(stream, data); //écrit dans la sauvegarde les informations sur Yaelle
        stream.Close();
    }
    
    
    //va chercher la sauvegarde de yaelle
    public static YaelleData LoadingData()
    {
        string path = Application.persistentDataPath + "/Yaelle.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);//ouvre le fichier de sauvegarde

            YaelleData data = (YaelleData) formatter.Deserialize(stream); //
            stream.Close(); //j'ai pas vrmt compris pourquoi faut obligatoirement le fermer, mais ca met des erreurs quand on le ferme pas

            return data;
        }
        else
        {
            return null;
        }
    }
}
