﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string CreditCardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Ccv { get; set; }
    }
}
