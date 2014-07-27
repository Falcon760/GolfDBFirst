
namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class ScoreCard
    {
        public ScoreCard()
        {
            this.Scores = new HashSet<Score>();
        }
    
        public int Id { get; set; }
        public Nullable<int> TotalScore { get; set; }
        public int PlayerId { get; set; }
        public int RoundId { get; set; }
        [DisplayName("ScoreCard Name")]
        public string Name { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Round Round { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
