﻿using System;
using Yugen.Toolkit.Standard.Collections;

namespace Yugen.Toolkit.Standard.Mvvm.Mediator
{
    /// <summary>
    /// in viewmodel constructor register to the mediator for the UserWroteSomething message,
    /// Callback delegate, when message is seen MediatorService.Instance.Register(o => { CommandBarViewModel.Title = (string) o; },
    /// </summary>
    public sealed class MediatorService
    {
        private static MediatorService _instance;

        private readonly MultiDictionary<string, Action<object>> _internalList =
                    new MultiDictionary<string, Action<object>>();

        public static MediatorService Instance => _instance ?? (_instance = new MediatorService());

        /// <summary>
        /// Registers a Colleague to a specific message
        /// </summary>
        /// <param name="message">The message to register to</param>
        /// <param name="callback">The callback to use when the message it seen</param>
        public void Register(string message, Action<object> callback) =>
            _internalList.AddValue(message, callback);

        /// <summary>
        /// Notify all colleagues that are registed to the specific message
        /// </summary>
        /// <param name="message">The message for the notify by</param>
        /// <param name="args">The arguments for the message</param>
        public void NotifyColleagues(string message, object args)
        {
            if (_internalList.ContainsKey(message))
            {
                //forward the message to all listeners
                foreach (Action<object> callback in _internalList[message])
                {
                    callback(args);
                }
            }
        }
    }
}