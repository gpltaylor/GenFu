﻿using System;

namespace GenFu.Fillers
{
    public class DateTimeAdapterFiller<T> : DateTimeNullableFiller
    {
        DateTimeFiller dateTimeFiller = new DateTimeFiller();
        private Random rand = new Random();

        public override object GetValue(object instance)
        {
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (this.SeedPercentage < rand.NextDouble())
                {
                    return null;
                }
                else
                {
                    return dateTimeFiller.GetValue(instance);
                }
            }

            return dateTimeFiller.GetValue(instance);
        }
    }
}
