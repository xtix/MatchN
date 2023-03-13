using System;
using System.Collections.Generic;
using System.Linq;
using App.Services.Item.ColorGenerator;
using FluentAssertions;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Services.Item.ColorGenerator
{
    public class ItemColorGeneratorTests
    {
        [Test]
        public void WhenGenerateItemTypeColorThenEveryItemTypeColorShouldBeUnique(
            [NUnit.Framework.Range(1, 50)] int itemTypesCount
        ) {
            ItemColorGenerator itemColorGenerator = new ItemColorGenerator(itemTypesCount);

            IEnumerable<Color> colors = Enumerable.Range(0, itemTypesCount - 1)
                .Select(itemType => itemColorGenerator.GenerateColor(itemType));

            colors.Should().OnlyHaveUniqueItems();
        }

        [TestCase(3, -1)]
        [TestCase(3, 3)]
        [TestCase(3, 4)]
        public void WhenTryGenerateColorWithOutOfRangeItemTypeThenExceptionShouldBeThrown(
            int itemTypesCount,
            int itemType
        ) {
            ItemColorGenerator itemColorGenerator = new ItemColorGenerator(itemTypesCount);

            Action act = () => itemColorGenerator.GenerateColor(itemType);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}