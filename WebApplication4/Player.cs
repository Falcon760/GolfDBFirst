
namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class Player
    {
        public Player()
        {
            this.ScoreCards = new HashSet<ScoreCard>();
            this.Rounds = new HashSet<Round>();
        }
    
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<int> Handicap { get; set; }
        public string Comments { get; set; }
        [NotMapped]
        [Display(Name = "Player Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
        public virtual Combined Combined { get; set; }
    }
}
