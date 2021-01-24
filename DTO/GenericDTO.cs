using System;
using System.ComponentModel.DataAnnotations;

namespace fpAPI.DTO
{
    public class Pagination
    {
        [Required]
        public bool Paginated { get; set; }
        public int Page { get; set; } = 1;
        public string Search { get; set; }

        private int qtyRecordsPerPage = 10;
        private readonly int maxQtyRecordsPerPage = 50;

        public int ResourceQty
        {
            get => qtyRecordsPerPage;
            set
            {
                qtyRecordsPerPage = (value > maxQtyRecordsPerPage ? maxQtyRecordsPerPage : value);
            }
        }
    }
}
