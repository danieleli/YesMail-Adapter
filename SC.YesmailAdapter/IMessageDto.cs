using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC.YesMailAdapter
{
    public interface IMessageDto
    {
        string MasterMessageId { get; set; }
        string ConsumerId { get; set; }
        string Email { get; set; }
    }
}
