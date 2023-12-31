using ms.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace ms.Utils
{

    public class Root
    {
        public DateOnly dateSlot { get; set; }
        public TimeOnly timeSlot { get; set; }
    }

    public class Requests
    {

        private static HttpClient _client = new HttpClient();
        public Requests() { }

        public HttpResponseMessage sendPostAsync(string name, string pass)
        {
            if(_client.Timeout.Minutes != 3)
            {
                _client.Timeout = new TimeSpan(0, 3, 0);
            }
            var requestData = new { username = name, password = pass };
            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = _client.PostAsync($"http://earms.onrender.com/ms/auth/login", content);
                if (response.IsCanceled)
                {
                    return null;
                }
                else
                {
                    return response.Result;
                }
                
            }
            catch(TaskCanceledException e)
            {
                return null;
            }
            
        }

        public List<EventModel> GetWebsiteDataAsync()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync("http://earms.onrender.com/ms/rest/event/allOwned").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<EventModel> myDeserializedClass = JsonConvert.DeserializeObject<List<EventModel>>(result);
                return myDeserializedClass;
            }
            return [];
        }

        public List<EventModel> GetGuestEvents()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = _client.GetAsync("https://earms.onrender.com/ms/rest/event/allGuest").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<EventModel> myDeserializedClass = JsonConvert.DeserializeObject<List<EventModel>>(result);
                return myDeserializedClass;
            }
            return [];
        }

        public bool CloseEvent(int id)
        {
            HttpResponseMessage response = _client.PutAsync($"http://earms.onrender.com/ms/rest/event/{id}/close", null).Result;
            if (response.IsSuccessStatusCode)
            { 
                return true;
            }
            return false;
        }

        public bool DeleteEvent(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync($"http://earms.onrender.com/ms/rest/event/{id}/delete").Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public EventModel GetEvent(int id)
        {
            HttpResponseMessage response = _client.GetAsync($"https://earms.onrender.com/ms/rest/event/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                EventModel myDeserializedClass = JsonConvert.DeserializeObject<EventModel>(result);
                return myDeserializedClass;
            }
            return null;
        }

        public bool SetFinalOption(int id)
        {
            HttpResponseMessage response = _client.PostAsync($"http://earms.onrender.com/ms/rest/event/options/final/{id}", null).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool DeleteOption(int eventId, int optionId)
        {
            HttpResponseMessage response = _client.DeleteAsync($"http://earms.onrender.com/ms/rest/event/{eventId}/options/{optionId}").Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool AddOption(PollOptionModel pollOption)
        {
            string jsonData = JsonConvert.SerializeObject(new[] { pollOption });

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"https://earms.onrender.com/ms/rest/event/{pollOption.eventId}/options/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool AddUsername(string username, int id)
        {
            string jsonData = JsonConvert.SerializeObject(new[] { username });

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"http://earms.onrender.com/ms/rest/event/{id}/guests/add/registered", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool AddEmail(string email, int id)
        {
            string jsonData = JsonConvert.SerializeObject(new[] { email });

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"http://earms.onrender.com/ms/rest/event/{id}/guests/add/notregistered", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool DeleteGuest(int eventId, int guestId)
        {
            HttpResponseMessage response = _client.DeleteAsync($"http://earms.onrender.com/ms/rest/event/{eventId}/guests/delete/{guestId}").Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool UpdateEvent(EventModel eventModel)
        {
            var requestData = new { name = eventModel.name, detail = eventModel.Detail, location = eventModel.Location, openDueTo = eventModel.openDueTo };
            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync($"http://earms.onrender.com/ms/rest/event/{eventModel.id}/update", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public EventModel CreateEvent(EventModel eventModel)
        {
            var requestData = new { name = eventModel.name, detail = eventModel.Detail, location = eventModel.Location, openDueTo = eventModel.openDueTo };
            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync($"http://earms.onrender.com/ms/rest/event/create", content).Result;
            var test = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                EventModel myDeserializedClass = JsonConvert.DeserializeObject<EventModel>(result);
                return myDeserializedClass;
            }
            return null;
        }

        public bool AddVote(VoteModel vote)
        {
            string jsonData = JsonConvert.SerializeObject(new[] { vote });

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = _client.PutAsync($"https://earms.onrender.com/ms/rest/event/options/{vote.PollOptionId}/votes/add", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public AccountModel GetMyAccount()
        {
            HttpResponseMessage response = _client.GetAsync($"http://earms.onrender.com/ms/rest/users/current").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                AccountModel myDeserializedClass = JsonConvert.DeserializeObject<AccountModel>(result);
                return myDeserializedClass;
            }
            return null;
        }

        public UserModel GetUser(int id)
        {
            HttpResponseMessage response = _client.GetAsync($"http://earms.onrender.com/ms/rest/users/get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                UserModel myDeserializedClass = JsonConvert.DeserializeObject<UserModel>(result);
                return myDeserializedClass;
            }
            return null;
        }
        public bool LeaveEvent(int eventId)
        {
            HttpResponseMessage response = _client.DeleteAsync($"https://earms.onrender.com/ms/rest/event/{eventId}/guests/leave").Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public UserModel GetUserByUsername(string username)
        {
            HttpResponseMessage response = _client.GetAsync($"https://earms.onrender.com/ms/rest/users/getByName/{username}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                UserModel myDeserializedClass = JsonConvert.DeserializeObject<UserModel>(result);
                return myDeserializedClass;
            }
            return null;
        }

        public bool UpdateUser(UserModel user)
        {
            var requestData = new { username = user.username, password = user.password, firstName = user.firstName, lastName = user.lastName, email = user.email };
            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync($"http://earms.onrender.com/ms/rest/users/update", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public HttpResponseMessage RegisterUser(UserModel user)
        {
            var requestData = new { username = user.username, password = user.password, firstName = user.firstName, lastName = user.lastName, email = user.email };
            string json = System.Text.Json.JsonSerializer.Serialize(requestData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync($"http://earms.onrender.com/ms/rest/users/register", content).Result;
            return response;
        }

        public bool Logout()
        {
            HttpResponseMessage response = _client.PostAsync($"https://earms.onrender.com/ms/logout", null).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
