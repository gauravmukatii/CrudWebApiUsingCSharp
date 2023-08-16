namespace CrudApi.Models
{
    public class UpdateEmployeeRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
