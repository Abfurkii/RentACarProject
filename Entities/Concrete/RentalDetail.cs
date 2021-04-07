using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //carId: number;
    //customerId: number;
    //rentDate: Date;
    //returnDate: Date;
    //brandName: string;
    //colorName: string;
    //dailyPrice: number;
    //description:string;
    public class RentalDetail
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
