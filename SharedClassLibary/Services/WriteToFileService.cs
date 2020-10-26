using CsvHelper;
using Newtonsoft.Json;
using SharedClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Xaml.Shapes;
using static SharedClassLibary.Models.Person;

namespace SharedClassLibary.Services
{
    public class WriteToFileService
    {
        static StorageFolder storageFolder;
   
        static List<Person> people = new List<Person>();
        public static async Task WriteToFileJsonAsync(Person person)
        {
            try
            {

                storageFolder = KnownFolders.DocumentsLibrary;
                StorageFile file = await storageFolder.GetFileAsync("jsonfile.json");

                var json = "";
                var filetext = await FileIO.ReadTextAsync(file);


                if (filetext != string.Empty)
                {
                    var result = JsonConvert.DeserializeObject<List<Person>>(filetext);
                    foreach (var p in result)
                    {
                        people.Add(p);
                    }
                    people.Add(person);
                    json = JsonConvert.SerializeObject(people);
                    await FileIO.WriteTextAsync(file, json);
                }
                else
                {
                    people.Add(person);
                    json = JsonConvert.SerializeObject(people);
                    await FileIO.WriteTextAsync(file, json);
                }
            }
            catch { }

        }

        public static async Task WriteToFileXmlAsync(Person person)
        {
            try
            {
                storageFolder = KnownFolders.DocumentsLibrary;
                StorageFile file = await storageFolder.GetFileAsync("xmlfile.xml");

                string ToXML(Object oObject)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    XmlSerializer xmlSerializer = new XmlSerializer(oObject.GetType());
                    using (MemoryStream xmlStream = new MemoryStream())
                    {
                        xmlSerializer.Serialize(xmlStream, oObject);
                        xmlStream.Position = 0;
                        xmlDoc.Load(xmlStream);
                        return xmlDoc.InnerXml;

                    }
                }

                var filetext = await FileIO.ReadTextAsync(file);

                if (filetext != string.Empty)
                {

                    try
                    {
                        using (TextReader reader = new StringReader(filetext))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
                            List<Person> ppl = (List<Person>)serializer.Deserialize(reader);
                            foreach (var p in ppl)
                            {
                                people.Add(p);
                            }
                            reader.Close();
                        }
                    }
                    catch
                    {
                        using (TextReader reader = new StringReader(filetext))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(Person));
                            var ppl = (Person)serializer.Deserialize(reader);
                            people.Add(ppl);
                            reader.Close();
                        }
                    }

                    people.Add(person);

                    var strXML = ToXML(people);
                    await FileIO.WriteTextAsync(file, strXML);

                }
                else
                {
                    var strXML = ToXML(person);
                    await FileIO.WriteTextAsync(file, strXML);
                }
            }

            catch { }

        }

        public static async Task WriteToFileCsvAsync(Person person)
        {
            try
            {
                storageFolder = KnownFolders.DocumentsLibrary;
                StorageFile file = await storageFolder.GetFileAsync("csvfile.csv");

                string csv = $"{person.FirstName};{person.LastName};{person.Address};{person.Email};{person.JobTitle}";

                await FileIO.WriteTextAsync(file, csv);
            }
            catch { }
        }

        public static async Task WriteToFileTxtAsync(Person person)
        {
            try
            {
                storageFolder = KnownFolders.DocumentsLibrary;
                StorageFile file = await storageFolder.GetFileAsync("textfile.txt");

                string txt = $"{person.FirstName},{person.LastName},{person.Address},{person.Email},{person.JobTitle}";

                await FileIO.WriteTextAsync(file, txt);
            }
            catch { }
        
        }


    }
}
