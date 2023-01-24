﻿using CustomStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace CustomStore.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        private List<Event> notifications;

        public IReadOnlyCollection<Event> Notifications => notifications?.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if(ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public void AddEvent(Event eventItem)
        {
            notifications = notifications ?? new List<Event> { };
            notifications.Add(eventItem);
        }

        public void RemoveEvent(Event eventItem)
        {
            notifications?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            notifications?.Clear();
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
