namespace ModelEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Yêu cầu nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [Required(ErrorMessage = "Yêu cầu nhập giá sản phẩm")]
        [Display(Name = "Đơn giá")]
        public decimal? UnitCost { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập số lượng sản phẩm")]
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string image { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã loại sản phẩm")]

        public string idCategoryNo { get; set; }

        public virtual tblCategory tblCategory { get; set; }
    }
}
