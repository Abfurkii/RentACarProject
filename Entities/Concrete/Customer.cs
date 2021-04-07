using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //id:number,
    //userId:number,
    //firstName:string,
    //lastName:string,
    //companyName:string,
    //email:string,
    //status:boolean;
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
