namespace PinyinCardApi.Entities.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CategoryProps
{
    public string? NameEn { get; set; }
    public string? NameIt { get; set; }
    public string? NameFr { get; set; }
    public string? NameDe { get; set; }
    public string? NameRu { get; set; }
    public string? NamePt { get; set; }
    public string? NameChs { get; set; }
    public string? NameCht { get; set; }
    public string? Image { get; set; }
}

[Table("category")]
public class Category : BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Column("id", Order = 0)]
    public int Id { get; set; }

    // [StringLength(255, ErrorMessage = "NameEn can't be longer than 255 characters")]
    // [Column("name_en")]
    // public string NameEn { get; set; }

    // [StringLength(255, ErrorMessage = "NamePt can't be longer than 255 characters")]
    // [Column("name_pt")]
    // public string NamePt { get; set; }

    // [StringLength(255, ErrorMessage = "NameCht can't be longer than 255 characters")]
    // [Column("name_cht")]
    // public string NameCht { get; set; }

    // [StringLength(255, ErrorMessage = "NameChs can't be longer than 255 characters")]
    // [Column("name_chs")]
    // public string NameChs { get; set; }

    // [StringLength(255, ErrorMessage = "NameIt can't be longer than 255 characters")]
    // [Column("name_it")]
    // public string NameIt { get; set; }

    // [StringLength(255, ErrorMessage = "NameFr can't be longer than 255 characters")]
    // [Column("name_fr")]
    // public string NameFr { get; set; }

    // [StringLength(255, ErrorMessage = "NameFr can't be longer than 255 characters")]
    // [Column("name_de")]
    // public string NameDe { get; set; }

    // [Column("parent_category_id")]
    // public int? ParentCategoryId { get; set; }

    // [Column("parent_category_id")]
    // public Category? ParentCategory { get; set; }

    // , TypeName = "Json"
    [Column("props")]
    public CategoryProps Props { get; set; }
}
