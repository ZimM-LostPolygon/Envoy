﻿using System;

namespace LostPolygon.Envoy.Internal {
    public abstract class EnvoyEventBase {
        protected EventDispatchType _defaultDispatchType;

        protected EnvoyEventBase() {
            _defaultDispatchType = EventDispatchType.Now;
        }

        protected EnvoyEventBase(EventDispatchType defaultDispatchType) {
            _defaultDispatchType = defaultDispatchType == EventDispatchType.Default ?
                                   EventDispatchType.Now :
                                   defaultDispatchType;
        }

        public abstract Delegate Event { get; }
        public abstract int RemoveAllListeners();
        public abstract void DispatchDeferred();

        public void Dispose() {
            RemoveAllListeners();
        }
    }
}