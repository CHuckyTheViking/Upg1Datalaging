using Newtonsoft.Json;
using SharedClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Data.Json;
using Windows.Storage;
using Windows.System.Update;
using Windows.UI.Xaml.Media;

namespace SharedClassLibary.Services
{
    public class ReadFileService
    {

        public static async Task<ObservableCollection<Person>> FilePickerAsync()
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>();

            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                picker.FileTypeFilter.Add(".txt");
                picker.FileTypeFilter.Add(".xml");
                picker.FileTypeFilter.Add(".json");
                picker.FileTypeFilter.Add(".csv");


                StorageFile file = await picker.PickSingleFileAsync();


                var type = file.FileType;

                if (type == ".json")
                {
                    var filetext = await FileIO.ReadTextAsync(file);

                    people = JsonConvert.DeserializeObject<ObservableCollection<Person>>(filetext);
                }

                if (type == ".csv")
                {
                    var filetext = await FileIO.ReadTextAsync(file);

                    var fileText = filetext.Split(';');

                    var data = new Person { FirstName = fileText[0], LastName = fileText[1], Address = fileText[2], Email = fileText[3], JobTitle = fileText[4] };
                    people.Add(data);
                }

                if (type == ".xml")
                {
                    var filetext = await FileIO.ReadTextAsync(file);

                    try
                    {
                        using (TextReader reader = new StringReader(filetext))
                        {
                            var serializer = new XmlSerializer(typeof(List<Person>));
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
                            var serializer = new XmlSerializer(typeof(Person));
                            var ppl = (Person)serializer.Deserialize(reader);
                            people.Add(ppl);
                            reader.Close();
                        }
                    }

                }

                if (type == ".txt")
                {
                    var filetext = await FileIO.ReadTextAsync(file);

                    var fileText = filetext.Split(',');

                    var data = new Person { FirstName = fileText[0], LastName = fileText[1], Address = fileText[2], Email = fileText[3], JobTitle = fileText[4] };
                    people.Add(data);
                }

               
            }
            catch { }
            return people;
        }
    }
}
