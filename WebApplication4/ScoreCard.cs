//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class ScoreCard
    {
        public ScoreCard()
        {
            this.TotalScore = 0;
            this.Scores = new HashSet<Score>();
        }
    
        public int Id { get; set; }
        [Display(Name="Total Score")]
        [DisplayFormat(DataFormatString="{0:# Strokes}", ApplyFormatInEditMode=true, NullDisplayText="No Total Score")]
        public Nullable<int> TotalScore { get; set; }
        [DisplayName("Player Name")]
        public int PlayerId { get; set; }
        [DisplayName("Round Name")]
        public int RoundId { get; set; }
        [DisplayName("ScoreCard Name")]
        public string Name { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Round Round { get; set; }
        public virtual ICollection<Score> Scores { get; set; }
    }
}
