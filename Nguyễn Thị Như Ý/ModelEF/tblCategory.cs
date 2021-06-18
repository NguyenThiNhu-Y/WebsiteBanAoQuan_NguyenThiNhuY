namespace ModelEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCategory")]
    public partial class tblCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCategory()
        {
            tblProducts = new HashSet<tblProduct>();
        }

        [StringLength(10)]
        [Display(Name = "Mã loại sản phẩm")]
        public string id { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên loại phẩm")]
        public string name { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
    }
}
