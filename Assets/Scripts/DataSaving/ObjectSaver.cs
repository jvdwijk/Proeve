using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PeppaSquad.DataSaving {

    /// <summary>
    /// Saves and loads instances to and from files.
    /// </summary>
    public class ObjectSaver {

        public readonly string mainDirectoryPath;

        public ObjectSaver(string path) {
            mainDirectoryPath = path;
        }

        public bool FileExits(string fileName, string subdirectory = "") {
            string filePath = Path.Combine(mainDirectoryPath, subdirectory, fileName);
            return File.Exists(filePath);
        }

        /// <summary>
        /// Saves object to a file in the main directory. 
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="subdirectory">Subdirectory in which the file will be saved</param>
        /// <param name="obj"></param>
        /// <typeparam name="T">type of the object (has to be serializable)</typeparam>
        public void SaveObject<T>(string fileName, string subdirectory, T obj) {
            if (!IsSerializable(obj))
                throw new Exception("Given object is not serializable.");

            string directoryPath = Path.Combine(mainDirectoryPath, subdirectory);
            string filePath = Path.Combine(directoryPath, fileName);

            BinaryFormatter formatter = new BinaryFormatter();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            using(FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate)) {
                formatter.Serialize(stream, obj);
            }
        }

        /// <summary>
        /// Saves object to a file in the main directory. 
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="obj"></param>
        /// <typeparam name="T">type of the object (has to be serializable)</typeparam>
        public void SaveObject<T>(string fileName, T obj) {
            SaveObject<T>(fileName, string.Empty, obj);
        }

        /// <summary>
        /// Loads object from a file in the main directory.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="subdirectory">Subdirectory in which the file will be saved</param>
        /// <param name="obj">The loaded object</param>
        /// <typeparam name="T">type of the object (has to be serializable)</typeparam>
        /// <returns>result</returns>
        public LoadResult LoadObject<T>(string fileName, string subdirectory, out T obj) {
            string directoryPath = Path.Combine(mainDirectoryPath, subdirectory);
            string filePath = Path.Combine(directoryPath, fileName);

            if (!FileExits(filePath)) {
                obj = default(T);
                return LoadResult.FileDoesNotExist;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                object loadedObject = formatter.Deserialize(stream);
                if (loadedObject.GetType() != typeof(T)) {
                    obj = default(T);
                    return LoadResult.WrongType;
                }
                obj = (T) loadedObject;
            }
            return LoadResult.Succes;

        }

        /// <summary>
        /// Loads object from a file in the main directory.
        /// </summary>
        /// <param name="fileName">Name of the file</param>
        /// <param name="obj">The loaded object</param>
        /// <typeparam name="T">type of the object (has to be serializable)</typeparam>
        /// <returns>result</returns>
        public LoadResult LoadObject<T>(string fileName, out T obj) {
            return LoadObject(fileName, string.Empty, out obj);
        }

        private bool IsSerializable(object obj) {
            return obj.GetType().IsSerializable;
        }
    }
}