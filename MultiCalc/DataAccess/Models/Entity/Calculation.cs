using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DataAccess.Models.Entity
{
    [DataContract]
    [Table("Calculation")]
    public class Calculation 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string NumberA { get; set; }

        [DataMember]
        public string NumberB { get; set; }

        [DataMember]
        public string Op { get; set; }

        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public virtual Person Person { get; set; }
    }
}