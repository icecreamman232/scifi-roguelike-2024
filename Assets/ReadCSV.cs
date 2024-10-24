using System.IO;
using System.Linq;
using SGGames.Scripts.Data;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    public string FilePath;
    public EnemyDataContainer[] DataContainers;
    
    [ContextMenu("Read CSV")]
    public void ReadFile()
    {
        StreamReader reader = new StreamReader(FilePath);
        bool endOfFile = false;
        while (!endOfFile)
        {
            string line = reader.ReadLine();
            if (line == null)
            {
                endOfFile = true;
                break;
            }
            
            var data = line.Split(',');
            var container = DataContainers.FirstOrDefault(x => x.EnemyID == data[0]);
            
            if (container == null) continue;
            container.UpdateBulletData(float.Parse(data[1]), float.Parse(data[2]));
            container.UpdateWeaponData(float.Parse(data[3]));
        }
    }
    
    
}
