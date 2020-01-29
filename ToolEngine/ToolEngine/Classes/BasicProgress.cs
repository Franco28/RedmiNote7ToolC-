// <copyright file=BasicProgress>
// Copyright (c) 2019-2020 All Rights Reserved
// </copyright>
// <author>Franco28</author>
// <date> 29/1/2020 13:16:41</date>
// <summary>A DLL Lib needed by Redmi Note 7 Tool</summary>

using System;

namespace Franco28Tool.Engine
{
    public class BasicProgress<T> : IProgress<T>
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
