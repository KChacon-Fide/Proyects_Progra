using System.ComponentModel.DataAnnotations.Schema;

namespace PAW.Models
{
    public partial class Product
    {

        [NotMapped]
        public bool IsDirty { get; set; }

        [NotMapped]
        public DateTime LastRetreived { get; set; }
    }
}
