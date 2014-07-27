
namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Score
    {
        public int id { get; set; }
        public int ScoreCardid { get; set; }
        public Nullable<int> Strokes { get; set; }
        public int Holeid { get; set; }
    
        public virtual ScoreCard ScoreCard { get; set; }
        public virtual Hole Hole { get; set; }
    }
}
