
namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class Hole
    {
        public Hole()
        {
            this.Rounds = new HashSet<Round>();
            this.Scores = new HashSet<Score>();
        }
    
        public int Id { get; set; }
        public int Number { get; set; }
        public int Par { get; set; }
        public Nullable<int> TotalYards { get; set; }
        public Nullable<int> YardsFromBlue { get; set; }
        public Nullable<int> YardsFromWhite { get; set; }
        public Nullable<int> YardsFromRed { get; set; }
        public int CourseId { get; set; }
        public Nullable<int> Score { get; set; }
        public string Name { get; set; }
        [DisplayName("Hole Name")]
        public string _Name { get { return Course.Name + " Hole " + Number; } }
        public virtual Course Course { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
