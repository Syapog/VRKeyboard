using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    [SerializableAttribute]
    public struct DataRecord
    {
        public string PlayerName;
        public int Score;

        public DataRecord(string newName, int newScore)
        {
            PlayerName = newName;
            Score = newScore;
        }
    }

    private static string _recordsFilePath = Application.dataPath + "/StreamingAssets/Records.txt";

    public static List<Record> LoadFromFile()
    {
        List<Record> records = new List<Record>();

        if (File.Exists(_recordsFilePath))
        {
            FileStream fin = File.OpenRead(_recordsFilePath);
            BinaryFormatter bf = new BinaryFormatter();
            List<DataRecord> dataRecords = (List<DataRecord>)bf.Deserialize(fin);
            fin.Close();

            for (int i = 0; i < dataRecords.Count; i++)
            {
                records.Add(new Record(dataRecords[i].PlayerName, dataRecords[i].Score));
            }
        }
        else
        {
            SaveToFile(records);
        }
        return records;
    }

    public static void SaveToFile(List<Record> records)
    {
        List <DataRecord> dataRecords = new List<DataRecord>();
        for (int i = 0; i < records.Count; i++)
        {
            dataRecords.Add(new DataRecord(records[i].Name, records[i].Score));
        }

        FileStream fout = File.OpenWrite(_recordsFilePath);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fout, dataRecords);
        fout.Close();
    }
}
