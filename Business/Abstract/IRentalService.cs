using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll(Expression<Func<Rental,bool>> filter=null);
        IResult Add(Rental rental);
        IDataResult<List<RentalDetail>> GetRentalDetails();
        IResult RentalCarControl(int carId);
    }
}
