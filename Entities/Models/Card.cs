using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Innofactor.EfCoreJsonValueConverter;



namespace Entities.Models
{
    public class ExtraEn
    {
        public string Pronunciation { get; set; }
    }

    public class ExtraPt
    {
        public string Gender { get; set; }
        public string FemaleName { get; set; }

        public string FemaleAudio { get; set; }
    }

    public class ExtraIt
    {
        public string Gender { get; set; }

        public string FemaleName { get; set; }

        public string FemaleAudio { get; set; }
    }

    public class ExtraFr
    {
        public string Gender { get; set; }

        public string FemaleName { get; set; }

        public string FemaleAudio { get; set; }
    }

    public class ExtraDe
    {
        public string Gender { get; set; }

        public string FemaleName { get; set; }

        public string FemaleAudio { get; set; }
    }

    public class ExtraCh
    {
        public string MeasureWordT { get; set; }
        public string MeasureWordS { get; set; }
    }
    [Table("card")]
    public class Card : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id", Order = 0)]
        public int Id { get; set; }

        [StringLength(255, ErrorMessage = "NameEn can't be longer than 255 characters")]
        [Column("name_en")]
        public string NameEn { get; set; }

        [StringLength(255, ErrorMessage = "AudioEn can't be longer than 255 characters")]
        [Column("audio_en")]
        public string AudioEn { get; set; }

        [Column("extra_en", TypeName = "Json")]
        [JsonField]
        public ExtraEn ExtraEn { get; set; }

        [StringLength(255, ErrorMessage = "NamePt can't be longer than 255 characters")]
        [Column("name_pt")]
        public string NamePt { get; set; }

        [StringLength(255, ErrorMessage = "AudioPt can't be longer than 255 characters")]
        [Column("audio_pt")]
        public string AudioPt { get; set; }

        [Column("extra_pt", TypeName = "Json")]
        [JsonField]
        public ExtraPt ExtraPt { get; set; }

        [StringLength(255, ErrorMessage = "NameCht can't be longer than 255 characters")]
        [Column("name_cht")]
        public string NameCht { get; set; }

        [StringLength(255, ErrorMessage = "NameChs can't be longer than 255 characters")]
        [Column("name_chs")]
        public string NameChs { get; set; }

        [StringLength(255, ErrorMessage = "NameChs can't be longer than 255 characters")]
        [Column("pinyin")]
        public string Pinyin { get; set; }

        [StringLength(255, ErrorMessage = "AudioCh can't be longer than 255 characters")]
        [Column("audio_ch")]
        public string AudioCh { get; set; }

        [Column("extra_ch", TypeName = "Json")]
        [JsonField]
        public ExtraCh ExtraCh { get; set; }

        [StringLength(255, ErrorMessage = "NameIt can't be longer than 255 characters")]
        [Column("name_it")]
        public string NameIt { get; set; }

        [StringLength(255, ErrorMessage = "AudioIt can't be longer than 255 characters")]
        [Column("audio_it")]
        public string AudioIt { get; set; }

        [Column("extra_it", TypeName = "Json")]
        [JsonField]
        public ExtraIt ExtraIt { get; set; }

        [StringLength(255, ErrorMessage = "NameFr can't be longer than 255 characters")]
        [Column("name_fr")]
        public string NameFr { get; set; }

        [StringLength(255, ErrorMessage = "AudioFr can't be longer than 255 characters")]
        [Column("audio_fr")]
        public string AudioFr { get; set; }

        [Column("extra_fr", TypeName = "Json")]
        [JsonField]
        public ExtraFr ExtraFr { get; set; }

        [StringLength(255, ErrorMessage = "NameEn can't be longer than 255 characters")]
        [Column("name_de")]
        public string NameDe { get; set; }

        [StringLength(255, ErrorMessage = "AudioEn can't be longer than 255 characters")]
        [Column("audio_de")]
        public string AudioDe { get; set; }

        [Column("extra_de", TypeName = "Json")]
        [JsonField]
        public ExtraDe ExtraDe { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }


        [Column("category_id")]
        public Category Category { get; set; }

    }
}