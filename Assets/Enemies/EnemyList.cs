using UnityEngine;
using System.IO;
using System;

public class EnemyList : MonoBehaviour {
    
    public string fileName;

    public void ReadCsv() {
        string path = Path.Combine(Application.dataPath, fileName);

        using (StreamReader reader = new StreamReader(path)) {
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                string[] values = line.Split(',');

                foreach (string value in values) {
                    // TODO
                }
            }
        }
    }
}