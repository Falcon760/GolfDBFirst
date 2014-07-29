
namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Combined
    {
        public int Id { get; set; }
        public int PlayerCount { get; set; }
        public int? Handicap { get; set; }
        public string Name { get; set; }
        public virtual Player Player { get; set; }
        public virtual ScoreCard ScoreCard { get; set; }
    }
}
