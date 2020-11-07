using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace SharedClassLibary.Services
{
    public static class CreateFileService
    {
        public static async Task CreateFileAsync()
        {
            try
            {
                StorageFolder storageFolder;
                storageFolder = KnownFolders.DocumentsLibrary;

                await storageFolder.CreateFileAsync("jsonfile.json", CreationCollisionOption.OpenIfExists);
                await storageFolder.CreateFileAsync("xmlfile.xml", CreationCollisionOption.OpenIfExists);
                await storageFolder.CreateFileAsync("csvfile.csv", CreationCollisionOption.OpenIfExists);
                await storageFolder.CreateFileAsync("textfile.txt", CreationCollisionOption.OpenIfExists);
            }
            catch { }

        }
    }
}
