﻿using Parser.Enums;

namespace Parser.Types
{
    public abstract record class Node
    {
        public virtual NodeType NodeType { get; init; }
    }
}
