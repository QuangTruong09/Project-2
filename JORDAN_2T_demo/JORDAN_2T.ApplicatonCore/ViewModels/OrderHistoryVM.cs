using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JORDAN_2T.ApplicationCore.Models;

namespace JORDAN_2T.ApplicationCore.ViewModels;

    public class OrderHistoryVM
    {
        
        public IEnumerable<OrderDetail> OrderDetails {get;set;}
        public IEnumerable<Order> Order { get; set; }
    }

