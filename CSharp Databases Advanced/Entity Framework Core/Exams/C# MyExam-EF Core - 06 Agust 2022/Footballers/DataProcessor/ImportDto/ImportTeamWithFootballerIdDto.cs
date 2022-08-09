using System.ComponentModel.DataAnnotations;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamWithFootballerIdDto
    {
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+$")]
        public string Name { get; set; }

        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Range(1, int.MaxValue)]
        public int Trophies { get; set; }

        //or IEnumerable<int>
        public virtual int[] Footballers { get; set; }
    }
}
