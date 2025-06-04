
namespace RestSharpApiTestFramework.Core.Models
{
    public class User
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public string createdAt { get; set; }
        public override string ToString()
        {
            return $"Name: {name}, Job: {job}, Id: {id}, Created At: {createdAt}";
        }
    }
}
