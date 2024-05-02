namespace Sigim.Application.Models
{
    public class IncomeResult
    {
        public string Id { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public virtual UserResult? Usuario { get; set; }    
    }
}
