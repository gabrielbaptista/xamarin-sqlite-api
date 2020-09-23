using SQLite;

namespace AppSample.Models
{
    [Table("tbPeople")]
    public class Person
    {
        [PrimaryKey]
        public string _id { get; set; }
        public string personName { get; set; }
        public string Description { get; set; }
    }
}