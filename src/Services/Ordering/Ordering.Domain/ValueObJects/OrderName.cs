﻿namespace Ordering.Domain.ValueObJects
{
    public record OrderName
    {
        private const int DefaultLenght = 5;

		public string Value { get; }

        private OrderName(string value) => Value = value;

		public static OrderName Of(string value)
        {
			ArgumentNullException.ThrowIfNull(value);
			ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLenght);

			return new OrderName(value);
		}
	}
}
