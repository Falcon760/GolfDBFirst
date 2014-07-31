
namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Round
    {
        public Round()
        {
            this.ScoreCards = new HashSet<ScoreCard>();
            this.Holes = new HashSet<Hole>();
            this.Players = new HashSet<Player>();
        }
    
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Round")]
        public System.DateTime RoundDate { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
        public virtual ICollection<Hole> Holes { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
