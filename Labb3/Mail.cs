﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    [Serializable]
    public class Mail : BaseMessage
    {
        
        public bool isSeen { get; set; }
}
}