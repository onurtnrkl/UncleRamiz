#region License
/*================================================================
Product:    TapEngine
Developer:  Onur Tanrıkulu
Date:       26/11/2017 15:58

Copyright (c) 2017 Onur Tanrikulu. All rights reserved.
================================================================*/
#endregion

using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BabylonJam
{
    public static class DatabaseManager
    {
        public static T Read<T>(string name, string category = "")
        {
            //TODO: is not exists return new T.
            string directory = "Database";

            if (!category.Equals(string.Empty)) directory = Path.Combine(directory, category);

            string path = Path.Combine(directory, name);
            string data = Resources.Load<TextAsset>(path).text;

            return JsonUtility.FromJson<T>(data);
        }

        public static string[] GetFileNames(string category)
		{
            List<string> names = new List<string>();
			string directory = DirectoryPath(category);
            string[] files = Directory.GetFiles(directory, "*.json");

            for (int i = 0; i < files.Length; i++)
            {
                string file = files[i];
                string name = Path.GetFileNameWithoutExtension(file);

                names.Add(name);
            }

            return names.ToArray();
		}

        private static string DirectoryPath(string category = "")
		{
			string directory = Path.Combine(Application.dataPath, "Resources/Database");
			string path;

			if (!category.Equals(string.Empty)) path = Path.Combine(directory, category);
			else path = directory;

			if (!Directory.Exists(path)) Directory.CreateDirectory(path);

			return path;
		}

#if UNITY_EDITOR

        private static string FilePath(string name, string category = "")
        {
            string directory = DirectoryPath(category);
            string file = name + ".json";
            string path = Path.Combine(directory, file);

            return path;
        }

        public static void Write(string name, object obj, string category = "")
        {
            string data = JsonUtility.ToJson(obj, true);
            string path = FilePath(name, category);

            File.WriteAllText(path, data);
            UnityEditor.AssetDatabase.Refresh();
        }
#endif
    }
}