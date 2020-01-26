using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("category")]
    public class Category : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id", Order = 0)]
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "NameEn can't be longer than 255 characters")]
        [Column("name_en")]
        public string NameEn { get; set; }

        [StringLength(255, ErrorMessage = "NamePt can't be longer than 255 characters")]
        [Column("name_pt")]
        public string NamePt { get; set; }

        [StringLength(255, ErrorMessage = "NameCht can't be longer than 255 characters")]
        [Column("name_cht")]
        public string NameCht { get; set; }

        [StringLength(255, ErrorMessage = "NameChs can't be longer than 255 characters")]
        [Column("name_chs")]
        public string NameChs { get; set; }

        [StringLength(255, ErrorMessage = "NameIt can't be longer than 255 characters")]
        [Column("name_it")]
        public string NameIt { get; set; }

        [StringLength(255, ErrorMessage = "NameFr can't be longer than 255 characters")]
        [Column("name_fr")]
        public string NameFr { get; set; }

    }
}