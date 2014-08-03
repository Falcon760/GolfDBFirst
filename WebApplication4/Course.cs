//------------------------------------------------------------------------------
// <auto-generated>

namespace WebApplication4
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Course
    {
        public Course()
        {
            this.Holes = new HashSet<Hole>();
            this.Rounds = new HashSet<Round>();
        }
    
        public int Id { get; set; }
        [Required]
        [DisplayName("Course Name")]
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Hole> Holes { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
    }
}
