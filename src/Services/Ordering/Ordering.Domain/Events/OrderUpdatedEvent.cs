using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Events
{
    class OrderUpdatedEvent(Order order) : IDomainEvent;
}
