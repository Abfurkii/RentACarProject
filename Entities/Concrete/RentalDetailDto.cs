using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //CarId yerine BrandName, CustomerId yerine FirstName + LastName şeklinde gösteriniz.
    public class RentalDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrandName { get; set; }
    }
}
