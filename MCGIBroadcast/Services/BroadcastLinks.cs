using MCGIBroadcast.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace MCGIBroadcast.Services
{
    public class BroadcastLinks
    {
        private const string MCGI_LINK = "http://is.mcgi.org/api/broadcast/default.aspx?device=ios&version=1.0&callback=?";
        ObservableCollection<BroadcastModel> _myLinks = new ObservableCollection<BroadcastModel>();

        /// <summary>
        /// Gets the Broadcast Links' details.
        /// </summary>
        /// <returns>Broadcast links details.</returns>
        public async Task<ObservableCollection<BroadcastModel>> GetLinks()
        {
            // Check if Links has been loaded before
            if (_myLinks.Count > 0)
            {
                return _myLinks;
            }

            // Retrieve Broadcast Links' details
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(MCGI_LINK);
                response.EnsureSuccessStatusCode();

                var jsonResult = await response.Content.ReadAsStringAsync();

                _myLinks = JsonConvert.DeserializeObject<ObservableCollection<BroadcastModel>>(jsonResult);
            }
            catch (Exception)
            {

            }

            return _myLinks;
        }

        /// <summary>
        /// Static Text for the Welcome note.
        /// </summary>
        /// <returns>The welcome note.</returns>
        public ObservableCollection<NoteModel> GetNote()
        {
            var collection = new ObservableCollection<NoteModel>();
            collection.Add(new NoteModel()
            {
                Content = "Watch the 24-hour broadcast of The Old Path(Ang Dating Daan), the flagship broadcast program of Members Church of God International, using MCGI Broadcast App.\n\r" + 
                "This app aims to provide a 24/7 programming of the Old Path broadcast in the following language formats: English, Portuguese, Spanish and Tagalog.\n\r" + 
                "The Old Path is hosted by Bro. Eliseo F. Soriano and has started in the Philippines in 1980. Its question-and-answer segment \"Ask Soriano\" has catapulted the program to its phenomenal rise as an award-winning informative religious show."
            });
            return collection;
        }

        /// <summary>
        /// Static Links for External Links.
        /// </summary>
        /// <returns>External links.</returns>
        public ObservableCollection<ExternalLinksModel> GetExternalLinks()
        {
            var links = new ObservableCollection<ExternalLinksModel>();

            links.Add(new ExternalLinksModel()
            {
                Name = "MCGI",
                Description = "The official website of the \nMembers Church of God International",
                URL = new Uri("http://mcgi.org")
            });

            links.Add(new ExternalLinksModel()
            {
                Name = "Ang Dating Daan",
                Description = "The official website of the Ang Dating Daan",
                URL = new Uri("http://angdatingdaan.org")
            });

            links.Add(new ExternalLinksModel()
            {
                Name = "The Old Path",
                Description = "The official website of The Old Path",
                URL = new Uri("http://theoldpath.tv")
            });

            return links;
        }
    }
}
