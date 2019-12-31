// <copyright file=BasicProgress>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 31/12/2019 19:15:46</date>
// <summary>A basic simple Tool based on C# for Xiaomi Redmi Note 7 Lavender </summary>



using System;

namespace RedmiNote7ToolC
{
    class BasicProgress<T> : IProgress<T>
    {
        private readonly Action<T> _handler;

        public BasicProgress(Action<T> handler)
        {
            _handler = handler;
        }

        void IProgress<T>.Report(T value)
        {
            _handler(value);
        }
    }
}
